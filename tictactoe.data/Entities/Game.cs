using tictactoe.data.Entities;
using tictactoe.data.Enums;

namespace tictactoe.data.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public int BoardSize { get; set; }
        public int PlayerXId { get; set; }
        public int? PlayerOId { get; set; }
        public GameStatus Status { get; set; } = GameStatus.InProgress;
        public bool IsDeleted { get; set; } = false;
        public GameOutcome OutcomeStatus { get; set; } = GameOutcome.None;
        public int WinningLineLength { get; set; }
        public int? WinningPlayerId { get; set; } // Nullable, as not all games have a winner
        public List<Move> Moves { get; set; } = new List<Move>();
    }
}