using tictactoe.data.Entities;
using tictactoe.data.Enums;

namespace tictactoe.data.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _context;

        public GameRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateGame(Game game)
        {
            // Set initial status based on PlayerOId presence
            game.Status = game.PlayerOId.HasValue
                ? GameStatus.InProgress
                : GameStatus.WaitingForPlayer;
            _context.Games.Add(game);
        }
        public async Task<bool> JoinGame(int gameId, int playerOId)
        {
            var game = await _context.Games.FindAsync(gameId);
            if (game == null || game.Status != GameStatus.WaitingForPlayer)
                return false;

            game.PlayerOId = playerOId;
            game.Status = GameStatus.InProgress;
            return true;
        }
        public async Task<Game?> GetGameById(int gameId)
        {
            return await _context.Games.FindAsync(gameId);
        }
    
        public async Task<bool> UpdateGame(Game game)
        {
            var existingGame = await _context.Games.FindAsync(game.Id);
            if (existingGame == null)
                return false;
            _context.Entry(existingGame).CurrentValues.SetValues(game);
            return true;
        }
    }
}


