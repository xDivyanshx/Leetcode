public class Solution
{
    public int PivotIndex(int[] nums)
    {
        int sum = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            sum += nums[i];
        }
        int pivot = -1;
        int leftSum = 0;
        int rightSum = sum;
        for (int i = 0; i < nums.Length; i++)
        {
            if (leftSum == rightSum)
            {
                pivot = i;
                break;
            }
            else
            {
                leftSum += nums[i];
                if (i == nums.Length - 1)
                {
                    rightSum = 0;
                }
                else
                    rightSum -= nums[i + 1];
            }
        }
        return pivot;
    }
}