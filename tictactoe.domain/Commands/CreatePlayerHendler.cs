using MediatR;
using tictactoe.data.Entities;
using tictactoe.data.Repositories;

namespace tictactoe.domain.Commands
{
    public class CreatePlayerHandler : IRequestHandler<CreatePlayerCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPlayerRepository _playerRepository;
        public CreatePlayerHandler(IUnitOfWork unitOfWork, IPlayerRepository playerRepository)
        {
            _unitOfWork = unitOfWork;
            _playerRepository = playerRepository;
        }
        

        public async Task<int> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = new Player { Name = request.Name };
            await _playerRepository.AddAsync(player);
            await _unitOfWork.SaveChangesAsync();
            return player.Id;
        }
    }
}
