// 5. Longest Palindromic Substring
// Difficulty: Medium
// https://leetcode.com/problems/longest-palindromic-substring/
// Runtime: 31 ms | Memory: 41 MB | Submitted: 2026-06-20


using System;

public class Solution
{
    public string LongestPalindrome(string s)
    {
        int maxLength = -1;
        int startIndex = -1;
        for (int i = 0; i < s.Length; i++)
        {
            // For odd length palindromes
            int oddMax = ExpandAroundCenter(s, i, i);
            // For even length palindromes
            int evenMax = ExpandAroundCenter(s, i, i + 1);
            int max = Math.Max(oddMax, evenMax);
            if (max > maxLength)
            {
                maxLength = max;
                // if max=4, i=2, sI = 1
                // if max=3, i=2, sI = 1
                startIndex = i - ((max - 1) / 2);
            }
        }
        return s.Substring(startIndex, maxLength);

    }

    // Take the left as potential center, and finds longest substring it could be a part of
    // Right is also present to tackle even length strings
    // eg. babab, babbaba
    private static int ExpandAroundCenter(string s, int left, int right)
    {
        for (; left >= 0 && right < s.Length; left--, right++)
        {
            if (s[left] != s[right])
                break;
        }
        // for babab, right = -1 and left = 5, after loop, so 5 - (-1) - 1
        return right - left - 1;
    }
}
