// 1331. Rank Transform of an Array
// Difficulty: Easy
// https://leetcode.com/problems/rank-transform-of-an-array/
// Runtime: 45 ms | Memory: 71.5 MB | Submitted: 2026-08-11

public class Solution
{
    public int[] ArrayRankTransform(int[] arr)
    {
        int[] sortedArr = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            sortedArr[i] = arr[i];
        }
        Array.Sort(sortedArr);
        Dictionary<int, int> rankMap = new Dictionary<int, int>();
        int rank = 1;
        foreach (int i in sortedArr)
        {
            if (!rankMap.ContainsKey(i))
            {
                rankMap[i] = rank++;
            }
        }
        int[] rankArr = new int[arr.Length];
        for (int i = 0; i < arr.Length; i++)
        {
            rankArr[i] = rankMap[arr[i]];
        }
        return rankArr;
    }
}