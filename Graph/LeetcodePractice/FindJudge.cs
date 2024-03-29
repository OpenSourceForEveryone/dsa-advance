

namespace Graph.LeetcodePractice
{
    internal class FindJudge
    {
        public int FindJudge1(int n, int[][] trusts)
        {
            HashSet<int>[] trustList = new HashSet<int>[n + 1];
            foreach (int[] trust in trusts)
            {
                if (trustList[trust[0]] == null)
                {
                    trustList[trust[0]] = new HashSet<int>();
                }

                trustList[trust[0]].Add(trust[1]);
            }
            // find a cadidate for town judge
            int judge = -1;
            for (int i = 1; i <=n ; i++)
            {
                if (trustList[i] == null)
                {
                    if(judge > 0) // more than 1 judge
                    {
                        return -1;
                    }
                    judge = i;
                }
            }

            // if there is not judge
            if (judge == -1)
            {
                return -1;
            }

            // if we found one judge
            for(int i = 1; i <=n; i++)
            {
                if(i != judge)
                {
                    if (!trustList[i].Contains(judge)) // judge is not trusted by one of member
                    {
                        return -1;
                    }
                }
            }

            return judge;
        }
    }
}
