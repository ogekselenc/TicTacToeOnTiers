using MediatR;
using System;

namespace tictactoe.domain.Commands
{
    public class MakeMoveRequest : IRequest<MakeMoveResponse>
    {
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
    }
}
