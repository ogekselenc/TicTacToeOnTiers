using MediatR;
using tictactoe.data.Entities;
using tictactoe.data.Repositories;

public class MakeMoveCommand : IRequest<bool>
{
    public int GameId { get; set; }
    public int PlayerId { get; set; }
    public int Row { get; set; }
    public int Column { get; set; }
}