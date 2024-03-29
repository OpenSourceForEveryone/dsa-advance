namespace Graph.LeetcodePractice
{
    internal class SurroundedRegions
    {
        /// <summary>
        /// https://leetcode.com/problems/surrounded-regions/description/
        /// </summary>
        /// <param name="board"></param>
        public void Solve(char[][] board)
        {
            int rows = board.Length;
            int cols = board[0].Length;

            // Capture unsurrounded regions O->T
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j <  cols; j++)
                {
                    if(board[i][j] == '0' && ( i == 0 || i == rows - 1) || ( j ==0 || j == cols-1))
                    {
                        DFS((i,j), board, rows, cols );
                    }
                }
            }
            // Capture sourrounded regions O -> X

            // Capture unsurrounded regions O->T
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (board[i][j] == '0')
                    {
                        board[i][j] = 'X';
                    }
                }
            }

            // Uncapture unsurrounded regions T->0

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (board[i][j] == 'T')
                    {
                        board[i][j] = '0';
                    }
                }
            }
        }

        void DFS((int, int) cordinate, char[][] board, int r, int c)
        {
            int row = cordinate.Item1;
            int col = cordinate.Item2;

            if(row < 0 || col < 0 || row == r || col == c || board[row][col] != '0')
                return;

            board[row][col] = 'T';
            DFS((row + 1, col), board, r, c);
            DFS((row - 1, col), board, r, c);
            DFS((row, col + 1), board, r, c);
            DFS((row, col + 1), board, r, c);
        }
    }
}
