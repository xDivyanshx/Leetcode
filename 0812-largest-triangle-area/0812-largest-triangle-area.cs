// 812. Largest Triangle Area
// Difficulty: Easy
// https://leetcode.com/problems/largest-triangle-area/
// Runtime: 2 ms | Memory: 41.9 MB | Submitted: 2025-10-06

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

using System;

public class Solution
{
	public double LargestTriangleArea(int[][] points)
	{
		double maxArea = 0;
		for (int i = 0; i < points.Length; i++)
		{
			for (int j = i + 1; j < points.Length; j++)
			{
				for (int k = j + 1; k < points.Length; k++)
				{
					double area = 0.5 * Math.Abs((points[i][0] * (points[j][1] - points[k][1])) + (points[j][0] * (points[k][1] - points[i][1])) + (points[k][0] * (points[i][1] - points[j][1])));
					maxArea = area > maxArea ? area : maxArea;
				}

			}
		}
		return maxArea;
	}
}