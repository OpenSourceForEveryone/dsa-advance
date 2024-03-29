namespace DynamicProgramming.Knapsack
{
    // https://www.geeksforgeeks.org/problems/0-1-knapsack-problem0945/1?itm_source=geeksforgeeks&itm_medium=article&itm_campaign=bottom_sticky_on_article
    internal class KnapsackGFG
    {
        public int knapSack(int W, int[] wt, int[] val, int n)
        {
            int[][] dp = new int[n + 1][];
            for (int i = 0; i <= n; i++)
            {
                dp[i] = new int[W + 1];
                Array.Fill(dp[i], -1);
            }
            return knapSack(W, wt, val, n, dp);
        }

        private int knapSack(int W, int[] wt, int[] val, int n, int[][] dp)
        {
            //Your code here
            if (n == 0 || W == 0)
                return 0;

            if (dp[n][W] != -1)
            {
                return dp[n][W];
            }

            if (wt[n - 1] <= W)
            {
                return dp[n][W] = Math.Max(val[n - 1] + knapSack(W - wt[n - 1], wt, val, n - 1, dp),
                    knapSack(W, wt, val, n - 1, dp));

            }
            else
            {
                return dp[n][W] = knapSack(W, wt, val, n - 1, dp);
            }
        }

        private int knapSackDP(int W, int[] wt, int[] val, int n)
        {
            int[,] dp = new int[n + 1, W + 1];
            for(int i=0; i <= n; i++)
            {
                dp[i, 0] = 0;
            }
            for (int j = 0; j <= W; j++)
            {
                dp[0, j] = 0;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= W; j++)
                {
                    if (wt[i-1] <= j)
                    {
                        dp[i, j] = Math.Max(val[i - 1] + dp[i - 1, j - wt[i - 1]], dp[i - 1, j]);
                    }
                    else
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                }
            }
            return dp[n, W];
        }
    }
}
