using MediatR;
using System.Threading;
using System.Threading.Tasks;
using tictactoe.data.Entities;
using tictactoe.data.Repositories;

namespace tictactoe.domain.Commands
{
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
            if (game == null)
            {
                Console.WriteLine("Game not found!");
                return false;
            }

            if (game.PlayerXId != request.PlayerId && game.PlayerOId != request.PlayerId)
            {
                Console.WriteLine($"Player {request.PlayerId} is not part of game {request.GameId}.");
                return false;
            }

            var existingMove = await _unitOfWork.Moves.FindAsync(m => m.GameId == request.GameId && m.Row == request.Row && m.Column == request.Column);
            if (existingMove == null)
            {
                Console.WriteLine($"Move already exists at Row: {request.Row}, Column: {request.Column} in Game {request.GameId}.");
                return false;
            }

            var move = new Move
            {
                GameId = request.GameId,
                PlayerId = request.PlayerId,
                Row = request.Row,
                Column = request.Column
            };

            await _unitOfWork.Moves.AddAsync(move);
            await _unitOfWork.SaveChangesAsync();
            Console.WriteLine($"Move made: Player {request.PlayerId} -> Game {request.GameId}, Row {request.Row}, Column {request.Column}");
            return true;
        }

    }
}
