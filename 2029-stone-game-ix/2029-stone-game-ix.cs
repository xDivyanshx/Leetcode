public class Solution
{
    public bool StoneGameIX(int[] stones)
    {
        int zeros = 0;
        int ones = 0;
        int twos = 0;
        
        // 1. Sort the stones into buckets based on their remainder
        for (int i = 0; i < stones.Length; i++)
        {
            int rem = stones[i] % 3;
            if (rem == 0)
                zeros++;
            else if (rem == 1)
                ones++;
            else
                twos++;
        }

        // 2. Determine the winner based on the Game Theory math rules
        if (zeros % 2 == 0)
        {
            return ones > 0 && twos > 0;
        }
        else
        {
            return Math.Abs(ones - twos) > 2;
        }
    }
}