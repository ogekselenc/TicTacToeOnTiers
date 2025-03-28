using tictactoe.data.Entities;

namespace tictactoe.data.Repositories
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(AppDbContext context) : base(context) { }
    }
}
