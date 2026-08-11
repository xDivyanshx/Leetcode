public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, int> indexMap = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            int complement = target - nums[i];
            if (indexMap.TryGetValue(complement, out int complementIndex))
            {
                return [complementIndex, i];
            }
            indexMap[nums[i]] = i;

        }
        return [0, 0];
    }
}