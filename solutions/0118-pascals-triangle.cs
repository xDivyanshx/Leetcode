// 118. Pascal's Triangle
// Difficulty: Easy
// https://leetcode.com/problems/pascals-triangle/
// Runtime: 2 ms | Memory: 40.4 MB | Submitted: 2026-06-23

using System.Collections.Generic;

public class Solution
{
    public IList<IList<int>> Generate(int numRows)
    {
        List<IList<int>> dataRows = [[1]];
        if (numRows > 1)
            dataRows.Add([1, 1]);
        for (int i = 2; i < numRows; i++)
        {
            List<int> row = [1];
            for (int j = 1; j < i; j++)
            {
                row.Add(dataRows[i - 1][j - 1] + dataRows[i - 1][j]);
            }
            row.Add(1);
                        dataRows.Add(row);
        }
        return dataRows;
    }
}
