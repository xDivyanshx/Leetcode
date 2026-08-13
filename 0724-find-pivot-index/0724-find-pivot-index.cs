public class Solution
{
    public int PivotIndex(int[] nums)
    {
        int totalSum = 0;
        foreach (int num in nums)
        {
            totalSum += num;
        }

        int leftSum = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            // Check if the left side equals the right side algebraically
            if (leftSum * 2 + nums[i] == totalSum)
            {
                return i;
            }

            // Add the current number to the left sum for the next iteration
            leftSum += nums[i];
        }

        return -1;
    }
}