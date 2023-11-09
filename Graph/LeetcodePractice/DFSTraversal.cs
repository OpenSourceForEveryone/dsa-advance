namespace Graph.LeetcodePractice
{
    internal class DFSTraversal
    {
        public static List<int> DFS(int v, List<int>[] adjList)
        {
            List<int> dfsPath = new List<int>();
            bool[] visited = new bool[v];
            for (int vertex = 0; vertex < v; vertex++)
            {
                if (!visited[vertex])
                {
                    DFS(vertex, adjList, visited, dfsPath);
                }
            }
            return dfsPath;
        }

        private static void DFS(int source, List<int>[] adjList, bool[] visited, List<int> dfsPath)
        {
            visited[source] = true;
            dfsPath.Add(source);
            foreach(var neighbor in adjList[source])
            {
                if (!visited[neighbor])
                {
                    DFS(neighbor, adjList, visited, dfsPath);
                }
            }
        }
    }
}
