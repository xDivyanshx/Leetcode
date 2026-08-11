// 78. Subsets
// Difficulty: Medium
// https://leetcode.com/problems/subsets/
// Runtime: 0 ms | Memory: 47 MB | Submitted: 2026-06-27


using System.Collections.Generic;

public class Solution
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        IList<IList<int>> result = [];

        BackTrack(nums, 0, [], result);

        return result;
    }

    private static void BackTrack(int[] nums, int index, List<int> current, IList<IList<int>> result)
    {
        result.Add(new List<int>(current));
        if (nums.Length == index)
        {
            return;
        }

        for (int i = index; i < nums.Length; i++)
        {
            current.Add(nums[i]);
            BackTrack(nums, i + 1, current, result);
          current.RemoveAt(current.Count - 1);
        }
    }
}