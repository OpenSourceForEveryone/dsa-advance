namespace Graph.Rivision
{
    internal class BFS
    {
        public List<int> bfsOfGraph(int V, List<int>[] adj)
        {
            //Your code here
            bool[] visited = new bool[V];
            List<int> bfs = new List<int>();
            for(int i = 0; i < V; i++)
            {
                if (!visited[i])
                {
                    BFSTraversal(adj, i, visited, bfs);
                }
            }
            return bfs;
        }

        void BFSTraversal (List<int>[] adj, int src, bool[] visited, List<int> ans)
        {
            Queue<int> queue = new Queue<int>();
            visited[src] = true;
            queue.Enqueue(src);
            while (queue.Any())
            {
                int currentNode = queue.Dequeue();
                ans.Add(currentNode);
                foreach (int neighbor in adj[currentNode])
                {
                    if (!visited[neighbor])
                    {
                        queue.Enqueue(neighbor);
                        visited[neighbor] = true;
                    }
                }
            }
        }
    }
}
