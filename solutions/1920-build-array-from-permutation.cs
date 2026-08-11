// 1920. Build Array from Permutation
// Difficulty: Easy
// https://leetcode.com/problems/build-array-from-permutation/
// Runtime: 0 ms | Memory: 52.7 MB | Submitted: 2025-05-07

public class Solution {
    public int[] BuildArray(int[] nums) {
        int[] arr = new int[nums.Length];
        int i = 0;
        foreach (int n in nums)
        {
            arr[i++] = nums[n];
        }
        return arr;
        
    }
}