using MediatR;
using tictactoe.domain.DTOs;


namespace tictactoe.domain.Queries
{
    public class GetGameQuery : IRequest<GameDTO>
    {
        public int GameId { get; set; }
        public GetGameQuery(int gameId)
        {
            GameId = gameId;
        }
    }
}