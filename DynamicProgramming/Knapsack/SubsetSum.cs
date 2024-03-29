namespace DynamicProgramming.Knapsack
{
    /// <summary>
    /// https://www.geeksforgeeks.org/problems/subset-sum-problem-1611555638/1?itm_source=geeksforgeeks&itm_medium=article&itm_campaign=bottom_sticky_on_article
    /// </summary>
    internal class SubsetSum
    {
        static bool isSubsetSum(int N, int[] arr, int sum)
        {

            // initialization
            bool[][] table = new bool[N+1][];
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = new bool[sum + 1];
                table[i][0] = true;
            }

            for(int j = 1; j < table[0].Length; j++)
            {
                table[0][j] = false;
            }
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= sum; j++)
                {
                    if (arr[i - 1] <= j)
                    {
                        table[i][j] = table[i][j - arr[i - 1]] || table[i - 1][j];
                    }
                    else
                    {
                        table[i][j] = table[i - 1][j];
                    }
                }
            }
            return table[table.Length-1][sum-1];
        }
    }
}
