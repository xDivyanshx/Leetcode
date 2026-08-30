public class Solution
{
    public IList<string> TwoEditWords(string[] queries, string[] dictionary)
    {
        List<string> result = new List<string>();
        for (int i = 0; i < queries.Length; i++)
        {
            for (int j = 0; j < dictionary.Length; j++)
            {
                int edits = 0;
                for (int k = 0; k < queries[0].Length; k++)
                {
                    if (queries[i][k] != dictionary[j][k])
                    {
                        edits++;
                    }
                    if (edits > 2)
                        break;
                }
                if (edits <= 2)
                {
                    result.Add(queries[i]);
                    break;
                }
            }
        }
        return result;
    }
}