// CreateGameHandler.cs
using MediatR;
using tictactoe.data.Entities;
using tictactoe.data.Repositories;
using tictactoe.data.Enums;

namespace tictactoe.domain.Commands
{
    public class CreateGameHandler : IRequestHandler<CreateGameCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGameRepository _gameRepository;
        public CreateGameHandler(IUnitOfWork unitOfWork, IGameRepository gameRepository)
        {
            _unitOfWork = unitOfWork;
            _gameRepository = gameRepository;
        }

        public async Task<int> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var game = new Game
            {
                PlayerXId = request.PlayerXId,
                PlayerOId = request.PlayerOId,
                BoardSize = request.BoardSize,
                WinningLineLength = request.WinningLineLength,
            };
            // Kreiraj igru u bazi podataka

            await _gameRepository.CreateGame(game);
            await _unitOfWork.SaveChangesAsync(); // Transakcija se potvrđuje ovde
            return game.Id;
        }
    }
}