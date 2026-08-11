// 7. Reverse Integer
// Difficulty: Medium
// https://leetcode.com/problems/reverse-integer/
// Runtime: 24 ms | Memory: 29 MB | Submitted: 2025-07-03

public class Solution {
    public int Reverse(int x)
    {
        int y = 0;
        while (x!=0)
        {
            int d = x % 10;
            x /= 10;
            if (y > int.MaxValue / 10 || (y == int.MaxValue / 10 && d > 7)) return 0;
            if (y < int.MinValue / 10 || (y == int.MinValue / 10 && d < -8)) return 0;
            y = y * 10 + (d);
        }
        return y;
    }
}