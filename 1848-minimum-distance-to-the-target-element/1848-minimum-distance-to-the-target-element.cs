public class Solution
{
    public int GetMinDistance(int[] nums, int target, int start)
    {
        int minDistance = int.MaxValue;
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == target)
            {
                int temp = Math.Abs(i - start);
                if (temp < minDistance)
                {
                    minDistance = temp;
                }
            }
        }
        return minDistance;
    }
}