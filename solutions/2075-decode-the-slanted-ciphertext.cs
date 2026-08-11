// 2075. Decode the Slanted Ciphertext
// Difficulty: Medium
// https://leetcode.com/problems/decode-the-slanted-ciphertext/
// Runtime: 17 ms | Memory: 78.6 MB | Submitted: 2026-08-02

using System.Text;

public class Solution
{
    public string DecodeCiphertext(string encodedText, int rows)
    {
        if (string.IsNullOrEmpty(encodedText))
            return string.Empty;
        int columns = ((encodedText.Length - 1) / rows) + 1;
        char[][] matrix = new char[rows][];
        for (int i = 0; i < rows; i++)
        {
            matrix[i] = new char[columns];
        }
        int index = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i][j] = encodedText[index++];
            }
        }

        StringBuilder originalText = new StringBuilder();
        for (int j = 0; j < columns; j++)
        {
            for (int i = 0; i < rows; i++)
            {
                if (i + j < columns)
                    originalText.Append(matrix[i][i + j]);
            }
        }
        string originalTextString = originalText.ToString().TrimEnd();
        return originalTextString;

    }
}