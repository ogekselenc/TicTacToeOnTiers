using MediatR;
using Microsoft.EntityFrameworkCore;
using tictactoe.data.Entities;
using tictactoe.data.Repositories;
using tictactoe.domain.Services;
using tictactoe.domain.Commands;
using tictactoe.data.Enums;

namespace tictactoe.domain.Commands
{
    public class MakeMoveHandler : IRequestHandler<MakeMoveRequest, MakeMoveResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IGameRepository _gameRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IMoveRepository _moveRepository;

        public MakeMoveHandler(IUnitOfWork unitOfWork, IGameRepository gameRepository, IPlayerRepository playerRepository, IMoveRepository moveRepository)
        {
            _unitOfWork = unitOfWork;
            _gameRepository = gameRepository;
            _playerRepository = playerRepository;
            _moveRepository = moveRepository;
        }


        public async Task<MakeMoveResponse> Handle(MakeMoveRequest request, CancellationToken cancellationToken)
        {
            var game = await _gameRepository.GetGameById(request.GameId);
            var player = await _playerRepository.GetPlayerById(request.PlayerId);

            if (game == null || player == null)
                throw new Exception("Invalid game or player");

            if (game.Status == GameStatus.Completed)
                throw new Exception("Game already finished");

            if (game.PlayerXId != request.PlayerId && game.PlayerOId != request.PlayerId)
                throw new Exception("Player not part of this game");

            var moves = await _moveRepository.GetByGameIdAsync(game.Id);

            if (moves.Count() % 2 == 0 && game.PlayerXId != request.PlayerId)
                throw new Exception("It's not your turn (X's turn)");
            if (moves.Count() % 2 != 0 && game.PlayerOId != request.PlayerId)
                throw new Exception("It's not your turn (O's turn)");

            var board = GameLogicHelper.ReconstructBoard(game.BoardSize, moves, game);

            if (!GameLogicHelper.IsValidMove(board, request.Row, request.Column))
                throw new Exception("Invalid move position");

            var move = new Move
            {
                GameId = game.Id,
                PlayerId = player.Id,
                Row = request.Row,
                Column = request.Column,
                CreatedAt = DateTime.UtcNow
            };

            await _moveRepository.AddMove(move);

            board[request.Row, request.Column] = GameLogicHelper.GetPlayerSymbol(game, request.PlayerId);
            var (status, outcome, WinningSymbol) = GameLogicHelper.CheckOutcome(board, request.Row, request.Column, game.WinningLineLength);

            if (status == GameStatus.Completed)
            {
                game.Status = GameStatus.Completed;
                game.OutcomeStatus = outcome ?? GameOutcome.None;
                if (outcome == GameOutcome.Win)
                {
                    game.WinningPlayerId = request.PlayerId; // The player who made the winning move
                }
                else
                {
                    game.WinningPlayerId = null; // For draws
                }
            }

            await _unitOfWork.SaveChangesAsync();

            return new MakeMoveResponse
            {
                Id = move.Id,
                GameId = move.GameId,
                PlayerId = move.PlayerId,
                Row = move.Row,
                Column = move.Column,
                Status = game.Status,
                OutcomeStatus = game.OutcomeStatus,
                WinningPlayer = WinningSymbol
            };
        }
    }
}