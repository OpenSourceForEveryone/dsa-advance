
namespace Graph.AnujPlayList
{
    internal class NumberOfIsland
    {
        /// <summary>
        /// https://leetcode.com/problems/number-of-islands/description/
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int NumIslands(char[][] grid)
        {
            int rows = grid.Length;
            int cols = grid[0].Length;
            if(rows == 0)
                return 0;

            int numberOfIsland = 0;
            HashSet<(int, int)> visited = new HashSet<(int, int)> ();
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if(grid[row][col] == '1' && !visited.Contains((row, col)))
                    {
                        numberOfIsland++;
                        BFS((row, col), grid, visited);
                    }           
                }
            }

            return numberOfIsland;
        }

        private void BFS((int, int) cell, char[][] grid, HashSet<(int, int)> visited)
        {
            Queue<(int, int)> queue = new Queue<(int, int)>();
            int[][] directions = new int[][]
            {
                new int[] { 0 , 1  },
                new int[] { 0 , -1 },
                new int[] { 1 , 0  },
                new int[] { -1 , 0 }
            };
            queue.Enqueue(cell);
            visited.Add(cell);
            while (queue.Any())
            {
                (int, int) curr = queue.Dequeue();
                int r = curr.Item1;
                int c = curr.Item2;
                foreach (int[] direction in directions)
                {
                    int row = r + direction[0];
                    int col = c + direction[1];
                    if (row < grid.Length && col < grid[0].Length && row >= 0 && col >= 0 &&
                         grid[row][col] == '1' && !visited.Contains((row, col)))
                    {
                        queue.Enqueue((row, col));
                        visited.Add((row, col));
                    }
                }
            }
        }
    }
}
