// 3016. Minimum Number of Pushes to Type Word II
// Difficulty: Medium
// https://leetcode.com/problems/minimum-number-of-pushes-to-type-word-ii/
// Runtime: 8 ms | Memory: 52.3 MB | Submitted: 2026-07-31

public class Solution 
{
    public int MinimumPushes(string word) 
    {
        // 1. Use a 26-element array instead of a Dictionary
        int[] freq = new int[26];
        
        // Foreach on a string is highly optimized in C#
        foreach (char c in word) 
        {
            // Subtracting 'a' converts the char to an index (0 to 25)
            freq[c - 'a']++;
        }
        
        // 2. Sort the array. C# sorts ascending by default.
        // Sorting 26 integers is effectively instantaneous O(1) time.
        Array.Sort(freq);
        
        int total = 0;
        
        // 3. Iterate backwards (from highest frequency to lowest)
        for (int i = 25; i >= 0; i--) 
        {
            // If we hit a 0, we've processed all letters present in the word
            if (freq[i] == 0) break;
            
            // Math trick to replace the innerCount/iteration tracker:
            // (25 - i) gets us the 0-based rank of the letter.
            // Dividing by 8 and adding 1 gives exactly the multiplier (1, 2, 3, etc.)
            int pushes = ((25 - i) / 8) + 1;
            
            total += freq[i] * pushes;
        }
        
        return total;
    }
}