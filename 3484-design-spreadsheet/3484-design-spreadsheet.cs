// 3484. Design Spreadsheet
// Difficulty: Medium
// https://leetcode.com/problems/design-spreadsheet/
// Runtime: 73 ms | Memory: 78.7 MB | Submitted: 2025-09-19

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
using System.Collections.Generic;

public class Spreadsheet
{
	private List<List<int>> dataRows;

	public Spreadsheet(int rows)
	{
		dataRows = new List<List<int>>(rows);

		for (int i = 0; i < rows; i++)
		{
			List<int> row = new List<int>(new int[26]); // 26 columns for A-Z
			dataRows.Add(row);
		}
	}

	public void SetCell(string cell, int value)
	{
		(int row, int col) = ParseCell(cell);
		dataRows[row][col] = value;
	}

	public void ResetCell(string cell)
	{
		(int row, int col) = ParseCell(cell);
		dataRows[row][col] = 0;
	}

	public int GetValue(string formula)
	{
		if (string.IsNullOrWhiteSpace(formula))
			return 0;

		formula = formula.TrimStart('=');
		string[] parts = formula.Split('+', StringSplitOptions.RemoveEmptyEntries);

		int result = 0;

		foreach (string part in parts)
		{
			result += ParseOperand(part);
		}

		return result;
	}

	// Helper method to convert cell string like "A1" to row and column indices
	private (int row, int col) ParseCell(string cell)
	{
		char columnChar = cell[0];
		int col = columnChar - 'A';

		string rowStr = cell.Substring(1);
		int row = int.Parse(rowStr) - 1;

		return (row, col);
	}

	// Helper method to get value from either a literal number or a cell reference
	private int ParseOperand(string operand)
	{
		if (int.TryParse(operand, out int value))
		{
			return value;
		}

		(int row, int col) = ParseCell(operand);
		return dataRows[row][col];
	}
}
