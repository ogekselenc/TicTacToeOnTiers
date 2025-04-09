using MediatR;
using tictactoe.data.Entities;
using tictactoe.data.Repositories;

namespace tictactoe.domain.Queries
{
    public class GetGameQuery : IRequest<Game>
    {
        public int GameId { get; set; }
        public GetGameQuery(int gameId)
        {
            GameId = gameId;
        }
    }

    public class GetGameHandler : IRequestHandler<GetGameQuery, Game>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetGameHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Game> Handle(GetGameQuery request, CancellationToken cancellationToken)
        {
            var game = await _unitOfWork.Games.GetByIdAsync(request.GameId);
            if (game == null)
            {
                throw new KeyNotFoundException($"Game with ID {request.GameId} was not found.");
            }
            return game;
        }
    }
}