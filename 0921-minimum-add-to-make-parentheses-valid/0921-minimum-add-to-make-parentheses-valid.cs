public class Solution
{
    public int MinAddToMakeValid(string s)
    {
        int remainingOpeningBracket = 0;
        int total = 0;
        foreach (char c in s)
        {
            if (c == '(')
            {
                remainingOpeningBracket++;
            }
            else
            {
                if (remainingOpeningBracket == 0)
                {
                    total++;
                }
                else
                    remainingOpeningBracket--;
            }
        }
        return total + remainingOpeningBracket;
    }
}