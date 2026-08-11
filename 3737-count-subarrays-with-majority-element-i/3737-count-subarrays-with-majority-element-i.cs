// 3737. Count Subarrays With Majority Element I
// Difficulty: Medium
// https://leetcode.com/problems/count-subarrays-with-majority-element-i/
// Runtime: 41 ms | Memory: 50.6 MB | Submitted: 2026-06-25

public class Solution
{
    public int CountMajoritySubarrays(int[] nums, int target)
    {
        int totalCount = 0;
        for (int startIndex = 0; startIndex < nums.Length; startIndex++)
        {
            int count = 0;
            for (int endIndex = startIndex; endIndex < nums.Length; endIndex++)
            {
                if (nums[endIndex] == target)
                {
                    count++;
                }
                if (count > ((endIndex - startIndex+1) / 2))
                {
                    totalCount++;
                }
            }
        }
        return totalCount;
    }
}