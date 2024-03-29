namespace BackTracking.AdityaPlayList
{
    internal class PermutationOfString
    {
        /// <summary>
        /// Find all permutation of a string
        /// </summary>
        /// <param name="input"></param>
        public List<string> Permutation(string input)
        {
            List<string> result = new List<string>();
            Solve(input, string.Empty, result);
            return result; 
        }

        private void Solve(string input, string output, List<string> result)
        {
            if (input.Length == 0)
            {
                result.Add(output);
            }
            HashSet<char> map = new HashSet<char>();
            for (int i = 0; i < input.Length; i++)
            {
                if (map.Add(input[i]))
                {
                    string newInput = input.Substring(0, i) + input.Substring(i + 1);
                    string newOutput = output + input[i];
                    Solve(newInput, newOutput, result);
                }
            }
        }
    }
}
