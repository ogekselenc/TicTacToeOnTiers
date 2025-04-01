using System;
using System.Threading.Tasks;
using tictactoe.data.Entities;

namespace tictactoe.data.Repositories
{
    public interface IGameRepository
    {
        Task<int> CreateGame(Game game);
        Task<Game> GetGameById(Game gameId);
        Task<bool> UpdateGame(Game game);
    }
}
