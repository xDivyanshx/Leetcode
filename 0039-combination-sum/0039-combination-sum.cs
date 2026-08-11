// 39. Combination Sum
// Difficulty: Medium
// https://leetcode.com/problems/combination-sum/
// Runtime: 5 ms | Memory: 47.2 MB | Submitted: 2026-06-23


using System.Collections.Generic;

public class Solution
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        IList<IList<int>> result = [];
        IList<int> element = [];
        BackTrack(candidates, target, result, element, 0, 0);
        return result;

    }

    private static void BackTrack(int[] candidates, int target, IList<IList<int>> result, IList<int> element, int sum, int startIndex)
    {
        if (sum == target)
        {
            result.Add(new List<int>(element));
        }
        else if (sum > target)
        {
            return;
        }
        for (int j = startIndex; j < candidates.Length; j++)
        {
            int i = candidates[j];

            element.Add(i);

            sum = sum + i;

            BackTrack(candidates, target, result, element, sum, j);

            sum = sum - i;

            element.RemoveAt(element.Count - 1);
        }
    }
}
