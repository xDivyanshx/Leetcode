public class Solution
{
    public int MinMirrorPairDistance(int[] nums)
    {
        Dictionary<int, int> reversedTrack = [];
        int minDist = int.MaxValue;
        for (int i = 0; i < nums.Length; i++)
        {
            int n = nums[i];
            if (reversedTrack.ContainsKey(n))
            {
                int dist = i - reversedTrack[n];
                minDist = Math.Min(minDist, dist);
            }

            while (n > 0 && n % 10 == 0)
            {
                n /= 10;
            }

            int reverse = 0;
            while (n > 0)
            {
                reverse = reverse * 10 + (n % 10);
                n /= 10;
            }

            reversedTrack[reverse] = i;

        }

        if (minDist == int.MaxValue)
            return -1;
        else
            return minDist;
    }
}