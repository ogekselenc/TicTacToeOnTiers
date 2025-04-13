// GameDTO.cs
using System.Collections.Generic;
using tictactoe.data.Enums;
using tictactoe.data.Entities;

namespace tictactoe.domain.DTOs
{
    public class GameDTO
    {
        public int Id { get; set; }
        public int BoardSize { get; set; }
        public int? PlayerXId { get; set; }
        public int? PlayerOId { get; set; }
        public GameStatus Status { get; set; }
        public GameOutcome OutcomeStatus { get; set; }
        public int WinningLineLength { get; set; }
        public int? WinningPlayerId { get; set; }
    }
}