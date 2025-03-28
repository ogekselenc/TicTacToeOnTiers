using System;
using System.Collections.Generic;

namespace tictactoe.data.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public int BoardSize { get; set; }
        public int WinningLineLength { get; set; }
        public int? PlayerXId { get; set; }
        public int? PlayerOId { get; set; }
        public GameStatus Status { get; set; }
        public ICollection<Move> Moves { get; set; } = new List<Move>();

        public enum GameStatus
        {
            WaitingForOpponent,
            InProgress,
            Finished
        }
    }
}
