using MediatR;
using System;
using tictactoe.data.Enums;

namespace tictactoe.domain.Commands
{
    public class MakeMoveResponse
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public GameStatus Status { get; set; }
        public GameOutcome OutcomeStatus { get; set; }
        public string? WinningPlayer { get; set; } // "X" or "O" or null
    }
}