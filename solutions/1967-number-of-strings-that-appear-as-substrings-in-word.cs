// 1967. Number of Strings That Appear as Substrings in Word
// Difficulty: Easy
// https://leetcode.com/problems/number-of-strings-that-appear-as-substrings-in-word/
// Runtime: 20 ms | Memory: 57.4 MB | Submitted: 2026-06-29


using System.Collections.Generic;

public class Solution
{
    public int NumOfStrings(string[] patterns, string word)
    {
        HashSet<string> substrings = new HashSet<string>();
        for (int i = 0; i < word.Length; i++)
        {
            for (int j = i+1; j <= word.Length; j++)
            {
                substrings.Add(word.Substring(i, j - i));
            }
        }
        int count = 0;
        foreach (string patter in patterns)
        {
            if (substrings.Contains(patter))
                count++;
        }
        return count;
    }
}
