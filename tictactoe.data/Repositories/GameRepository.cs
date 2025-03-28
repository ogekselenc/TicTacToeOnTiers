using tictactoe.data.Entities;

namespace tictactoe.data.Repositories
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(AppDbContext context) : base(context) { }
    }
}
