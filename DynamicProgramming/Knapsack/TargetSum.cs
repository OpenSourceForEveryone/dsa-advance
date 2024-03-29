namespace DynamicProgramming.Knapsack
{
    internal class TargetSum
    {
        /// <summary>
        /// https://leetcode.com/problems/target-sum/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int FindTargetSumWays(int[] nums, int target)
        {
             /*
              * s1 + s2 = sum
              * s1 - s2 = diff
              * s1 = diff + sum  /  2;
            */
            if (nums.Length == 1)    
            {
                if (Math.Abs(nums[0]) == Math.Abs(target))
                    return 1;
                else
                    return 0;
            }
            int sum = nums.Sum();
            if (target > sum || (sum + target) % 2 != 0)
                return 0;
            sum = (sum + target) / 2;
            if (sum < 0)
                return 0;
            // count the subset with sum s1
            int[][] table = new int[nums.Length + 1][];
            for (int i = 0; i <= nums.Length; i++)
            {
                table[i] = new int[sum + 1];
                table[i][0] = 1;
            }
            for (int j = 1; j <= sum; j++)
            {
                table[0][j] = 0;
            }
            // knapsack
            int coutZero = nums[0] == 0 ? 1 : 0;
            for (int i = 1; i <= nums.Length; i++)
            {
                if (i < nums.Length && nums[i] == 0)
                {
                    coutZero++;
                }
                for (int j = 1; j <= sum; j++)
                {
                    if (nums[i - 1] != 0 && nums[i - 1] <= j)
                    {
                        table[i][j] = table[i - 1][j] + table[i - 1][j - nums[i - 1]];
                    }
                    else
                    {
                        table[i][j] = table[i - 1][j];
                    }
                }
            }
            return table[nums.Length][sum] * (int)Math.Pow(2, coutZero);
        }
    }
}
