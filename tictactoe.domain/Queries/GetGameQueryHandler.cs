// GetGameQuery.cs (Handler part)
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using tictactoe.data.Entities;
using tictactoe.data.Repositories;
using tictactoe.domain.DTOs;

namespace tictactoe.domain.Queries
{
    public class GetGameHandler : IRequestHandler<GetGameQuery, GameDTO>
    {
        private readonly IGameReadRepository _gameReadRepository;

        public GetGameHandler(IGameReadRepository gameReadRepository)
        {
            _gameReadRepository = gameReadRepository;
        }

        public async Task<GameDTO> Handle(GetGameQuery request, CancellationToken cancellationToken)
        {
            var game = await _gameReadRepository.GetByIdAsync(request.GameId);
            if (game == null)
            {
                throw new KeyNotFoundException($"Game with ID {request.GameId} was not found.");
            }

            return new GameDTO
            {
                Id = game.Id,
                BoardSize = game.BoardSize,
                PlayerXId = game.PlayerXId,
                PlayerOId = game.PlayerOId,
                Status = game.Status,
                OutcomeStatus = game.OutcomeStatus,
                WinningLineLength = game.WinningLineLength,
                WinningPlayerId = game.WinningPlayerId,
            };
        }
    }
}