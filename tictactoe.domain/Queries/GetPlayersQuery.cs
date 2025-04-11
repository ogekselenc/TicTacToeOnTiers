using MediatR;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using tictactoe.data.Entities;
using tictactoe.data;
using tictactoe.data.Repositories;

namespace tictactoe.domain.Queries
{
    // Query to get all players
    public class GetPlayersQuery : IRequest<List<Player>>
    {
    }

    // Handler for the GetPlayersQuery
    public class GetPlayersHandler : IRequestHandler<GetPlayersQuery, List<Player>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPlayersHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Player>> Handle(GetPlayersQuery request, CancellationToken cancellationToken)
        {
            // Fetch all players from the database
            var players = await _unitOfWork.Players.GetAllAsync();
            return players.ToList();
        }
    }
}
