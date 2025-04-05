using tictactoe.data.Entities;

public class Game
{
    public int Id { get; set; }
    public int BoardSize { get; set; }
    public int PlayerXId { get; set; }
    public int PlayerOId { get; set; }
    public GameStatus Status { get; set; } = GameStatus.InProgress;
    public bool IsDeleted { get; set; } = false;
    public string? OutcomeReason { get; set; }
    public GameOutcome OutcomeStatus { get; set; } = GameOutcome.None;

    public int WinningLineLength { get; set; }

    public List<Move> Moves { get; set; } = new List<Move>();
}
