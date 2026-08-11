public class Solution
{
    public int MissingInteger(int[] nums)
    {
        int totalSum = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1] + 1)
            {
                totalSum += nums[i];
            }
            else
            {
                break;
            }
        }

        HashSet<int> result = new HashSet<int>(nums);

        for (int i = totalSum; ; i++)
        {
            if (!result.Contains(i))
                return i;
        }
    }
}