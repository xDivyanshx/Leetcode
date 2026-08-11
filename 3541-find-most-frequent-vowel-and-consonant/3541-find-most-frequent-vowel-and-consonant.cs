// 3541. Find Most Frequent Vowel and Consonant
// Difficulty: Easy
// https://leetcode.com/problems/find-most-frequent-vowel-and-consonant/
// Runtime: 1 ms | Memory: 40.9 MB | Submitted: 2025-09-13

public class Solution {
    public int MaxFreqSum(string s) {
        int[] arr = new int[26];
        int maxCon = 0;
        int maxVow = 0;
        foreach (char c in s)
        {
            int i = c - 'a';
            arr[i] = arr[i] + 1;
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
            {
                if (arr[i] > maxVow)
                    maxVow = arr[i];
            }
            else
            {
                if (arr[i] > maxCon)
                    maxCon = arr[i];
            }

        }

        return maxVow + maxCon;
        
    }
}