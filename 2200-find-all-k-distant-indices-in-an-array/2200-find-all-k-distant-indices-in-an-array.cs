// 2200. Find All K-Distant Indices in an Array
// Difficulty: Easy
// https://leetcode.com/problems/find-all-k-distant-indices-in-an-array/
// Runtime: 1 ms | Memory: 50 MB | Submitted: 2025-06-24

public class Solution
{
    public IList<int> FindKDistantIndices(int[] nums, int key, int k)
    {
        List<int> result = new List<int>();
        int[] arr = new int[nums.Length+1];
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] ==key)
            {
               int start = Math.Max(0, i-k);
               int end = Math.Min(nums.Length-1, i+k);
                arr[start]++;
                arr[end + 1]--;
            }
        }
        int count = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            count += arr[i];
            if (count > 0)
                result.Add(i);
        }
        return result;

    }
}
