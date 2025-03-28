namespace tictactoe.data.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGameRepository Games { get; }
        IPlayerRepository Players { get; }
        IMoveRepository Moves { get; }
        Task<int> SaveChangesAsync();
    }
}
