// 2140. Solving Questions With Brainpower
// Difficulty: Medium
// https://leetcode.com/problems/solving-questions-with-brainpower/
// Runtime: 2 ms | Memory: 93.6 MB | Submitted: 2025-04-02

public class Solution
{
    public long MostPoints(int[][] questions)
    {
        int n = questions.Length;
        long[] dpArray = new long[n + 1];
        for (int i = n - 1; i >= 0; i--)
        {
            int points = questions[i][0];
            int brainPower = questions[i][1];
            long skip = dpArray[i + 1];
            long solve = points;
            if (i + brainPower + 1 < n)
                solve = solve + dpArray[i + brainPower + 1];
            dpArray[i] = skip > solve ? skip : solve;
        }
        return dpArray[0];
    }
}