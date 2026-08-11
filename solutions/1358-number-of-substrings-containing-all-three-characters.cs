// 1358. Number of Substrings Containing All Three Characters
// Difficulty: Medium
// https://leetcode.com/problems/number-of-substrings-containing-all-three-characters/
// Runtime: 1600 ms | Memory: 42.8 MB | Submitted: 2026-06-30

public class Solution
{
    public int NumberOfSubstrings(string s)
    {
        int count = 0;
        for (int i = 0; i < s.Length; i++)
        {
            bool aFound = false;
            bool bFound = false;
            bool cFound = false;
            for (int j = i; j < s.Length; j++)
            {
                if (!aFound && s[j] == 'a')
                    aFound = true;
                if (!bFound && s[j] == 'b')
                    bFound = true;
                if (!cFound && s[j] == 'c')
                    cFound = true;
                if (aFound && bFound && cFound)
                {
                    count += (s.Length - 1 - j)+1;
                    break;
                }
            }
        }
        return count;
    }
}
