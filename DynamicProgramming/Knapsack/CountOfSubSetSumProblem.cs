namespace DynamicProgramming.Knapsack
{
    internal class CountOfSubSetSumProblem
    {
        public int CountOfSubSetSum(int[] nums, int sum)
        {
            // target is given 
            // we have choice to select each element
            // this is a Knapsack problem
            int[][] table = new int[nums.Length+1][];
            for (int i = 0; i <= nums.Length; i++)
            {
                table[i] = new int[sum+1];
                table[i][0] = 1;
            }
            for (int j = 1; j <= sum; j++)
            {
                table[0][j] = 0;
            }
            for (int i = 1; i <= nums.Length; i++)
            {
                for (int j = 0; j <= sum; j++)
                {
                    if (nums[i-1] <= j)
                    {
                        table[i][j] = table[i - 1][j] + table[i - 1][j-nums[i-1]];
                    }
                    else
                    {
                        table[i][j] = table[i - 1][j];
                    }
                }
            }
            return table[nums.Length][sum];
        }
    }
}
    