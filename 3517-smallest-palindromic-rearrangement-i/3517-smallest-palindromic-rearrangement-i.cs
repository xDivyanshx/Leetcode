// 3517. Smallest Palindromic Rearrangement I
// Difficulty: Medium
// https://leetcode.com/problems/smallest-palindromic-rearrangement-i/
// Runtime: 31 ms | Memory: 62.5 MB | Submitted: 2026-07-28

using System.Text;

public class Solution
{
    public string SmallestPalindrome(string s)
    {
        int[] freqMap = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            int index = (int)c - 'a';
            freqMap[index]++;
        }
        StringBuilder sb1 = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();
        char middle = '\0';
        for (int j = 0; j < 26; j++)
        {
            if (freqMap[j] > 0)
            {
                char c = (char)('a' + j);
                if (freqMap[j] % 2 != 0)
                {
                    middle = c;
                }
                for (int i = 1; i <= freqMap[j] / 2; i++)
                {
                    sb1.Append(c);
                }
            }
        }
        for (int i = sb1.Length - 1; i >= 0; i--)
        {
            sb2.Append(sb1[i]);
        }
        if (middle == '\0')
            return sb1.Append(sb2).ToString();
        else
            return sb1.Append(middle).Append(sb2).ToString();
    }
}