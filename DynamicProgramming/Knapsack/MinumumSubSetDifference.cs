namespace DynamicProgramming.Knapsack
{
    internal class MinumumSubSetDifference
    {
        /// <summary>
        /// https://leetcode.com/problems/partition-array-into-two-arrays-to-minimize-sum-difference/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>`
        public int MinimumDifference(int[] nums)
        {
            int range = nums.Sum();
            bool[][] table = new bool[nums.Length+1][];
            for (int i = 0; i <= nums.Length; i++)
            {
                table[i] = new bool[range + 1];
                table[i][0] = true;
            }

            for (int j = 1; j <= range; j++)
            {
                table[1][j] = false;
            }

            // knapsack
            for (int i = 1; i <= nums.Length; i++)
            {
                for (int j = 1; j <= range; j++)
                {
                    if (nums[i-1] <= j)
                    {
                        table[i][j] = table[i - 1][j - nums[i - 1]] || table[i - 1][j];
                    }
                    else
                    {
                        table[i][j] = table[i - 1][j];
                    }
                }
            }

            // difference candidate will be last row of the table

            int min = int.MaxValue;
            for (int i = 0; i <= range/2; i++)
            {
                if (table[nums.Length][i])
                {
                    min = Math.Min(min,  range - 2 * i);
                }
            }

            return min;
        }
    }
}
