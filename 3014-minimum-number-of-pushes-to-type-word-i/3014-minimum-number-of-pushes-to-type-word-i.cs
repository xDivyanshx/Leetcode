// 3014. Minimum Number of Pushes to Type Word I
// Difficulty: Easy
// https://leetcode.com/problems/minimum-number-of-pushes-to-type-word-i/
// Runtime: 0 ms | Memory: 39.3 MB | Submitted: 2026-07-30

public class Solution
{
    public int MinimumPushes(string word)
    {
        int total = 0;
        int unique = word.Length;
        int iteration = 1;
        while (unique > 0)
        {
            if (unique > 8)
            {
                unique -= 8;
                total = total + (iteration * 8);
            }
            else
            {
                total = total + (iteration * unique);
                unique = 0;
            }
            iteration++;
        }
        return total;
    }
}