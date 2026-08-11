// 22. Generate Parentheses
// Difficulty: Medium
// https://leetcode.com/problems/generate-parentheses/
// Runtime: 0 ms | Memory: 49.8 MB | Submitted: 2026-06-23

using System.Collections.Generic;
using System.Text;

public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        // i can choose open or close
        // for open to choose i i just it to be present in the bucket
        // for close to choose, i need its count to be < open in the string
        List<string> results = new List<string>();
        BackTrack(new StringBuilder(), results, n, 0, 0);
        return results;
    }

    private void BackTrack(StringBuilder sb, List<string> results, int n, int openCount, int closeCount)
    {
        if (sb.Length == (n * 2))
        {
            results.Add(sb.ToString());
            return;
        }
        bool canChooseOpen = openCount < n;
        bool canChooseClose = closeCount < openCount;

        if (canChooseOpen)
        {
            BackTrack(sb.Append('('), results, n, openCount + 1, closeCount);
            sb.Length--;
        }

        if (canChooseClose)
        {
            BackTrack(sb.Append(')'), results, n, openCount, closeCount + 1);
            sb.Length--;
        }
    }
}
