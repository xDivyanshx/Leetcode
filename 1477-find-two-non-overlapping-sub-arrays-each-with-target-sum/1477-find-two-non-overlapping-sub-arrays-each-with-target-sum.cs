public class Solution
{
    public int MinSumOfLengths(int[] arr, int target)
    {
        int length = arr.Length;
        int[] minLen = new int[length];

        // We use int.MaxValue / 2 to represent infinity so that adding two 
        // "infinities" together doesn't cause a negative integer overflow.
        int infinity = int.MaxValue / 2;

        for (int i = 0; i < length; i++)
        {
            minLen[i] = infinity;
        }

        int left = 0;
        int sum = 0;
        int minCombinedLength = infinity;
        int shortestSingleSubarray = infinity;

        for (int right = 0; right < length; right++)
        {
            sum += arr[right];

            // If our window sum is too big, shrink it from the left
            while (sum > target && left <= right)
            {
                sum -= arr[left];
                left++;
            }

            // We found a valid sub-array!
            if (sum == target)
            {
                int currentLength = right - left + 1;

                // If there is a valid sub-array before our current 'left' index
                if (left > 0 && minLen[left - 1] != infinity)
                {
                    int combinedLength = currentLength + minLen[left - 1];
                    if (combinedLength < minCombinedLength)
                    {
                        minCombinedLength = combinedLength;
                    }
                }

                // Update the running record for the shortest single sub-array found so far
                if (currentLength < shortestSingleSubarray)
                {
                    shortestSingleSubarray = currentLength;
                }
            }

            // Record history: the best sub-array length ending at or before 'right'
            minLen[right] = shortestSingleSubarray;
        }

        // If we never found two non-overlapping arrays, return -1
        if (minCombinedLength == infinity)
        {
            return -1;
        }

        return minCombinedLength;
    }
}