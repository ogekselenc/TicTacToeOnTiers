using System.Threading;
using System.Threading.Tasks;
using MediatR;
using tictactoe.data;

public class SoftDeleteGameCommand : IRequest<bool>
{
    public int GameId { get; }

    public SoftDeleteGameCommand(int gameId)
    {
        GameId = gameId;
    }
}

public class SoftDeleteGameHandler : IRequestHandler<SoftDeleteGameCommand, bool>
{
    private readonly AppDbContext _dbContext;

    public SoftDeleteGameHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> Handle(SoftDeleteGameCommand request, CancellationToken cancellationToken)
    {
        // Find the game by ID
        var game = await _dbContext.Games.FindAsync(new object[] { request.GameId }, cancellationToken);

        if (game == null)
        {
            return false; // Game not found
        }

        // Mark the game as soft-deleted
        game.IsDeleted = true;

        // Save changes to the database
        await _dbContext.SaveChangesAsync(cancellationToken);

        return true; // Successfully soft-deleted
    }
}
