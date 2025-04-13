// PlayerReadRepository.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using tictactoe.data.Entities;

namespace tictactoe.data.Repositories
{
    public class PlayerReadRepository : IPlayerReadRepository
    {
        private readonly AppDbContext _context;

        public PlayerReadRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Player>> GetAllPlayersAsync()
        {
            return await _context.Players
                .AsNoTracking() // Samo čitanje podataka
                .ToListAsync();
        }
    }
}