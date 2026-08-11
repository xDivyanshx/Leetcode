// 438. Find All Anagrams in a String
// Difficulty: Medium
// https://leetcode.com/problems/find-all-anagrams-in-a-string/
// Runtime: 5 ms | Memory: 51.4 MB | Submitted: 2026-08-11

public class Solution
{
    public IList<int> FindAnagrams(string s, string p)
    {
        if (s.Length < p.Length)
            return new List<int>();

        int[] freqArr = new int[26];

        foreach (char ch in p)
        {
            int index = ch - 'a';
            freqArr[index]++;
        }

        for (int i = 0; i < p.Length; i++)
        {
            char ch = s[i];
            int index = ch - 'a';
            freqArr[index]--;
        }

        List<int> result = new List<int>();
        if (IsAnagram(freqArr))
            result.Add(0);

        for (int i = 1; (i + p.Length - 1) < s.Length; i++)
        {
            int prevIndex = s[i - 1] - 'a';
            freqArr[prevIndex]++;
            int nextIndex = s[i + p.Length - 1] - 'a';
            freqArr[nextIndex]--;
            if (IsAnagram(freqArr))
                result.Add(i);


        }

        return result;

    }

    private static bool IsAnagram(int[] freqArr)
    {
        foreach (int i in freqArr)
        {
            if (i != 0)
                return false;
        }
        return true;
    }
}