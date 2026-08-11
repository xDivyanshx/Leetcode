// 1742. Maximum Number of Balls in a Box
// Difficulty: Easy
// https://leetcode.com/problems/maximum-number-of-balls-in-a-box/
// Runtime: 3 ms | Memory: 29.2 MB | Submitted: 2026-06-30

public class Solution
{
    public int CountBalls(int lowLimit, int highLimit)
    {
        int[] count = new int[46]; // The maximum sum of digits for numbers up to 10^5 is 45
        for (int i = lowLimit; i <= highLimit; i++)
        {
            int sum = 0;
            int num = i;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            count[sum]++;
        }
        int maxCount = 0;
        for (int i = 0; i < count.Length; i++)
        {
            if (count[i] > maxCount)
            {
                maxCount = count[i];
            }
        }
        return maxCount;

    }
}