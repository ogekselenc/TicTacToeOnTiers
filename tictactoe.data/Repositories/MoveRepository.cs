using tictactoe.data.Entities;
using Microsoft.EntityFrameworkCore;

namespace tictactoe.data.Repositories
{
    public class MoveRepository : IMoveRepository
    {
        private readonly AppDbContext _context;
        public MoveRepository(AppDbContext context) 
        {
            _context = context;
        }
        public async Task<bool> AddMove(Move move)
        {
            // Implementation for adding a move
            await _context.Set<Move>().AddAsync(move);
            return true;
        }

        public async Task<bool> ValidateMove(int gameId, int PlayerId, int Row, int Column)
        {
            // Implementation for validating a move
            return !await _context.Set<Move>().AnyAsync(m => m.GameId == gameId && m.PlayerId == Row && m.PlayerId == Column);
        }

        public async Task<IEnumerable<Move>> GetByGameIdAsync(int gameId)
        {
            return await _context.Set<Move>().Where(m => m.GameId == gameId).ToListAsync();
        }
        // This method counts the number of moves for a specific game
        public async Task<int> GetMoveCountForGame(int gameId)
        {
            return await _context.Set<Move>().CountAsync(m => m.GameId == gameId);
        }
    }
}