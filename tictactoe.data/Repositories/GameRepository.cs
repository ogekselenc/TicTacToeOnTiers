using tictactoe.data.Entities;
using tictactoe.data.Enums;

namespace tictactoe.data.Repositories
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(AppDbContext context) : base(context) { }

        public async Task<int> CreateGame(Game game)
        {
            game.Status = GameStatus.InProgress;
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game.Id;
        }

        public async Task<bool> JoinGame(int gameId, int playerOId)
        {
            var game = await _context.Games.FindAsync(gameId);
            if (game == null || game.Status != GameStatus.WaitingForPlayer)
                return false;

            game.PlayerOId = playerOId;
            game.Status = GameStatus.InProgress;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<Game?> GetGameById(Game game)
        {
            return await _context.Games.FindAsync(game.Id);
        }
    
        public async Task<bool> UpdateGame(Game game)
        {
            var existingGame = await _context.Games.FindAsync(game.Id);
            if (existingGame == null)
                return false;
    
            _context.Entry(existingGame).CurrentValues.SetValues(game);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}


