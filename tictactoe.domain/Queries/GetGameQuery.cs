using MediatR;
using tictactoe.data.Entities;
using tictactoe.data.Repositories;

public class GetGameQuery : IRequest<Game>
{
    public int GameId { get; set; }
}

public class GetGameHandler : IRequestHandler<GetGameQuery, Game>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetGameHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Game> Handle(GetGameQuery request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.Games.GetByIdAsync(request.GameId);
    }
}
