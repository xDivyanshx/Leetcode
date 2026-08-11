// 2657. Find the Prefix Common Array of Two Arrays
// Difficulty: Medium
// https://leetcode.com/problems/find-the-prefix-common-array-of-two-arrays/
// Runtime: 2 ms | Memory: 61.1 MB | Submitted: 2026-05-20

public class Solution {
	public int[] FindThePrefixCommonArray(int[] A, int[] B)
	{

		bool[] a = new bool[A.Length+1]; bool[] b = new bool[B.Length+1];

		for (int i = 0; i < A.Length; i++)
			a[i] = false;
		for (int i = 0; i < B.Length; i++)
			b[i] = false;
		int[] ab = new int[A.Length];
		int c = 0;
		for (int i = 0; i < A.Length; i++)
		{
			int a1 = A[i];
			int b1 = B[i];
			if (a1 == b1)
			{
				c++;
			}
			if (a[b1])
				c++;
			if (b[a1])
				c++;
			a[a1] = true;
			b[b1] = true;
			ab[i] = c;
		}
		return ab;
	}
}