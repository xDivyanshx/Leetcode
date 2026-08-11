// 3120. Count the Number of Special Characters I
// Difficulty: Easy
// https://leetcode.com/problems/count-the-number-of-special-characters-i/
// Runtime: 0 ms | Memory: 40.7 MB | Submitted: 2026-07-01

public class Solution
{
    public int NumberOfSpecialChars(string word)
    {
        int count = 0;
        bool[] arr = new bool[52];
        foreach (char c in word)
        {
            if (c >= 'A' && c<='Z')
            {
                int index = c - 65;
                if (arr[index])
                    continue;
                arr[index] = true;
                if (arr[index + 26])
                    count++;
            }
            else
            {
                int index = c - 97+26;
                if (arr[index])
                    continue;
                arr[index] = true;
                if (arr[index-26])
                    count++;
            }
        }
        return count;
    }
}