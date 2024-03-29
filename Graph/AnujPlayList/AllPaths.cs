namespace Graph.AnujPlayList
{
    internal class AllPaths
    {
        // all paths from source to destination
        /// <summary>
        /// https://leetcode.com/problems/all-paths-from-source-to-target/
        /// </summary>
        /// <param name="graph"></param>
        /// <returns></returns>
        public IList<IList<int>> AllPathsSourceTarget(int[][] graph)
        {

            IList<IList<int>> paths = new List<IList<int>>();   
            DFS(graph, new List<int>() { 0 }, paths, 0, graph.Length - 1);
            return paths;

        }

        private void DFS(int[][] graph, List<int> path,
            IList<IList<int>> paths, int curr, int target)
        {
            if(curr == target)
            {
                paths.Add(new List<int>(path));
                return;
            }
            foreach (int neighbor in graph[curr])
            {
                path.Add(neighbor);
                DFS(graph, path, paths, neighbor, target);    
                path.Remove(neighbor); // back tracking step
            }
        }
    }
}
