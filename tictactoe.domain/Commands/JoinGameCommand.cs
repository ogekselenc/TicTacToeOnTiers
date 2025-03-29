using MediatR;

namespace tictactoe.domain.Commands
{
    public class JoinGameCommand : IRequest<bool>
    {
        public int GameId { get; set; }
        public int PlayerId { get; set; }

        public JoinGameCommand(int gameId, int playerId)
        {
            GameId = gameId;
            PlayerId = playerId;
        }
    }
}
