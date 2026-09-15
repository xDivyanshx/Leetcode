public class Solution
{
    public int MaxPalindromes(string s, int k)
    {
        int count = 0;
        for (int i = 0; i <= s.Length - k;)
        {
            if (i + k <= s.Length && IsPalindrome(s.AsSpan(i, k)))
            {
                count++;
                i += k;
            }
            else if (i + k + 1 <= s.Length && IsPalindrome(s.AsSpan(i, k + 1)))
            {
                count++;
                i += k + 1;
            }
            else
                i++;
        }
        return count;
    }

    private static bool IsPalindrome(ReadOnlySpan<char> s)
    {
        for (int i = 0; i < s.Length / 2; i++)
        {
            if (s[i] != s[s.Length - i - 1])
                return false;
        }
        return true;
    }
}