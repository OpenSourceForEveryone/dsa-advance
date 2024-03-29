namespace Graph.AnujPlayList
{
    internal class DFS
    {
        public List<int> DFSTraversal(List<int>[] adjList, int V)
        {
            List<int> result = new List<int>();
            bool[] visited = new bool[V]; // 0 - v-1 vertex
            DFSTraversal(adjList, 0, visited, result);
            return result;
        }

        private void DFSTraversal(List<int>[] adjList, int src, bool[] visited, List<int> result)
        {
            visited[src] = true;
            result.Add(src);
            foreach (int neighbor in adjList[src])
            {
                if (!visited[neighbor])
                {
                    DFSTraversal(adjList, neighbor, visited, result);
                }  
            }
        }
    }
}
