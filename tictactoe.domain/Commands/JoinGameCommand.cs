using MediatR;
using System;

namespace tictactoe.domain.Commands
{
    public class JoinGameCommand : IRequest<bool>
    {
        public int GameId { get; set; }
        public int PlayerOId { get; set; }
    }
}
