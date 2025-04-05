using MediatR;
using System;

namespace tictactoe.domain.Commands
{
    public class StartGameCommand : IRequest<int>
    {
        public int PlayerXId { get; set; }
        public int PlayerOId { get; set; }
        public int BoardSize { get; set; }
        public int WinningLineLength { get; set; }
    }
}
