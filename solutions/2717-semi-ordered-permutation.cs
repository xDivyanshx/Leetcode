// 2717. Semi-Ordered Permutation
// Difficulty: Easy
// https://leetcode.com/problems/semi-ordered-permutation/
// Runtime: 1 ms | Memory: 47.3 MB | Submitted: 2026-06-22


public class Solution
{
    public int SemiOrderedPermutation(int[] nums)
    {

        int firstIndex = -1;
        int nIndex = -1;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 1)
                firstIndex = i;
            else if (nums[i] == nums.Length)
                nIndex = i;
        }
        if (firstIndex < nIndex)
        {
            // 2315764 -> to get 1 to first i would need 2 (2nd index) swaps to get 1 to first index, and 2 (7-1-4) swapsto get to last index for 7
            return firstIndex + (nums.Length - 1 - nIndex);
        }
        else
        {
            // 2375164 -> to get 1 to first i would need 4 (4th index) swaps to get 1 to first index, and 3 (7-1-4)-1 swaps to get to last index for 7 becuase it would shifted one right side when moving 1 to the leftmost index
            return firstIndex + (nums.Length - 1 - nIndex) - 1;
        }
    }
}
