using MediatR;

namespace tictactoe.domain.Commands
{
    public class MakeMoveCommand : IRequest<bool>
    {
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public MakeMoveCommand(int gameId, int playerId, int row, int column)
        {
            GameId = gameId;
            PlayerId = playerId;
            Row = row;
            Column = column;
        }
    }
}
