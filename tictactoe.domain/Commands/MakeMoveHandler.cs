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

        public MakeMoveHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MakeMoveResponse> Handle(MakeMoveRequest request, CancellationToken cancellationToken)
        {
            var game = await _unitOfWork.Games.GetByIdAsync(request.GameId);
            var player = await _unitOfWork.Players.GetByIdAsync(request.PlayerId);

            if (game == null || player == null)
                throw new Exception("Invalid game or player");

            if (game.OutcomeStatus != 0)
                throw new Exception("Game already finished");

            if ((game.PlayerXId != request.PlayerId && game.PlayerOId != request.PlayerId))
                throw new Exception("Player not part of this game");

            /*if (game.Moves.Count % 2 == 0 && game.PlayerXId != request.PlayerId)
                throw new Exception("It's not your turn");*/

            var moves = await _unitOfWork.Moves.GetByIdAsync(game.Id);

            var board = GameLogicHelper.ReconstructBoard(game.BoardSize, game.Moves, game);
            
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

            await _unitOfWork.Moves.AddAsync(move);

            board[request.Row, request.Column] = GameLogicHelper.GetPlayerSymbol(game, request.PlayerId);
            var outcome = GameLogicHelper.CheckOutcome(board, request.Row, request.Column, game.WinningLineLength);

            if (outcome.Status != null)
            {
                game.OutcomeStatus = Enum.Parse<GameOutcome>(outcome.Status);
                game.OutcomeReason = outcome.Reason;
            }

            await _unitOfWork.SaveChangesAsync();

            return new MakeMoveResponse
            {
                Id = move.Id,
                GameId = move.GameId,
                PlayerId = move.PlayerId,
                Row = move.Row,
                Column = move.Column,
                OutcomeStatus = game.OutcomeStatus.ToString(),
                OutcomeReason = game.OutcomeReason
            };
        }
    }
}