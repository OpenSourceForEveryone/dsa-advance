namespace DynamicProgramming.Knapsack
{
    internal class CountSubSetWithGivenDifference
    {
        /// <summary>
        /// https://www.geeksforgeeks.org/problems/partitions-with-given-difference/1
        /// </summary>
        /// <param name="n"></param>
        /// <param name="d"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int countPartitions(int n, int d, List<int> arr)
        {
            /*
            * s1 + s2 = sum
            * s1 - s2 = diff
            * s1 = diff + sum  /  2;
            */
            int mod = 1000000007;
            int sum = arr.Sum();
            sum = sum + d;
            if (sum % 2 != 0)
                return 0;


            sum = sum / 2;
            // count the subset with sum s1
            int[][] table = new int[n + 1][];
            for (int i = 0; i <= n; i++)
            {
                table[i] = new int[sum + 1];
                table[i][0] = 1;
            }
            for (int j = 1; j <= sum; j++)
            {
                table[0][j] = 0;
            }
            // knapsack
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= sum; j++)
                {
                    if (arr[i - 1] <= j)
                    {
                        table[i][j] = (table[i - 1][j] + table[i - 1][j - arr[i - 1]]) % mod;
                    }
                    else
                    {
                        table[i][j] = table[i - 1][j] % mod;
                    }
                }
            }
            return table[n][sum] % mod;
        }
    }
}
