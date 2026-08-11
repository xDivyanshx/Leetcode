// 1189. Maximum Number of Balloons
// Difficulty: Easy
// https://leetcode.com/problems/maximum-number-of-balloons/
// Runtime: 0 ms | Memory: 40.1 MB | Submitted: 2026-06-22


using System;

public class Solution
{
    public int MaxNumberOfBalloons(string text)
    {

        int[] freqMap = new int[26];

        foreach (char c in text)
        {
            freqMap[c - 'a']++;
        }

        return Math.Min(Math.Min(Math.Min(Math.Min(freqMap['a' - 'a'], freqMap['b'-'a']), freqMap['n' - 'a']), freqMap['l' - 'a'] / 2), freqMap['o' - 'a'] / 2);
    }
}
