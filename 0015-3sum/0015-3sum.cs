public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);

        IList<IList<int>> result = new List<IList<int>>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
                continue;

            int target = -1 * nums[i];

            int startPointer = i + 1;
            int endPointer = nums.Length - 1;

            while (startPointer < endPointer)
            {
                int sum = nums[startPointer] + nums[endPointer];
                if (sum > target)
                    endPointer--;
                else if (sum < target)
                    startPointer++;
                else
                {
                    result.Add([nums[startPointer], nums[endPointer], -1 * target]);
                    int currentStart = nums[startPointer];
                    int currentEnd = nums[endPointer];
                    while (nums[startPointer] == currentStart && startPointer < endPointer)
                    {
                        startPointer++;
                    }
                    while (nums[endPointer] == currentEnd && startPointer < endPointer)
                    {
                        endPointer--;
                    }
                }
            }


        }
        return result;
    }
}