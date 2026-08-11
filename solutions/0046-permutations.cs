// 46. Permutations
// Difficulty: Medium
// https://leetcode.com/problems/permutations/
// Runtime: 1 ms | Memory: 47.7 MB | Submitted: 2026-06-23


using System.Collections.Generic;

public class Solution
{
    public IList<IList<int>> Permute(int[] nums)
    {
        IList<IList<int>> result = new List<IList<int>>();
        bool[] usedArr = new bool[nums.Length];
        BackTrack(nums, usedArr, [], result);
        return result;
    }

    private static void BackTrack(int[] nums, bool[] usedArr, List<int> element, IList<IList<int>> result)
    {
        if (element.Count == nums.Length)
        {
            result.Add(new List<int>(element));
            return;
        }

        for (int j = 0; j < nums.Length; j++)
        {
            int i = nums[j];
            if (!usedArr[j])
            {
                usedArr[j] = true;

                element.Add(i);

                BackTrack(nums, usedArr, element, result);

                usedArr[j] = false;
                element.RemoveAt(element.Count - 1);
            }
        }
    }
}