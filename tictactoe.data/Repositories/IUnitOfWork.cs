using tictactoe.data.Entities;

namespace tictactoe.data.Repositories;

public interface IUnitOfWork
{
    IPlayerRepository Players { get; }
    IGameRepository Games { get; }
    IMoveRepository Moves { get; }
    Task SaveChangesAsync();
}
