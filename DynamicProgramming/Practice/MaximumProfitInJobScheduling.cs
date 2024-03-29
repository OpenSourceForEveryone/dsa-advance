namespace DynamicProgramming.Practice
{
    internal class MaximumProfitInJobScheduling
    {
        public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
        {
            int n = startTime.Length;
            List<MyJob> jobs = new List<MyJob>();

            for (int i = 0; i < n; i++)
            {
                jobs.Add(new MyJob(startTime[i], endTime[i], profit[i]));
            }
            jobs.Sort((x, y) => x.EndTime.CompareTo(y.EndTime));

            int[] dp = new int[n + 1];

            for (int i = 1; i <= n; i++)
            {
                dp[i] = Math.Max(dp[i - 1], jobs[i - 1].Profit);
                for (int j = i - 1; j > 0; j--)
                {
                    if (jobs[i - 1].StartTime >= jobs[j - 1].EndTime)
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + jobs[i - 1].Profit);
                        break;
                    }
                }
            }
            return dp[n];
        }
        public class MyJob
        {
            public int StartTime;
            public int EndTime;
            public int Profit;

            public MyJob(int start, int end, int prof)
            {
                StartTime = start;
                EndTime = end;
                Profit = prof;
            }
        }
    }
}
