// 274. H-Index
// Difficulty: Medium
// https://leetcode.com/problems/h-index/
// Runtime: 0 ms | Memory: 41.6 MB | Submitted: 2025-06-24

public class Solution {
    public int HIndex(int[] citations) {
        int n = citations.Length;
        int[] counts = new int[n + 1];

        // Count papers with citations
        foreach (int c in citations) {
            if (c >= n) {
                counts[n]++;
            } else {
                counts[c]++;
            }
        }

        // Accumulate counts from the end
        int total = 0;
        for (int i = n; i >= 0; i--) {
            total += counts[i];
            if (total >= i) {
                return i;
            }
        }

        return 0;
    }
}
