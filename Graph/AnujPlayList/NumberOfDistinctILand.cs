namespace Graph.AnujPlayList
{
    internal class NumberOfDistinctILand
    {
        /// <summary>
        /// https://www.geeksforgeeks.org/problems/number-of-distinct-islands/1
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        int CountDistinctIslands(int[][] grid)
        {
            // Your Code here
            int m = grid.Length;
            int n = grid[0].Length;
            if(m == 0)
                return 0;
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            HashSet<List<string>> set = new HashSet<List<string>>();
            for (int row = 0; row < m; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if(!visited.Contains((row, col)) && grid[row][col] == 1)
                    {
                        // we need to pass the base from here
                        List<string> isLand = new List<string>();
                        BFS(grid, visited, row, col, isLand);
                        set.Add(isLand);

                    }
                }
            }
            return set.Count;
        }
        void BFS(int[][] grid, HashSet<(int, int)> visited, 
            int baseRow, int baseCol, List<string> isLand)
        {
            visited.Add((baseRow, baseCol));
            Queue<(int, int)> queue = new Queue<(int, int)>();
            queue.Enqueue((baseRow, baseCol));

            // create direction

            int[][] directions = new int[][]
            {
                new int[] {0, 1},
                new int[] {0, -1},
                new int[] {1, 0},
                new int[] {-1, 0},
            };

            while (queue.Any())
            {
                (int, int) cell = queue.Dequeue();
                int r = cell.Item1;
                int c = cell.Item2;
                isLand.Add($"{r - baseRow}-{c - baseCol}");
                foreach (int[] dir in directions)
                {
                    int row = r + dir[0];
                    int col = c + dir[1];

                    if(row >= 0 && row < grid.Length && col >=0 && col < grid[0].Length 
                        && !visited.Contains((row, col)) && grid[row][col] == 1)
                    {
                        visited.Add((row, col));
                        queue.Enqueue((row, col));
                    }
                }
            }     
        }
    }
}
