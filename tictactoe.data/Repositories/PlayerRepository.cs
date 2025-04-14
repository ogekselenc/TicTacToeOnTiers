// PlayerRepository.cs
using Microsoft.EntityFrameworkCore;
using tictactoe.data.Entities;

namespace tictactoe.data.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly AppDbContext _context;

        public PlayerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Player player)
        {
            await _context.Players.AddAsync(player);
        }
        public async Task<Player?> GetPlayerById(int playerId)
        {
            return await _context.Players
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == playerId);
        }
    }
}