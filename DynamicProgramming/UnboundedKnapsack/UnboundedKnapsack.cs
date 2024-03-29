namespace DynamicProgramming.UnboundedKnapsack
{
    internal class UnboundedKnapsack
    {
        public int Unboundedknapsack(int W, int[] wt, int[] val, int n)
        {
            int[][] dp = new int[n + 1][];
            for (int i = 0; i <= n; i++)
            {
                dp[i] = new int[W + 1];
                Array.Fill(dp[i], -1);
            }

            return Unboundedknapsack(W, wt, val, n, dp);
        }

        private int Unboundedknapsack(int W, int[] wt, int[] val, int n, int[][] dp)
        {
           if(n == 0 || W == 0)
                return 0;

            if (dp[n][W] != -1)
                return dp[n][W];

            if (wt[n-1] <= W)
            {
                return dp[n][W] = Math.Max(val[n - 1] + Unboundedknapsack(W - wt[n], wt, val, n - 1, dp), Unboundedknapsack(W, wt, val, n, dp));
            }else
            {    
                return dp[n][W] = Unboundedknapsack(W, wt, val, n - 1, dp);
            }
        }
    }
}
