// 8. String to Integer (atoi)
// Difficulty: Medium
// https://leetcode.com/problems/string-to-integer-atoi/
// Runtime: 0 ms | Memory: 41.7 MB | Submitted: 2025-05-07

public class Solution
{
    public int MyAtoi(string s)
    {
        double result = 0;
        bool negFlag = false;
        s = s.Trim();
        for (int i = 0;i<s.Length;i++)
        {
            char c = s[i];
            if (c == '-')
            {
                if (i == 0)
                    negFlag = true;
                else
                    break;
            }
            else if (c == '+')
            {
                if (i == 0)
                    negFlag = false;
                else
                    break;
            }
            else if (char.IsDigit(c))
            {
                int a = (int)c - 48;
                result = result * 10 + a;
            }
            else
            {
                break;
            }

        }
        result = negFlag ? result * -1 : result;
        if (result < Math.Pow(-2, 31))
            result = Math.Pow(-2, 31);
        else if (result > (Math.Pow(2, 31)-1))
            result = Math.Pow(2, 31) -1;
        int res = (int)result;
        return res;
    }

}