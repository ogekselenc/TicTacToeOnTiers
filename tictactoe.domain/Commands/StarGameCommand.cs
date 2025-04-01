using MediatR;
using System;

namespace tictactoe.domain.Commands
{
    public class StartGameCommand : IRequest<Guid>
    {
        public Guid PlayerXId { get; set; }
        public Guid PlayerOId { get; set; }
        public int BoardSize { get; set; }
        public int WinningLineLength { get; set; }
    }
}
