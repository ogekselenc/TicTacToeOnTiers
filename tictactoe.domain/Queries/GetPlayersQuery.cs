using MediatR;
using System.Collections.Generic;
using tictactoe.data.Entities;

namespace tictactoe.domain.Queries
{
    public class GetPlayersQuery : IRequest<List<Player>>
    {
    }
}
