// IGameRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using tictactoe.data.Entities;

namespace tictactoe.data.Repositories
{
    public interface IGameReadRepository
    {
        Task<Game?> GetByIdAsync(int gameId); // Updated method name and return type
    }
}