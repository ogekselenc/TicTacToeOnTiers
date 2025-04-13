// IPlayerReadRepository.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using tictactoe.data.Entities;

namespace tictactoe.data.Repositories
{
    public interface IPlayerReadRepository
    {
        Task<List<Player>> GetAllPlayersAsync();
    }
}