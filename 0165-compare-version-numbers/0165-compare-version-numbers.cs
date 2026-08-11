// 165. Compare Version Numbers
// Difficulty: Medium
// https://leetcode.com/problems/compare-version-numbers/
// Runtime: 0 ms | Memory: 39.5 MB | Submitted: 2025-09-23

public class Solution
{
	public int CompareVersion(string version1, string version2)
	{
		int i = 0, j = 0;
		while (i < version1.Length || j < version2.Length)
		{
			int v1 = 0;
			while (i < version1.Length && version1[i] != '.')
			{
				v1 = v1 * 10 + (version1[i] - '0');
				i++;
			}

			int v2 = 0;
			while (j < version2.Length && version2[j] != '.')
			{
				v2 = v2 * 10 + (version2[j] - '0');
				j++;
			}

			if (v1 < v2)
				return -1;
			else if (v1 > v2)
				return 1;

			i++; // Skip the dot
			j++; // Skip the dot
		}
		return 0;
	}
}
