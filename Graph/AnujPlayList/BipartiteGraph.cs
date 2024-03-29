    namespace Graph.AnujPlayList
{
    internal class BipartiteGraph
    {
        public bool IsBipartite(int V, List<int>[] adj)
        {
            int[] colors = new int[V];
            for (int i = 0; i < V; i++)
                colors[i] = -1;

            for (int i = 0; i < V; i++)
            {
                if (colors[i] == -1)
                {
                    if(!CheckBipartieBFS(i, colors, adj))
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// BFS || CheckBipartieBFS
        /// </summary>
        /// <param name="start"></param>
        /// <param name="V"></param>
        /// <param name="colors"></param>
        /// <param name="adj"></param>
        /// <returns></returns>
        private bool CheckBipartieBFS(int start, int[] colors, List<int>[] adj)
        {
            Queue<int> queue = new Queue<int>();
            colors[start] = 0;
            queue.Enqueue(start);

            while(queue.Count > 0)
            {
                int currNode = queue.Dequeue();
                foreach (int neigbour in adj[currNode])
                {
                    if (colors[neigbour] == -1)
                    {
                        colors[neigbour] = 1 - colors[currNode];
                        queue.Enqueue(neigbour);
                    }

                    else if(colors[neigbour] == colors[currNode])
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// DFS || CheckBipartieDFS
        /// </summary>
        /// <param name="source"></param>
        /// <param name="color"></param>
        /// <param name="colors"></param>
        /// <param name="adj"></param>
        /// <returns></returns>
        private bool CheckBipartieDFS(int source, int color,  int[] colors, List<int>[] adj)
        {
            colors[source] = color;
            foreach (int neighbor in adj[source])
            {
                if (!CheckBipartieDFS(neighbor, 1 - color, colors, adj))
                    return false;

                else if (colors[neighbor] == color)
                      return false;
            }
            return true;
        }
    }
}
