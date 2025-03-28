using tictactoe.data.Entities;

namespace tictactoe.data.Repositories
{
    public class MoveRepository : Repository<Move>, IMoveRepository
    {
        public MoveRepository(AppDbContext context) : base(context) { }
    }
}
