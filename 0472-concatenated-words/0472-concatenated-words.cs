// 472. Concatenated Words
// Difficulty: Hard
// https://leetcode.com/problems/concatenated-words/
// Runtime: 82 ms | Memory: 70 MB | Submitted: 2026-08-01

public class Solution
{
    public IList<string> FindAllConcatenatedWordsInADict(string[] words)
    {
        HashSet<string> wordSet = new HashSet<string>(words);
        Dictionary<string, bool> memo = new Dictionary<string, bool>();
        IList<string> result = new List<string>();
        foreach (string word in words)
        {
            wordSet.Remove(word);
            if (CanForm(word,wordSet,memo))
            {
                result.Add(word);
            }
            wordSet.Add(word);
        }
        return result;
    }

    private static bool CanForm(string word, HashSet<string> wordSet, Dictionary<string, bool> memo)
    {
        if (memo.TryGetValue(word, out bool r))
            return r;

        for (int i = 1; i < word.Length; i++)
        {
            string prefix = word.Substring(0, i);
            string suffix = word.Substring(i);
            if (wordSet.Contains(prefix) && (wordSet.Contains(suffix) || CanForm(suffix, wordSet, memo)))
            {
                memo[word] = true;
                return true;
            }
        }
        memo[word] = false;
        return false;
    }
}