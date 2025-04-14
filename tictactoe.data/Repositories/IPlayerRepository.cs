using System.Threading.Tasks;
using tictactoe.data.Entities;

namespace tictactoe.data.Repositories
{
    public interface IPlayerRepository
    {
        Task AddAsync(Player player);
        Task<Player?> GetPlayerById(int playerId);
    }
}