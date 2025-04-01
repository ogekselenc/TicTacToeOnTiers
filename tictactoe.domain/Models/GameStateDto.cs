namespace tictactoe.domain.Models
{
    public class GameStateDto
    {
        public Guid GameId { get; set; }
        public string? CurrentState { get; set; }
        public string? PlayerTurn { get; set; }
    }
}