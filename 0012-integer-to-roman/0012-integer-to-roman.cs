// 12. Integer to Roman
// Difficulty: Medium
// https://leetcode.com/problems/integer-to-roman/
// Runtime: 3 ms | Memory: 46.4 MB | Submitted: 2026-06-20


using System.Text;

public class Solution
{
    public string IntToRoman(int num)
    {
        StringBuilder romanString = new StringBuilder();
        int[] integerValues = [1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1];
        string[] romanValues = ["M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"];

        for (int i = 0; i < integerValues.Length; i++)
        {
            int value = integerValues[i];
            while (num >= value)
            {
                romanString.Append(romanValues[i]);
                num -= value;
            }
        }
        return romanString.ToString();
    }
}
