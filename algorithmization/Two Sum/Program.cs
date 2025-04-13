namespace Two_Sum
{
    // все примеры и условия задачи с одноименным названием (проекта) на leetcode
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TwoSum([2, 7, 11, 15], 9)); // => [0,1]
        }
        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> numMap = new Dictionary<int, int>(); // A mapping to store numbers and their indices
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i]; // Find the required number to reach the target
                if (numMap.ContainsKey(complement))
                {
                    return new int[] { numMap[complement], i }; // Return indices of the complement and current number
                }
                numMap[nums[i]] = i; // Store the number with its index
            }
            return new int[] { }; // This line is never reached due to the problem guarantee
        }
    }
}
