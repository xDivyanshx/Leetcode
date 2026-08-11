// 1863. Sum of All Subset XOR Totals
// Difficulty: Easy
// https://leetcode.com/problems/sum-of-all-subset-xor-totals/
// Runtime: 4 ms | Memory: 41.6 MB | Submitted: 2025-04-05

public class Solution
{
    public int SubsetXORSum(int[] nums)
    {
        int total = 0;
        int n = nums.Length;

        for (int mask = 0; mask < (1 << n); mask++)
        {
            int subsetXor = 0;
            for (int i = 0; i < n; i++)
            {
                if ((mask & (1 << i)) != 0)
                {
                    subsetXor ^= nums[i];
                }
            }
            total += subsetXor;
        }

        return total;
    }
}
