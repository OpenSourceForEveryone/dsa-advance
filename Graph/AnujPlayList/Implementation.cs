namespace Graph.AnujPlayList
{
    internal class Graph
    {
        int edge;
        int vertex;
        int[,] adjMatrix; // Adjecency Matrix;
        List<List<int>> adjList;

        public Graph(int edge, int vertex)
        {
            this.edge = edge;
            this.vertex = vertex;
            adjMatrix = new int[edge, vertex];
            adjList = new List<List<int>>();
            for (int ve = 0; ve <= vertex; ve++)
            {
                adjList.Add(new List<int>());
            }
        }
        public void AddEdge_AdjMat(int soruce, int dest)
        { 
            adjMatrix[soruce, dest] = 1;
            adjMatrix[dest, soruce] = 1;
        }

        public void AddEdge_AdList(int soruce, int dest)
        {
            adjList[soruce].Add(dest);
            adjList[dest].Add(soruce);
        }

        public bool BSF(List<List<int>> adj, int src, int dest, int v, int[] pred, int[] dist)
        {
            bool[] visited = new bool[v];
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < v; i++)
            {
                dist[i] = int.MaxValue;
                pred[i] = int.MinValue;
            }

            visited[src] = true;
            dist[src] = 0;
            queue.Enqueue(src);

            while (queue.Any())
            {
                int curr = queue.Dequeue();
                foreach (int vertex in adj[curr])
                {
                    if (!visited[vertex])
                    {
                        visited[vertex] = true;
                        dist[vertex] = dist[curr] + 1;
                        pred[vertex] = vertex;
                        queue.Enqueue(vertex);
                    }

                    if (vertex == dest)
                        return true;
                }
            }

            return false;
        }

        public List<int> DFS(int v, List<List<int>> adj)
        {
            bool[] visited = new bool[v];
            List<int> ans = new List<int>();
            for (int i = 0; i < v; i++)
            {
                if (!visited[i])
                {
                    DFS(i, adj, visited, ans);
                }
            }
            return ans;
        }

        private void DFS(int v, List<List<int>> adj, bool[] visited, List<int> ans)
        {
            visited[v] = true;
            ans.Add(v);
            foreach (var neighbor in adj[v])
            {
                if (!visited[neighbor])
                {
                    DFS(neighbor, adj, visited, ans);
                }
            }
        }  
    }
}
