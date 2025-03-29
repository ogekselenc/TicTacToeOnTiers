using MediatR;
using System.Threading;
using System.Threading.Tasks;
using tictactoe.data.Entities;
using tictactoe.data.Repositories;

namespace tictactoe.domain.Commands
{
    public class JoinGameHandler : IRequestHandler<JoinGameCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public JoinGameHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(JoinGameCommand request, CancellationToken cancellationToken)
        {
            var game = await _unitOfWork.Games.GetByIdAsync(request.GameId);
            var player = await _unitOfWork.Players.GetByIdAsync(request.PlayerId);

            if (game == null || player == null) return false; // Ne postoji igra ili igrač

            // Dodaj igrača kao X ako nema igrača X, inače kao O
            if (game.PlayerXId == null)
                game.PlayerXId = request.PlayerId;
            else if (game.PlayerOId == null)
                game.PlayerOId = request.PlayerId;
            else
                return false; // Igra je već popunjena

            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
