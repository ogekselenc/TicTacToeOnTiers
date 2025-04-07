using tictactoe.domain.Commands;
using tictactoe.data.Entities;
using tictactoe.data.Enums;

namespace tictactoe.domain.Services
{

    public static class GameLogicHelper
    {
        public static string[,] ReconstructBoard(int size, IEnumerable<Move> moves, Game game)
        {
            var board = new string[size, size];
            foreach (var move in moves)
            {
                var symbol = GetPlayerSymbol(game, move.PlayerId);
                board[move.Row, move.Column] = symbol;
            }
            return board;
        }

        public static string GetPlayerSymbol(Game game, int playerId)
        {
            return game.PlayerXId == playerId ? "X" : "O";
        }

        public static bool IsValidMove(string[,] board, int row, int col)
        {
            int size = board.GetLength(0);
            return row >= 0 && col >= 0 && row < size && col < size && board[row, col] == null;
        }

        public static (string? Status, string? Reason) CheckOutcome(string[,] board, int row, int col, int winLength)
        {
            string? symbol = board[row, col];
            if (symbol == null) return (null, null);

            int[][] directions = new int[][]
            {
            new int[] {0, 1}, new int[] {1, 0}, new int[] {1, 1}, new int[] {1, -1}
            };

            foreach (var dir in directions)
            {
                int count = 1;
                count += CountDirection(board, row, col, dir[0], dir[1], symbol);
                count += CountDirection(board, row, col, -dir[0], -dir[1], symbol);
                if (count >= winLength)
                    return ("Win", $"Player {symbol} wins");
            }

            if (IsBoardFull(board))
                return ("Draw", "The board is full");

            return (null, null);
        }

        private static int CountDirection(string[,] board, int row, int col, int dRow, int dCol, string symbol)
        {
            int count = 0;
            int r = row + dRow;
            int c = col + dCol;
            while (r >= 0 && r < board.GetLength(0) && c >= 0 && c < board.GetLength(1) && board[r, c] == symbol)
            {
                count++;
                r += dRow;
                c += dCol;
            }
            return count;
        }

        private static bool IsBoardFull(string[,] board)
        {
            for (int r = 0; r < board.GetLength(0); r++)
                for (int c = 0; c < board.GetLength(1); c++)
                    if (board[r, c] == null) return false;
            return true;
        }
    }
}