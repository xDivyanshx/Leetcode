// 3345. Smallest Divisible Digit Product I
// Difficulty: Easy
// https://leetcode.com/problems/smallest-divisible-digit-product-i/
// Runtime: 0 ms | Memory: 29.1 MB | Submitted: 2026-08-06

public class Solution
{
    public int SmallestNumber(int n, int t)
    {
        for (int i=n; ;i++)
        {
            if (Product(i) % t == 0)
                return i;
        }
    }

    private static int Product(int x)
    {
        int product = 1;
        while (x > 0)
        {
            product *= x % 10;
            x /= 10;
        }
        return product;
    }
}