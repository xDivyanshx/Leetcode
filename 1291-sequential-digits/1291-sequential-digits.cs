// 1291. Sequential Digits
// Difficulty: Medium
// https://leetcode.com/problems/sequential-digits/
// Runtime: 0 ms | Memory: 39.7 MB | Submitted: 2026-07-13

public class Solution
{
    public IList<int> SequentialDigits(int low, int high)
    {
        List<int> result = new List<int>();
        int lowLength = low.ToString().Length;
        int highLength = high.ToString().Length;
        for (int i = lowLength; i <= highLength; i++)
        {
            for (int startDigit = 1;(startDigit+i-1) <=9;startDigit++)
            {
                int number = 0;
                for (int j=0;j<i;j++)
                {
                    number = number * 10 + (startDigit + j);
                }
                if (number < low || number > high)
                    continue;
                result.Add(number);
            }
        }
        return result;
    }
}