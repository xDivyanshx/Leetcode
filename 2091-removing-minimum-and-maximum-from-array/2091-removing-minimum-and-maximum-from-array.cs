public class Solution
{
    public int MinimumDeletions(int[] nums)
    {
        int left = 0;
        int right = nums.Length - 1;
        int minElement = nums[0];
        int maxElement = nums[0];
        int minIndex = 0;
        int maxIndex = 0;
        int total = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > maxElement)
            {
                maxElement = nums[i];
                maxIndex = i;
            }
            else if (nums[i] < minElement)
            {
                minElement = nums[i];
                minIndex = i;
            }
        }
        bool minRemoved = false;
        bool maxRemoved = false;
        while (true)
        {
            if (minRemoved && maxRemoved)
                break;
            int minSize = Math.Min(minIndex - left, right - minIndex);
            int maxSize = Math.Min(maxIndex - left, right - maxIndex);
            if ((!minRemoved && minSize <= maxSize) || maxRemoved)
            {
                if (minIndex - left < right - minIndex)
                {
                    total += minIndex - left + 1;
                    left = minIndex + 1;
                }
                else
                {
                    total += right - minIndex + 1;
                    right = minIndex - 1;
                }
                minRemoved = true;
            }
            else if ((!maxRemoved && minSize > maxSize) || minRemoved)
            {
                if (maxIndex - left < right - maxIndex)
                {
                    total += maxIndex - left + 1;
                    left = maxIndex + 1;
                }
                else
                {
                    total += right - maxIndex + 1;
                    right = maxIndex - 1;
                }
                maxRemoved = true;
            }
        }
        return total;
    }
}