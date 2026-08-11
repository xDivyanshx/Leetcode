// 3163. String Compression III
// Difficulty: Medium
// https://leetcode.com/problems/string-compression-iii/
// Runtime: 14 ms | Memory: 55.1 MB | Submitted: 2025-04-02

using System.Text;

public class Solution
{
    public string CompressedString(string word)
    {
        int count = 1;
        char lastChar = word[0];
        StringBuilder comp = new();
        for (int i = 1; i < word.Length; i++)
        {
            char c = word[i];
            if (c == lastChar && count < 9)
                count++;
            else
            {
                comp.Append(count).Append(lastChar);
                lastChar = c;
                count = 1;
            }
        }
        comp.Append(count).Append(lastChar);
        return comp.ToString();
    }
}