// 3190. Find Minimum Operations to Make All Elements Divisible by Three
// Difficulty: Easy
// https://leetcode.com/problems/find-minimum-operations-to-make-all-elements-divisible-by-three/
// Runtime: 0 ms | Memory: 43.1 MB | Submitted: 2025-11-22

public class Solution {
    public int MinimumOperations(int[] nums) {
        int count = 0;
        foreach (int n in nums)
        {
            if (n % 3 != 0)
                count++;
        }
        return count;
        
    }
}