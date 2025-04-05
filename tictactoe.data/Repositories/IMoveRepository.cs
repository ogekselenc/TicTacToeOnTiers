using System;
using System.Threading.Tasks;
using tictactoe.data.Entities;

namespace tictactoe.data.Repositories
{
    public interface IMoveRepository
    {
        Task<bool> AddMove(Move move);
        Task<bool> ValidateMove(int gameId, int PlayerId, int Row, int Column);
    }
}
