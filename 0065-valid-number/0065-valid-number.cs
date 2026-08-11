// 65. Valid Number
// Difficulty: Hard
// https://leetcode.com/problems/valid-number/
// Runtime: 0 ms | Memory: 44.8 MB | Submitted: 2025-09-25

// ///////////////////////////////////////////////////////////////////////////////////////////////////////
//
//
// All rights reserved by OneBanc
//
//
// (c) Copyright 2025 OneBanc Technologies Pvt. Ltd.
//
//
// ////////////////////////////////////////////////////////////////////////////////////////////////////////

public class Solution
{
	public bool IsNumber(string s)
	{
		int i = 0;
		int n = s.Length;
		if (i < n && (s[i] == '+' || s[i] == '-'))
			i++;

		bool isValid = false;

		while (i < n && char.IsDigit(s[i]))
		{
			i++;
			isValid = true;
		}


		if (i < n && s[i] == '.')
		{
			i++;
			while (i < n && char.IsDigit(s[i]))
			{
				i++;
				isValid = true;
			}
		}
		if (isValid && i < n && (s[i] == 'e' || s[i] == 'E'))
		{
			i++;
			isValid = false;

			if (i < n && (s[i] == '+' || s[i] == '-'))
				i++;

			while (i < n && char.IsDigit(s[i]))
			{
				i++;
				isValid = true;
			}
		}

		return isValid && i == n;
	}
}