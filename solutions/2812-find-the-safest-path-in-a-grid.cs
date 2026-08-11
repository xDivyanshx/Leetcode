// 2812. Find the Safest Path in a Grid
// Difficulty: Medium
// https://leetcode.com/problems/find-the-safest-path-in-a-grid/
// Runtime: 758 ms | Memory: 68.9 MB | Submitted: 2026-07-01

using System;
using System.Collections.Generic;

public class Solution
{
    // Direction arrays for Up, Down, Left, Right
    private readonly int[] dirX = { -1, 1, 0, 0 };
    private readonly int[] dirY = { 0, 0, -1, 1 };

    public int MaximumSafenessFactor(IList<IList<int>> grid)
    {
        int n = grid.Count;
        
        // Edge Case: If the start or end is a thief, the safeness is immediately 0.
        if (grid[0][0] == 1 || grid[n - 1][n - 1] == 1) return 0;

        // ==========================================
        // PHASE 1: Build the "Heat Map" (Multi-Source BFS)
        // ==========================================
        int[,] safeness = new int[n, n];
        bool[,] visited = new bool[n, n];
        Queue<(int r, int c)> queue = new Queue<(int, int)>();

        // 1. Find all thieves and add them to the queue
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] == 1)
                {
                    queue.Enqueue((i, j));
                    visited[i, j] = true;
                    safeness[i, j] = 0;
                }
            }
        }

        // 2. Spread the ripples out to calculate distances
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            int r = current.r;
            int c = current.c;

            for (int i = 0; i < 4; i++)
            {
                int newRow = r + dirX[i];
                int newCol = c + dirY[i];

                if (newRow >= 0 && newRow < n && newCol >= 0 && newCol < n && !visited[newRow, newCol])
                {
                    visited[newRow, newCol] = true;
                    safeness[newRow, newCol] = safeness[r, c] + 1;
                    queue.Enqueue((newRow, newCol));
                }
            }
        }

        // ==========================================
        // PHASE 2: Indiana Jones Walk (Dijkstra / Max-Heap)
        // ==========================================
        
        // Max-Heap: Always hands us the cell with the highest safeness score first
        PriorityQueue<(int r, int c, int score), int> pq = 
            new PriorityQueue<(int, int, int), int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
            
        bool[,] visitedWalk = new bool[n, n];
        
        // Start at the top-left corner
        pq.Enqueue((0, 0, safeness[0, 0]), safeness[0, 0]);
        visitedWalk[0, 0] = true;

        // 3. Walk the grid safely
        while (pq.Count > 0)
        {
            var current = pq.Dequeue();
            int r = current.r;
            int c = current.c;
            int currentScore = current.score;

            // EXIT CONDITION: Reached the bottom-right corner!
            if (r == n - 1 && c == n - 1)
            {
                return currentScore;
            }

            for (int i = 0; i < 4; i++)
            {
                int newRow = r + dirX[i];
                int newCol = c + dirY[i];

                if (newRow >= 0 && newRow < n && newCol >= 0 && newCol < n && !visitedWalk[newRow, newCol])
                {
                    visitedWalk[newRow, newCol] = true;
                    
                    // The path score is only as strong as its weakest link (lowest safeness)
                    int nextScore = Math.Min(currentScore, safeness[newRow, newCol]);
                    
                    pq.Enqueue((newRow, newCol, nextScore), nextScore);
                }
            }
        }

        return 0; // Fallback 
    }
}