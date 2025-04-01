using MediatR;
using tictactoe.data.Entities;
using tictactoe.data.Repositories;
using tictactoe.domain.Commands;

public class MakeMoveHandler : IRequestHandler<MakeMoveCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public MakeMoveHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(MakeMoveCommand request, CancellationToken cancellationToken)
    {
        var game = await _unitOfWork.Games.GetByIdAsync(request.GameId);
        if (game == null || game.Status != GameStatus.InProgress) return false;

        var moveExists = await _unitOfWork.Moves.FindAsync(m => m.GameId == request.GameId && m.Row == request.Row && m.Column == request.Column);
        if (moveExists != null) return false;

        var move = new Move { GameId = request.GameId, PlayerId = request.PlayerId, Row = request.Row, Column = request.Column };
        await _unitOfWork.Moves.AddAsync(move);
        await _unitOfWork.SaveChangesAsync();

        return true;
    }
}