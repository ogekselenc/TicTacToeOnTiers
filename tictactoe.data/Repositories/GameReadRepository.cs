// GameRepository.cs
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using tictactoe.data.Entities;

namespace tictactoe.data.Repositories
{
    public class GameReadRepository : IGameReadRepository
    {
        private readonly AppDbContext _context;

        public GameReadRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Game?> GetByIdAsync(int gameId)
        {
            return await _context.Games
                .Include(g => g.Moves)
                .FirstOrDefaultAsync(g => g.Id == gameId);
        }
    }
}