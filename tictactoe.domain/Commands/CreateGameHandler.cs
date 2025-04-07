using MediatR;
using tictactoe.data.Entities;
using tictactoe.data.Repositories;
using tictactoe.data.Enums;

namespace tictactoe.domain.Commands
{
    public class CreateGameHandler : IRequestHandler<CreateGameCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateGameHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var game = new Game { PlayerXId = request.PlayerXId,
                PlayerOId = request.PlayerOId,
                BoardSize = request.BoardSize,
                WinningLineLength = request.WinningLineLength };
            game.Status = GameStatus.InProgress;
            await _unitOfWork.Games.AddAsync(game);
            await _unitOfWork.SaveChangesAsync();
            return game.Id;
        }
    }
}
