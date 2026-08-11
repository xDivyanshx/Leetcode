// 1128. Number of Equivalent Domino Pairs
// Difficulty: Easy
// https://leetcode.com/problems/number-of-equivalent-domino-pairs/
// Runtime: 1 ms | Memory: 52.4 MB | Submitted: 2025-05-04

public class Solution
{
    public int NumEquivDominoPairs(int[][] dominoes)
    {
        int[] values = new int[100];
        int result = 0;
        foreach (int[] domino in dominoes)
        {
            int key = domino[0] < domino[1] ? domino[0] * 10 + domino[1] : domino[1] * 10 + domino[0];
            result += values[key];
            values[key]++;
        }
        return result;
    }
}