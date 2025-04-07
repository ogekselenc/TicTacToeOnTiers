using MediatR;
using System;

namespace tictactoe.domain.Commands
{
public class MakeMoveResponse
{
    public int Id { get; set; }
    public int GameId { get; set; }
    public int PlayerId { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }
    public string? OutcomeStatus { get; set; }
    public string? OutcomeReason { get; set; }
}
}