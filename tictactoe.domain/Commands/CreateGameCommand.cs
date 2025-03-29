using MediatR;
using tictactoe.data.Entities;
using tictactoe.data.Repositories;

public class CreateGameCommand : IRequest<int>
{
    public int PlayerXId { get; set; }
    public int PlayerOId { get; set; }
}