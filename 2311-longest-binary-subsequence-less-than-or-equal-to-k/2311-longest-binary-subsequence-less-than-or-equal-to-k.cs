// 2311. Longest Binary Subsequence Less Than or Equal to K
// Difficulty: Medium
// https://leetcode.com/problems/longest-binary-subsequence-less-than-or-equal-to-k/
// Runtime: 1 ms | Memory: 40.2 MB | Submitted: 2025-06-26

public class Solution
{
	public int LongestSubsequence(string s, int k)
	{
		long result = 0;
		int count = 0;
		bool foundInvalid1 = false;
		for (int i = s.Length - 1; i >= 0; i--)
		{
			char c = s[i];
			if (c == '0')
			{
				count++;
			}
			else if (!foundInvalid1)
			{
				long temp = result + (long)Math.Pow(2, count);
				if (temp <= k)
				{
					result = temp;
					count++;
				}
				else
				{
					foundInvalid1 = true;
				}
			}

		}
		return count;
	}
}
