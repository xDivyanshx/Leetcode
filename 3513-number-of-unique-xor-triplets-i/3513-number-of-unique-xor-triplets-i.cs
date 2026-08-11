// 3513. Number of Unique XOR Triplets I
// Difficulty: Medium
// https://leetcode.com/problems/number-of-unique-xor-triplets-i/
// Runtime: 0 ms | Memory: 86 MB | Submitted: 2026-07-23

public class Solution
{
    public int UniqueXorTriplets(int[] nums)
    {
        if (nums.Length == 0)
            return 0;
        else if (nums.Length == 1)
            return 1;
        else if (nums.Length == 2)
            return 2;
        else
        {
            int maxEle = nums.Length;
            int powerOfMaxEle = (int)Math.Log2(maxEle);
            return (int)Math.Pow(2,(powerOfMaxEle + 1));
        }

    }
}