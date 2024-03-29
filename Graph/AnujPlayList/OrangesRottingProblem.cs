namespace Graph.AnujPlayList
{
    internal class OrangesRottingProblem
    {

        public int OrangesRotting(int[][] grid)
        {
            Queue<(int,int)> queue = new Queue<(int, int)>();
            int time = 0;
            int fresh = 0;
            int m = grid.Length;
            int n = grid[0].Length;
            for (int row = 0; row < m; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (grid[row][col] == 1)
                        fresh++;
                    if (grid[row][col] == 2)
                        queue.Enqueue((row, col));

                }
            }
            int[][] directions = new int[][]
            {
                new int[] { 0, 1 },
                new int[] { 0, -1 },
                new int[] { 1, 0 },
                new int[] { -1, 0 },

            };
            while (queue.Any() && fresh > 0)
            {
                int count = queue.Count;
                for (int i = 0; i < count; i++)
                {
                    var cord = queue.Dequeue();
                    int r = cord.Item1;
                    int c = cord.Item2;
                    // now check the 4 direction
                    foreach (int[] direction in directions)
                    {
                        int row = r + direction[0];
                        int col = c + direction[1];
                        if(row < 0 || col < 0 
                            || row >= m | col >= n 
                            || grid[row][col] != 1)
                        {
                            continue;
                        }
                        grid[row][col] = 2;
                        queue.Enqueue((row, col));
                        fresh--;
                    }       
                }
                time++;  
            }
            return fresh == 0 ? time : -1;
        }
    }
}
