public class Solution
{
    public int MaxDistance(int[] colors)
    {
        int n = colors.Length;
        int maxDist = 0;

        // Scenario 1: Fix the first house, find the furthest different house from the right
        for (int i = n - 1; i >= 0; i--)
        {
            if (colors[i] != colors[0])
            {
                maxDist = i; // Distance from 0 to i is just i
                break;       // We found the furthest, no need to keep checking
            }
        }

        // Scenario 2: Fix the last house, find the furthest different house from the left
        for (int i = 0; i < n; i++)
        {
            if (colors[i] != colors[n - 1])
            {
                int dist = (n - 1) - i;
                maxDist = Math.Max(maxDist, dist);
                break;       // We found the furthest, no need to keep checking
            }
        }

        return maxDist;
    }
}