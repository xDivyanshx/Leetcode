// 36. Valid Sudoku
// Difficulty: Medium
// https://leetcode.com/problems/valid-sudoku/
// Runtime: 1 ms | Memory: 48.8 MB | Submitted: 2026-06-20

public class Solution
{
    public bool IsValidSudoku(char[][] board)
    {
        bool[][] boxArr = new bool[9][];
        bool[][] veriticalLineArr = new bool[9][];
        bool[][] horizontalLineArr = new bool[9][];

        for (int i = 0; i < 9; i++)
        {
            boxArr[i] = new bool[9];
            veriticalLineArr[i] = new bool[9];
            horizontalLineArr[i] = new bool[9];
        }

        for (int i = 0; i < board.Length; i++)
        {
            char[] line = board[i];
            for (int j = 0; j < line.Length; j++)
            {
                if (line[j] == '.')
                    continue;
                int horLine = i;
                int vertLine = j;
                int box = ((i / 3) * 3) + (j / 3);
                int ele = line[j] - '0' - 1;
                if (boxArr[box][ele])
                    return false;
                else
                    boxArr[box][ele] = true;
                if (horizontalLineArr[horLine][ele])
                    return false;
                else
                    horizontalLineArr[horLine][ele] = true;
                if (veriticalLineArr[vertLine][ele])
                    return false;
                else
                    veriticalLineArr[vertLine][ele] = true;

            }
        }
        return true;
    }
}
