// 73. Set Matrix Zeroes
// Difficulty: Medium
// https://leetcode.com/problems/set-matrix-zeroes/
// Runtime: 1 ms | Memory: 53.5 MB | Submitted: 2025-05-07

public class Solution {
    public void SetZeroes(int[][] matrix) {
        int[] row = new int[200];
        int[] col = new int[200];
        for (int i = 0;i<matrix.Length;i++)
        {
            for (int j=0;j<matrix[i].Length;j++)
            {
                if (matrix[i][j] == 0)
                    {
                        row[i] = 1;
                        col[j] = 1;
                    }

            }
        }
        for (int i = 0;i<matrix.Length;i++)
        {
            for (int j=0;j<matrix[i].Length;j++)
            {
                if (row[i] == 1 || col[j] == 1)
                    {
                        matrix[i][j] = 0;
                    }

            }
        }
        
    }
}