// 17. Letter Combinations of a Phone Number
// Difficulty: Medium
// https://leetcode.com/problems/letter-combinations-of-a-phone-number/
// Runtime: 0 ms | Memory: 47.7 MB | Submitted: 2026-06-20


using System.Collections.Generic;
using System.Text;

public class Solution
{

    private static char[][] letters = [['a', 'b', 'c'], ['d', 'e', 'f'], ['g', 'h', 'i'], ['j', 'k', 'l'], ['m', 'n', 'o'], ['p', 'q', 'r', 's'], ['t', 'u', 'v'], ['w', 'x', 'y', 'z']];

    public IList<string> LetterCombinations(string digits)
    {
        List<string> result = new List<string>();
        StringBuilder currentPath = new StringBuilder();
        BackTrack(digits, 0, currentPath, result);
        return result;
    }

    private static void BackTrack(string digits, int index, StringBuilder currentString, List<string> result)
    {
        if (index == digits.Length)
        {
            result.Add(currentString.ToString());
            return;
        }
        char[] possibleLetters = letters[digits[index] - '2'];
        foreach (char c in possibleLetters)
        {
            currentString.Append(c);

            BackTrack(digits, index + 1, currentString, result);

            currentString.Length--;
        }
    }
}