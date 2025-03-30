using MediatR;

public class SoftDeleteGameCommand : IRequest<bool>
{
    public int GameId { get; }

    public SoftDeleteGameCommand(int gameId)
    {
        GameId = gameId;
    }
}
