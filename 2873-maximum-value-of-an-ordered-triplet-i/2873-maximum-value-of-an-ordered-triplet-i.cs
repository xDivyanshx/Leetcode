// 2873. Maximum Value of an Ordered Triplet I
// Difficulty: Easy
// https://leetcode.com/problems/maximum-value-of-an-ordered-triplet-i/
// Runtime: 0 ms | Memory: 42.9 MB | Submitted: 2025-04-02

public class Solution
{
    public long MaximumTripletValue(int[] nums)
    {
        long maxSum = 0;
        long maxDiff = 0;
        long maxEle = 0;
        foreach (int i in nums)
        {
            maxSum = Math.Max(maxSum, maxDiff * i);
            maxDiff = Math.Max(maxDiff, maxEle - i);
            maxEle = Math.Max(maxEle, i);
        }
        return maxSum;

    }
}