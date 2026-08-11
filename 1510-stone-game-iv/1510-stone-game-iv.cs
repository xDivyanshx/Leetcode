// 1510. Stone Game IV
// Difficulty: Hard
// https://leetcode.com/problems/stone-game-iv/
// Runtime: 15 ms | Memory: 31.6 MB | Submitted: 2026-08-11

public class Solution
{
    public bool WinnerSquareGame(int n)
    {
        bool[] dp = new bool[n + 1];
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; (j * j) <= i; j++)
            {
                if (!dp[i - (j * j)])
                {
                    dp[i] = true;
                    break;
                }
            }
        }
        return dp[n];
    }
}