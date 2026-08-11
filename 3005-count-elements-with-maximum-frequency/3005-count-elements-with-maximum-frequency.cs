// 3005. Count Elements With Maximum Frequency
// Difficulty: Easy
// https://leetcode.com/problems/count-elements-with-maximum-frequency/
// Runtime: 0 ms | Memory: 43 MB | Submitted: 2025-09-22

public class Solution {
    public int MaxFrequencyElements(int[] nums) {
        Span<int> frs = stackalloc int[100];

        foreach (var num in nums)
        {
            frs[num - 1]++;
        }

        var maxFr = 0;
        var count = 0;

        foreach (var fr in frs)
        {
            if (fr > maxFr)
            {
                maxFr = fr;
                count = fr;
            }
            else if (fr == maxFr)
            {
                count += fr;
            }
        }

        return count;
    }
}