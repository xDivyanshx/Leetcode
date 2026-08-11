// 830. Positions of Large Groups
// Difficulty: Easy
// https://leetcode.com/problems/positions-of-large-groups/
// Runtime: 2 ms | Memory: 47.9 MB | Submitted: 2026-06-30

public class Solution
{
    public IList<IList<int>> LargeGroupPositions(string s)
    {
        IList<IList<int>> list = new List<IList<int>>();
        char lastChar = '\0';
        int count = 0;
        int startIndex = 0;
        int endIndex = -1;
        for(int i=0;i<s.Length;i++)
        {
            char a = s[i];
            if (a == lastChar)
            {
                count++;
                if (count>=3)
                {
                    char nextChar = i == s.Length-1 ? '\0' : s[i+1];
                    if ( nextChar == a)
                    {

                    }
                    else
                    {
                        endIndex = i;
                        list.Add(new List<int>() { startIndex, endIndex });
                        startIndex = i + 1;
                        endIndex = -1;
                        count = 0;
                    }
                }

            }
            else
            {
                lastChar = a;
                startIndex = i;
                endIndex = -1;
                count = 1;


            }

            
        }
        return list;
        

    }
}