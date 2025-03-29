using MediatR;

namespace tictactoe.domain.Commands
{
    public class CreateGameCommand : IRequest<int>
    {
        public int BoardSize { get; set; }
        public int WinningLineLength { get; set; }

        public CreateGameCommand(int boardSize, int winningLineLength)
        {
            BoardSize = boardSize;
            WinningLineLength = winningLineLength;
        }
    }
}
