using tictactoe.data.Entities;

namespace tictactoe.data.Repositories;

public interface IUnitOfWork
{
    IRepository<Player> Players { get; }
    IRepository<Game> Games { get; }
    IRepository<Move> Moves { get; }
    Task SaveChangesAsync();
}
