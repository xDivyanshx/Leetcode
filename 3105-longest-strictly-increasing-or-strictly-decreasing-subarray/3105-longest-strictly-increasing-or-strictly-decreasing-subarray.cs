// 3105. Longest Strictly Increasing or Strictly Decreasing Subarray
// Difficulty: Easy
// https://leetcode.com/problems/longest-strictly-increasing-or-strictly-decreasing-subarray/
// Runtime: 0 ms | Memory: 43.9 MB | Submitted: 2025-04-02

public class Solution
{
    public int LongestMonotonicSubarray(int[] nums)
    {
        int maxLen = 1;
        int incDig = nums[0];
        int incLen = 1;
        int decDig = nums[0];
        int decLen = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > incDig)
                incLen++;
            else
                incLen = 1;
            incDig = nums[i];

            if (decDig > nums[i])
            
                decLen++;
            
            else
            {
                decLen = 1;
            
            }
            decDig = nums[i];
            maxLen = Math.Max(maxLen, Math.Max(incLen, decLen));
        }
        return maxLen;
    }
}