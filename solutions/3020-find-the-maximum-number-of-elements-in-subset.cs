// 3020. Find the Maximum Number of Elements in Subset
// Difficulty: Medium
// https://leetcode.com/problems/find-the-maximum-number-of-elements-in-subset/
// Runtime: 790 ms | Memory: 69.3 MB | Submitted: 2026-06-27


using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public int MaximumLength(int[] nums)
    {
        // 1. Changed dictionary key to 'long' so we don't overflow when squaring!
        SortedDictionary<long, int> freqMap = new SortedDictionary<long, int>();
        foreach (int num in nums)
        {
            if (!freqMap.ContainsKey(num))
                freqMap[num] = 0;
            freqMap[num]++;
        }

        List<long> keys = freqMap.Keys.ToList();
        int maxLength = -1;

        for (int i = 0; i < keys.Count; i++)
        {
            long key = keys[i];
            int value = freqMap[key];

            if (key == 1)
            {
                maxLength = value % 2 == 0 ? value - 1 : value;
            }
            else
            {
                long totalValue = key;
                int currentLength = 0;

                while (true)
                {
                    // 2. We MUST check if the dictionary contains the key before asking for it, 
                    // otherwise C# throws a KeyNotFoundException and crashes.
                    if (!freqMap.ContainsKey(totalValue))
                    {
                        break; // This is the equivalent of your (freq == 0) check
                    }

                    int freq = freqMap[totalValue];

                    if (freq >= 1)
                    {
                        int temp = (currentLength * 2) + 1;
                        if (temp > maxLength)
                            maxLength = temp;
                    }

                    if (freq >= 2)
                    {
                        currentLength++;
                        // 3. Fix the squaring math! Just multiply the number by itself.
                        totalValue = totalValue * totalValue;
                    }
                    else
                    {
                        // If freq is 1, it's the peak of our mountain. 
                        // We already calculated temp max above, so we just break.
                        break;
                    }
                }
            }
        }

        return maxLength;
    }
}