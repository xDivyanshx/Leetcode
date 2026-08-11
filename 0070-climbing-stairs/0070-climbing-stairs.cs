// 70. Climbing Stairs
// Difficulty: Easy
// https://leetcode.com/problems/climbing-stairs/
// Runtime: 0 ms | Memory: 29 MB | Submitted: 2026-06-23

public class Solution
{
    public int ClimbStairs(int n)
    {
        int[] wayCount = new int[n + 1];
        wayCount[n] = 1;
        wayCount[n - 1] = 1;
        int totalWays = 0;
        for (int i = n - 2; i >= 0; i--)
        {
            wayCount[i] = wayCount[i + 1] + wayCount[i + 2];
        }
        return wayCount[0];
    }
}