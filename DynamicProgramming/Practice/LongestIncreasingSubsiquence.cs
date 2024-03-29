namespace DynamicProgramming.Practice
{
    internal class LongestIncreasingSubsiquence
    {
        public int LengthOfLIS(int[] nums)
        {
            int[] LIS = new int[nums.Length];
            // Initialization 
            for (int i = 0; i < nums.Length; i++)
            {
                LIS[i] = 1;
            }

            // memorization logic
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] < nums[j])
                    {
                        LIS[i] = Math.Max(LIS[i], 1 + LIS[j]);
                    }
                }
            }
            return LIS.Max();
        }
    }
}
