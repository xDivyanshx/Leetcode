public class Solution
{
    public int MinimumDeletions(int[] nums)
    {
        int length = nums.Length;
        
        if (length <= 2)
        {
            return length;
        }

        int minElement = nums[0];
        int maxElement = nums[0];
        int minIndex = 0;
        int maxIndex = 0;

        // 1. Single pass to find the exact indices
        for (int i = 1; i < length; i++)
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

        // 2. Identify the left-most and right-most target indices
        int index1 = Math.Min(minIndex, maxIndex);
        int index2 = Math.Max(minIndex, maxIndex);

        // 3. Calculate the three possible removal strategies
        int removeFromFront = index2 + 1;
        int removeFromBack = length - index1;
        int removeBothSides = (index1 + 1) + (length - index2);

        // 4. Return the most efficient path
        int minDeletions = Math.Min(removeFromFront, Math.Min(removeFromBack, removeBothSides));

        return minDeletions;
    }
}