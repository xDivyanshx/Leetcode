using System.Text;

public class Solution
{
    public string ProcessStr(string s)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < s.Length; i++)
        {
            char ch = s[i];
            if (ch == '*')
            {
                if (sb.Length > 0)
                {
                    sb.Remove(sb.Length - 1, 1);
                }
            }
            else if (ch == '#')
            {
                if (sb.Length > 0)
                {
                    sb.Append(sb);
                }
            }
            else if (ch == '%')
            {
                Reverse(sb);
            }
            else
            {
                sb.Append(ch);
            }
        }
        return sb.ToString();
    }

    private static void Reverse(StringBuilder sb)
    {
        for (int i = 0; i < sb.Length / 2; i++)
        {
            (sb[i], sb[sb.Length - 1 - i]) = (sb[sb.Length - 1 - i], sb[i]);
        }
    }
}