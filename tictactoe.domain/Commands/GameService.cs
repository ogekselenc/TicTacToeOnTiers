
using Microsoft.EntityFrameworkCore;
using tictactoe.data;
using tictactoe.data.Entities;

public class GameService
{
    public AppDbContext Context { get; }

    public GameService(AppDbContext context)
    {
        Context = context;
        // Constructor logic here
    }

    public async Task<Game> GetGameById(int gameId)
    {
        var game = await Context.Games
                .Where(x => x.Id == gameId)
                .FirstOrDefaultAsync();

        return game;
    }

    public async Task<bool> Delete(int gameId)
    {
        var game = await Context.Games
                .Where(x => x.Id == gameId)
                .FirstOrDefaultAsync();

        Context.Games.Remove(game);
        await Context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Add(Game game)
    {
        try
        {
            Context.Games.Add(game);
            await Context.SaveChangesAsync();

            return true;
        } catch (Exception ex)
        {
            // Handle exception
            throw;
        }
    }


}