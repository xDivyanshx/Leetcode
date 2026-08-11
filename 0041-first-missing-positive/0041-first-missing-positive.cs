// 41. First Missing Positive
// Difficulty: Hard
// https://leetcode.com/problems/first-missing-positive/
// Runtime: 1 ms | Memory: 64.4 MB | Submitted: 2026-06-20


public class Solution
{
    public int FirstMissingPositive(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            while (nums[i] != i + 1 && nums[i] > 0 && nums[i] <= nums.Length)
            {
                if (!Swap(nums, i))
                    break;
            }

        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != i + 1)
                return i + 1;
        }

        return nums.Length + 1;

    }

    private static bool Swap(int[] a, int index)
    {
        int number = a[index];
        int numberToSwap = a[number - 1];
        if (numberToSwap != number)
        {
            a[index] = numberToSwap;
            a[number - 1] = number;
            return true;
        }
        return false;
    }
}