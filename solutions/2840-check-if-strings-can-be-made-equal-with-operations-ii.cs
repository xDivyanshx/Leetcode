// 2840. Check if Strings Can be Made Equal With Operations II
// Difficulty: Medium
// https://leetcode.com/problems/check-if-strings-can-be-made-equal-with-operations-ii/
// Runtime: 4 ms | Memory: 52 MB | Submitted: 2026-08-11

public class Solution
{
    public bool CheckStrings(string s1, string s2)
    {
        if (s1.Length != s2.Length)
            return false;

        int[] evenArr = new int[26];
        int[] oddArr = new int[26];

        for (int i = 0; i < s1.Length; i++)
        {
            char ch = s1[i];
            int index = ch - 'a';
            if (i % 2 == 0)
            {
                evenArr[index]++;
            }
            else
            {
                oddArr[index]++;
            }
        }

        for (int i = 0; i < s2.Length; i++)
        {
            char ch = s2[i];
            int index = ch - 'a';
            if (i % 2 == 0)
            {
                evenArr[index]--;
            }
            else
            {
                oddArr[index]--;
            }
        }

        foreach (int i in evenArr)
        {
            if (i != 0)
                return false;
        }

        foreach (int i in oddArr)
        {
            if (i != 0)
                return false;
        }

        return true;

    }
}