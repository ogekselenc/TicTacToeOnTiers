using tictactoe.data.Entities;
using tictactoe.data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace tictactoe.data.Repositories
{
    public class MoveRepository : Repository<Move>, IMoveRepository
    {
        public MoveRepository(AppDbContext context) : base(context) { }

        public async Task<bool> AddMove(Move move)
        {
            // Implementation for adding a move
            await _context.Set<Move>().AddAsync(move);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> ValidateMove(int gameId, int x, int y)
        {
            // Implementation for validating a move
            return !await _context.Set<Move>().AnyAsync(m => m.GameId == gameId && m.PlayerId == x && m.PlayerId == y);
        }
    }
}