namespace Graph.LeetcodePractice
{
    internal class BFSTraversal
    {
        public static bool BFS(int vertexCount, List<int>[] adj, int src, int destination, int[] pred, int[] dist)
        {
            bool[] visited = new bool[vertexCount];
            for (int vertex = 0; vertex < vertexCount; vertex++)
            {
                dist[vertex] = int.MaxValue; // distance is set to infinity
                pred[vertex] = -1; // predecessor of vertex is set to -1 as our vertex starts from 0
            }

            Queue<int> queue = new Queue<int>();

            queue.Enqueue(src);    
            visited[src] = true;
            dist[src] = 0;

            while(queue.Count > 0)
            {
                int currentVertex = queue.Dequeue();

                foreach (int vertex in adj[currentVertex])
                {
                    if (!visited[vertex])
                    {
                        visited[vertex] = true;
                        dist[vertex] = dist[currentVertex] + 1;
                        pred[vertex] = currentVertex;
                    }

                    if (vertex == destination)
                        return true;
                }  
            }

            return false;
        }
    }
}
