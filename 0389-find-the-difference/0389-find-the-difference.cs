// 389. Find the Difference
// Difficulty: Easy
// https://leetcode.com/problems/find-the-difference/
// Runtime: 1 ms | Memory: 42.1 MB | Submitted: 2026-06-20

public class Solution
{
    public char FindTheDifference(string s, string t)
    {
        char result = '\0';
        foreach (char c in s)
            result ^= c;
        foreach (char c in t)
            result ^= c;
        return result;
    }
}