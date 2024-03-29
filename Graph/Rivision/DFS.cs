namespace Graph.Rivision
{
    internal class DFS
    {
        public int[] dfsOfGraph(int V, List<int>[] adj)
        {
            //Your code here
            List<int> dfs = new List<int>();
            bool[] visited = new bool[V];
            DFSTraversal(adj, 0, visited, dfs);
            return dfs.ToArray();
        }

        void DFSTraversal(List<int>[] adj, int src, bool[] visited, List<int> res)
        {
            visited[src] = true;
            res.Add(src);

            foreach (int neighbor in adj[src])
            {
                if (!visited[neighbor])
                {
                    DFSTraversal(adj, neighbor, visited, res);
                }
            }
        }
    }
}
