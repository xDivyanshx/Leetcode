// 746. Min Cost Climbing Stairs
// Difficulty: Easy
// https://leetcode.com/problems/min-cost-climbing-stairs/
// Runtime: 1 ms | Memory: 43.6 MB | Submitted: 2026-06-23


using System;

public class Solution
{
    public int MinCostClimbingStairs(int[] cost)
    {
        int[] costArray = new int[cost.Length + 1];
        costArray[costArray.Length - 1] = 0;
        costArray[costArray.Length - 2] = cost[cost.Length - 1];
        for (int i = costArray.Length - 3; i >= 0; i--)
        {
            costArray[i] = cost[i] + Math.Min(costArray[i + 1], costArray[i + 2]);
        }
        return Math.Min(costArray[0], costArray[1]);
    }
}