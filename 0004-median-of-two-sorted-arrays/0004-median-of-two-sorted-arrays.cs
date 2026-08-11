// 4. Median of Two Sorted Arrays
// Difficulty: Hard
// https://leetcode.com/problems/median-of-two-sorted-arrays/
// Runtime: 1 ms | Memory: 55.9 MB | Submitted: 2025-09-13

public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int m = nums1.Length, n = nums2.Length;
        int[] merged = new int[m + n];
        int i = 0, j = 0, k = 0;

        while (i < m && j < n) {
            if (nums1[i] < nums2[j]) {
                merged[k++] = nums1[i++];
            } else {
                merged[k++] = nums2[j++];
            }
        }
        while (i < m) merged[k++] = nums1[i++];
        while (j < n) merged[k++] = nums2[j++];

        int totalLength = m + n;
        if (totalLength % 2 == 1) {
            return merged[totalLength / 2];
        } else {
            int mid1 = merged[totalLength / 2 - 1];
            int mid2 = merged[totalLength / 2];
            return (mid1 + mid2) / 2.0;
        }
    }
}
