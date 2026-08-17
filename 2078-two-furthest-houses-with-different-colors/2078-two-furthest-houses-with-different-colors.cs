public class Solution
{
    public int MaxDistance(int[] colors)
    {
        Dictionary<int, int> startingPointMap = [];

        int maxDist = -1;

        for (int i = 0; i < colors.Length; i++)
        {
            startingPointMap.TryAdd(colors[i], i);

            foreach (KeyValuePair<int, int> kvp in startingPointMap)
            {
                if (kvp.Key != colors[i])
                {
                    int dist = i - kvp.Value;
                    if (dist > maxDist)
                        maxDist = dist;
                }
            }
        }

        return maxDist;
    }
}