namespace tictactoe.data.Entities;

public class Game
{
    public int Id { get; set; }
    public int PlayerXId { get; set; }
    public int PlayerOId { get; set; }
    public string Status { get; set; } = "InProgress";
    public int? WinnerId { get; set; }
    public int BoardSize { get; set; } = 3;
    public bool IsDeleted { get; set; } = false;

    public ICollection<Move> Moves { get; set; } = new List<Move>();
}
