// 135. Candy
// Difficulty: Hard
// https://leetcode.com/problems/candy/
// Runtime: 2 ms | Memory: 47.8 MB | Submitted: 2026-06-22


public class Solution
{
    public int Candy(int[] ratings)
    {
        int[] candies = new int[ratings.Length];
        for (int i = 0; i < candies.Length; i++)
        {
            candies[i] = 1;
        }
        for (int i = 1; i < candies.Length; i++)
        {
            if (ratings[i] > ratings[i - 1])
            {
                if (candies[i] <= candies[i - 1])
                    candies[i] = candies[i - 1] + 1;
            }
        }
        for (int i = candies.Length - 2; i >= 0; i--)
        {
            if (ratings[i] > ratings[i + 1])
            {
                if (candies[i] <= candies[i + 1])
                    candies[i] = candies[i + 1] + 1;
            }
        }
        int candyCount = 0;
        foreach (int candy in candies)
        {
            candyCount += candy;
        }
        return candyCount;
    }
}
