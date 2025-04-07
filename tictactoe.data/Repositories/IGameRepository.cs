using System;
using System.Threading.Tasks;
using tictactoe.data.Entities;

namespace tictactoe.data.Repositories
{
    public interface IGameRepository
    {
        Task<int> CreateGame(Game game);
        Task<bool> JoinGame(int gameId, int playerOId);
        Task<Game?> GetGameById(int gameId);
        Task<bool> UpdateGame(Game game);
        
    }
}
