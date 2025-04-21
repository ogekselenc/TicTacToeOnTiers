using tictactoe.data.Entities;

namespace tictactoe.data.Repositories;

public interface IUnitOfWork
{
    Task SaveChangesAsync();
}

