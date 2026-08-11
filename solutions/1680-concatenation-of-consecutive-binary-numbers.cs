// 1680. Concatenation of Consecutive Binary Numbers
// Difficulty: Medium
// https://leetcode.com/problems/concatenation-of-consecutive-binary-numbers/
// Runtime: 40 ms | Memory: 29.4 MB | Submitted: 2026-07-13

public class Solution
{
    private const int Mod = 1000000007;
    public int ConcatenatedBinary(int n)
    {
        int lengthToShift = 0;
        long result = 0;
        for (int i=1;i<=n;i++)
        {
            // if its a power of 2, we need to shift +1 element now
            if ((i & (i-1)) == 0)
            {
                lengthToShift++;
            }
            result = ((result << lengthToShift) + i) % Mod;

        }
        return (int)result;
    }
}