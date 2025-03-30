using System.Linq;
using tictactoe.data.Entities;

namespace tictactoe.domain.Services
{
    public class GameLogicService
    {
        public static bool CheckWin(Game game, int winLength)
        {
            var board = GenerateBoard(game);
            return CheckRows(board, winLength) || CheckColumns(board, winLength) || CheckDiagonals(board, winLength);
        }

        private static char[,] GenerateBoard(Game game)
        {
            var board = new char[game.BoardSize, game.BoardSize];
            foreach (var move in game.Moves)
            {
                board[move.Row, move.Column] = move.PlayerId == game.PlayerXId ? 'X' : 'O';
            }
            return board;
        }

        private static bool CheckRows(char[,] board, int winLength)
        {
            int size = board.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j <= size - winLength; j++)
                {
                    if (IsWinningLine(board, i, j, 0, 1, winLength)) return true;
                }
            }
            return false;
        }

        private static bool CheckColumns(char[,] board, int winLength)
        {
            int size = board.GetLength(0);
            for (int i = 0; i <= size - winLength; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (IsWinningLine(board, i, j, 1, 0, winLength)) return true;
                }
            }
            return false;
        }

        private static bool CheckDiagonals(char[,] board, int winLength)
        {
            int size = board.GetLength(0);
            for (int i = 0; i <= size - winLength; i++)
            {
                for (int j = 0; j <= size - winLength; j++)
                {
                    if (IsWinningLine(board, i, j, 1, 1, winLength) || IsWinningLine(board, i + winLength - 1, j, -1, 1, winLength))
                        return true;
                }
            }
            return false;
        }

        private static bool IsWinningLine(char[,] board, int startX, int startY, int stepX, int stepY, int winLength)
        {
            char first = board[startX, startY];
            if (first == '\0') return false;

            for (int k = 1; k < winLength; k++)
            {
                if (board[startX + k * stepX, startY + k * stepY] != first) return false;
            }
            return true;
        }
    }
}
