using MediatR;
using tictactoe.domain.DTOs;


namespace tictactoe.domain.Queries
{
    public class GetPlayersQuery : IRequest<List<PlayerDTO>> { }
}