namespace Graph.AnujPlayList
{
    internal class DetectCycle
    {
        public bool IsCycle(int V, List<int>[] adj)
        {
            bool[] visited = new bool[V];
            for (int i = 0; i < V; i++)
            {
                if (!visited[i])
                {
                   if (DetectBFS(i, adj, visited))
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// BFS || UnDirected graph
        /// </summary>
        /// <param name="src"></param>
        /// <param name="adj"></param>
        /// <param name="visited"></param>
        /// <returns></returns>
        private bool DetectBFS(int src, List<int>[] adj, bool[] visited)
        {
            Queue<KeyValuePair<int, int>> queue = new Queue<KeyValuePair<int, int>>();
            visited[src] = true;
            queue.Enqueue(new KeyValuePair<int, int>(src, -1));
            while (queue.Any())
            {
                KeyValuePair<int, int> curr = queue.Dequeue();
                int node = curr.Key;
                int parent = curr.Value;
                foreach (int neighbor in adj[node])
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        queue.Enqueue(new KeyValuePair<int, int>(neighbor, node));
                    }
                    else if (neighbor != parent)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        ///  DFS || UnDirected graph
        /// </summary>
        /// <param name="src"></param>
        /// <param name="parent"></param>
        /// <param name="adj"></param>
        /// <param name="visited"></param>
        /// <returns></returns>
        private bool DetectDFS(int src, int parent, List<int>[] adj, bool[] visited)
        {
            visited[src] = true;
            foreach (var neighbor in adj[src])
            {
                if (!visited[neighbor])
                {
                    if(DetectDFS(neighbor, src, adj, visited))
                    {
                        return true;
                    }
                }
                else if(neighbor != parent)
                {
                    return true;
                }

            }
            return false;
        }

        public bool DetectCycleInDirectedGraph(List<int>[] adj, int V)
        {
            bool[] visited = new bool[V];
            bool[] pathVisited = new bool[V];
            for (int i = 0; i < V; i++)
            {
                if (!visited[i])
                {
                    if(!DFSDirected(adj, i, visited, pathVisited))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool DFSDirected(List<int>[] adj, int src, bool[] visited, bool[] pathVisited)
        {
            visited[src] = true;
            pathVisited[src] = true;
            foreach (int neighbhour in adj[src ])
            {
                if (!visited[neighbhour])
                {
                    if (DFSDirected(adj, neighbhour, visited, pathVisited))
                    {
                        return true;
                    }
                } else if (pathVisited[neighbhour])
                    return true;
            }
            pathVisited[src] = false;
            return false;
        }
    }
}
