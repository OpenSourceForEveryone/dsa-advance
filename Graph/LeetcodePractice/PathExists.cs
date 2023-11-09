namespace Graph.LeetcodePractice
{
    internal class PathExists
    {
        /// <summary>
        /// https://leetcode.com/problems/find-if-path-exists-in-graph/description/
        /// Find if path exists in graph
        /// </summary>
        /// <param name="n"></param>
        /// <param name="edges"></param>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public bool ValidPath(int n, int[][] edges, int source, int destination)
        {
            List<int>[] adjList = new List<int>[n];

            for (int vertex = 0; vertex < n; vertex++)
                adjList[vertex] = new List<int>();

            foreach (int[] edge in edges)
            {
                // Bi-Directional graph that's why adding in both direction
                adjList[edge[0]].Add(edge[1]);
                adjList[edge[1]].Add(edge[0]);
            }

            bool[] visited = new bool[n];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                int vertex = queue.Dequeue();
                visited[vertex] = true;

                if (vertex == destination)
                    return true;

                foreach (int v in adjList[vertex])
                {
                    if (!visited[v])
                        queue.Enqueue(v);
                }
            }
            return false;

        }
    }
}
