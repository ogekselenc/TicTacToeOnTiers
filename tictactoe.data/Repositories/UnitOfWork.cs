namespace tictactoe.data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public IGameRepository Games { get; }
        public IPlayerRepository Players { get; }
        public IMoveRepository Moves { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Games = new GameRepository(context);
            Players = new PlayerRepository(context);
            Moves = new MoveRepository(context);
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
