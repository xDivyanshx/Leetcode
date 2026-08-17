using System;

public class Solution
{
    public int StoneGameV(int[] stoneValue)
    {
        int n = stoneValue.Length;
        int[] prefixSum = new int[n];

        // Build prefix sum array
        prefixSum[0] = stoneValue[0];
        for (int i = 1; i < n; i++)
        {
            prefixSum[i] = prefixSum[i - 1] + stoneValue[i];
        }

        // Create a 2D memoization table to store max scores for any [start, end] range
        int[,] memo = new int[n, n];

        // Start the game with the full array: from index 0 to n - 1
        return Solve(prefixSum, 0, n - 1, memo);
    }

    private int Solve(int[] prefixSum, int start, int end, int[,] memo)
    {
        // 1. Base Case: If there is only 1 stone left, the game ends. Score is 0.
        if (start == end)
            return 0;

        // 2. Memoization: If we already calculated this exact chunk, return the saved answer!
        if (memo[start, end] != 0)
            return memo[start, end];

        int maxScore = 0;

        // 3. The Split Loop: Try slicing the array at EVERY possible index inside this chunk
        for (int split = start; split < end; split++)
        {
            // Calculate sums of left part and right part in O(1) time using prefix sums
            int leftSum = prefixSum[split] - (start > 0 ? prefixSum[start - 1] : 0);
            int rightSum = prefixSum[end] - prefixSum[split];

            // 4. Game Rules: Evaluate the split
            if (leftSum < rightSum)
            {
                // Bob throws away right. Alice gets leftSum, and the game continues on the left part.
                int currentScore = leftSum + Solve(prefixSum, start, split, memo);
                maxScore = Math.Max(maxScore, currentScore);
            }
            else if (rightSum < leftSum)
            {
                // Bob throws away left. Alice gets rightSum, and the game continues on the right part.
                int currentScore = rightSum + Solve(prefixSum, split + 1, end, memo);
                maxScore = Math.Max(maxScore, currentScore);
            }
            else // leftSum == rightSum
            {
                // TIE! Alice gets the sum, PLUS the absolute best outcome of continuing on EITHER the left OR the right.
                int bestFuturePath = Math.Max(Solve(prefixSum, start, split, memo), Solve(prefixSum, split + 1, end, memo));
                int currentScore = leftSum + bestFuturePath;
                maxScore = Math.Max(maxScore, currentScore);
            }
        }

        // 5. Save the best score we found for this chunk so we never calculate it again
        memo[start, end] = maxScore;

        return maxScore;
    }
}