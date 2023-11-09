namespace Graph.LeetcodePractice
{
    internal class TownJudge
    {
        /// <summary>
        /// https://leetcode.com/problems/find-the-town-judge/
        /// </summary>
        /// <param name="n"></param>
        /// <param name="trust"></param>
        /// <returns></returns>
        public int FindJudge(int n, int[][] trust)
        {
            if (n == 1)
            {
                // if there is only one vertex and trust is zero
                if (trust.Length == 0)
                {
                    return 1;
                }
                return trust[0][1];
            }

            if (trust.Length == 0)
            {
                return -1;
            }

            int[] indegrees = new int[n + 1];
            List<int>[] adjList = new List<int>[n + 1];

            for (int person = 1; person <= n; person++)
                adjList[person] = new List<int>();

            foreach (int[] rel in trust)
            {
                adjList[rel[0]].Add(rel[1]);
                indegrees[rel[1]] += 1; // calculating indegree of each vertex
            }

            for (int vertex = 1; vertex <= n; vertex++)
            {
                // all vertext except judge should trust the vertex, therefore to be judge vertex, in degree should be n-1
                // judge should not have any trust vertex
                if (indegrees[vertex] == n - 1 && adjList[vertex].Count == 0)
                {
                    return vertex;
                }
            }
            return -1;
        }
    }
}
