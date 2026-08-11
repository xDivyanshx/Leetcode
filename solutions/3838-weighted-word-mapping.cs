// 3838. Weighted Word Mapping
// Difficulty: Easy
// https://leetcode.com/problems/weighted-word-mapping/
// Runtime: 3 ms | Memory: 51.4 MB | Submitted: 2026-06-13

using System;

public class Solution
{
    public string MapWordWeights(string[] words, int[] weights)
    {
        string rValue = String.Empty;
        foreach (string word in words)
        {
            int s = 0;
            foreach (char c in word)
            {
                int index = c - 'a';
                s += weights[index];
            }

            int v = s%26;
            v = 'z'-v;

            rValue += (char)(v);
        }

        return rValue;

    }
}