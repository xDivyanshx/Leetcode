public class Solution
{
    public bool IsGood(int[] nums)
    {
        int max = int.MinValue;
        int maxOccurances = 0;
        HashSet<int> visited = new HashSet<int>();

        foreach (int i in nums)
        {
            if (i == max)
            {
                maxOccurances++;
                if (maxOccurances > 2)
                {
                    return false;
                }
            }
            else if (i > max)
            {
                maxOccurances = 1;
                max = i;
                visited.Add(i);
            }
            else if (!visited.Add(i))
                return false;
        }

        if (maxOccurances != 2)
            return false;

        for (int i = 1; i < max; i++)
        {
            if (!visited.Contains(i))
                return false;
        }

        return true;
    }
}