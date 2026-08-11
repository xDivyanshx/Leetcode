// 2749. Minimum Operations to Make the Integer Zero
// Difficulty: Medium
// https://leetcode.com/problems/minimum-operations-to-make-the-integer-zero/
// Runtime: 1 ms | Memory: 29.2 MB | Submitted: 2026-06-22

public class Solution
{
    // so lets say we are getting there at k operations
    // num1 - (2^i1 + num2) - (2^i2 + num2) ... k times
    // num1 - (k * num2) = 2^i1 + 2^i2
    // now as given i can be 0,60
    // so looping from 0 to 60
    // now for k=1, i would get a target value
    // i need to know the minimum number of 2^i blocks required to make the target value -> number of set bits in a number -> e.g. 30 -> 11110 -> (16+8+4+2)
    // maxmimum is the number itself because we can use 1 to add up all

    public int MakeTheIntegerZero(int num1, int num2)
    {
        for (int i = 0; i <= 60; i++)
        {
            long target = num1 - (i * (long)num2);
            long min = GetSetBits(target);
            if (min <= i && i <= target)
            {
                return i;
            }

        }
        return -1;
    }

    private static long GetSetBits(long a)
    {
        if (a <= 0)
            return 0;
        long count = 0;
        long temp = a;
        while (temp > 0)
        {
            count += temp & 1;
            temp >>= 1;
        }
        return count;
    }
}
