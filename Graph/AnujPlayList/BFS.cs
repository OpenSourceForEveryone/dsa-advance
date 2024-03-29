namespace Graph.AnujPlayList
{
    internal class BFS
    {
        /// <summary>
        /// Traverse graph in levels
        /// </summary>
        /// <param name="adjList"></param>
        /// <param name="V"></param>
        /// <returns></returns>
        public List<int> BFSTraversal(List<int>[] adjList, int V)
        {
            List<int> result = new List<int>();
            bool[] visited = new bool[V]; // 0 - v-1 vertex
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0); // we are starting from 0 Vertex
            visited[V] = true;
            while (queue.Count > 0)
            {
                int curr = queue.Dequeue();
                result.Add(curr);
                foreach (int neighbor in adjList[curr]) // O(E)
                {
                    if (!visited[neighbor])
                    {
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);

                    }
                }
            }
            return result;
        }
    }
}
