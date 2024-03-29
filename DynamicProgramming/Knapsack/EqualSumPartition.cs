namespace DynamicProgramming.Knapsack
{
    internal class EqualSumPartition
    {
        /// <summary>
        /// https://practice.geeksforgeeks.org/problems/subset-sum-problem2014/1?utm_source=geeksforgeeks&utm_medium=ml_article_practice_tab&utm_campaign=article_practice_tab
        /// </summary>
        /// <param name="N"></param>
        /// <param name="arr"></param>
        /// <returns></returns>
        public bool CanPartition(int[] nums)
        {
            int n = nums.Length;
            int sum = nums.Sum();
            if(sum % 2 != 0)
                return false;

            sum = sum / 2;
            // create cache
            bool[][] cache = new bool[n + 1][];
            for (int i = 0; i <= n; i++)
            {
                cache[i] = new bool[sum + 1];
                cache[i][0] = true;
            }

            for (int i = 1; i <= sum; i++)
            {
                cache[0][i] = false;
            }
            // Kapsack solution
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= sum; j++)
                {
                    if (nums[i-1] < j)
                    {
                        cache[i][j] = cache[i-1][j - nums[i-1]] || cache[i-1][j];
                    }
                    else
                    {
                        cache[i][j] = cache[i - 1][j];

                    }
                }
            }

            return cache[n][sum];
        }
    }
}
