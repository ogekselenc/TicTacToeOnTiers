using tictactoe.data.Entities;

namespace tictactoe.data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IRepository<Player> Players { get; }
    public IRepository<Game> Games { get; }
    public IRepository<Move> Moves { get; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Players = new Repository<Player>(context);
        Games = new Repository<Game>(context);
        Moves = new Repository<Move>(context);
    }

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}
