using tictactoe.data.Entities;

namespace tictactoe.data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public IPlayerRepository Players { get; }
    public IGameRepository Games { get; }
    public IMoveRepository Moves { get; }

    public UnitOfWork(AppDbContext context, IGameRepository gameRepository, IMoveRepository moveRepository, IPlayerRepository playerRepository)
    {
        _context = context;
        Players = playerRepository;
        Games = gameRepository;
        Moves = moveRepository;
    }

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}
