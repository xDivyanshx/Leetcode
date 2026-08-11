// 2554. Maximum Number of Integers to Choose From a Range I
// Difficulty: Medium
// https://leetcode.com/problems/maximum-number-of-integers-to-choose-from-a-range-i/
// Runtime: 78 ms | Memory: 62.8 MB | Submitted: 2025-05-04

public class Solution
{
    public int MaxCount(int[] banned, int n, int maxSum)
    {
        int maxCount = 0;
        int sum = 0;
        HashSet<int> bannedSet = new HashSet<int>(banned);
        for (int  i =1;i<= n;i++)
        {
            if (!bannedSet.Contains(i))
            {
                sum += i;
                if (sum <= maxSum)
                    maxCount++;
                else 
                    break;
            }

        }
        return maxCount;
    }
}