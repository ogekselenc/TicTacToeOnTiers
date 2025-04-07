namespace tictactoe.data.Entities
{
    public class Move
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public DateTime CreatedAt { get; set; } // Added CreatedAt property
    }
}
