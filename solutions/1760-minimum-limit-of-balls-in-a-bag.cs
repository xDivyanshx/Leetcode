// 1760. Minimum Limit of Balls in a Bag
// Difficulty: Medium
// https://leetcode.com/problems/minimum-limit-of-balls-in-a-bag/
// Runtime: 29 ms | Memory: 67.3 MB | Submitted: 2025-05-04

using System.Security.Cryptography;

public class Solution
{
    public int MinimumSize(int[] nums, int maxOperations)
    {
        int lower = 1;
        int higher = nums.Max();
        int minPenalty = 0;
        while (lower <= higher)
        {
            int count = 0;
            int mid = lower + (higher - lower) / 2;
            foreach (var item in nums)
            {
                if (item > mid)
                    count = count + ((item - 1) / mid);
                if (count > maxOperations)
                    break;


            }
            if (count > maxOperations)
                lower = mid + 1;
            else
            {
                minPenalty = mid;
                higher = mid - 1;
            }

        }
        return minPenalty;
    }
}