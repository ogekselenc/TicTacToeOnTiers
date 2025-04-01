using tictactoe.data.Entities;

public class Game
{
    public int Id { get; set; }
    public int BoardSize { get; set; }
    public int WinningLineLength { get; set; }
    public int PlayerXId { get; set; }
    public int PlayerOId { get; set; }
    public bool IsDeleted { get; set; } = false;

    public GameStatus Status { get; set; } = GameStatus.InProgress;
    public GameOutcome OutcomeStatus { get; set; } = GameOutcome.None;
    public string? OutcomeReason { get; set; }

    public List<Move> Moves { get; set; } = new List<Move>();
}
