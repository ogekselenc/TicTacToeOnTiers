using MediatR;
using tictactoe.data.Entities;
using tictactoe.data.Repositories;

namespace tictactoe.domain.Commands
{
    public class CreatePlayerHandler : IRequestHandler<CreatePlayerCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePlayerHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = new Player { Name = request.Name };
            await _unitOfWork.Players.AddAsync(player);
            await _unitOfWork.SaveChangesAsync();
            return player.Id;
        }
    }
}
