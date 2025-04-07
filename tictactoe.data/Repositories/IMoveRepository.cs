using System;
using System.Threading.Tasks;
using tictactoe.data.Entities;

namespace tictactoe.data.Repositories
{
    public interface IMoveRepository
    {
        Task<bool> AddMove(Move move);
        Task<bool> ValidateMove(int gameId, int PlayerId, int Row, int Column);
        Task<IEnumerable<Move>> GetByGameIdAsync(int gameId); // Already implemented
        Task<int> GetMoveCountForGame(int gameId);
    }
}
