public class Solution
{
    public long GetDescentPeriods(int[] prices)
    {
        long result = prices.Length;
        int length = 1;
        for (int i = 1; i < prices.Length; i++)
        {
            if (prices[i] == prices[i - 1] - 1)
            {
                length++;
                result += (length - 1);
            }
            else
                length = 1;
        }
        return result;
    }
}