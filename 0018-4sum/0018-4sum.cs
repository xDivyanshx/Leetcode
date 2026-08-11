public class Solution
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {

        Array.Sort(nums);

        IList<IList<int>> result = new List<IList<int>>();

        for (int j = 0; j < nums.Length; j++)
        {
            if (j > 0 && nums[j] == nums[j - 1])
                continue;

            for (int i = j + 1; i < nums.Length; i++)
            {
                if (i > j + 1 && nums[i] == nums[i - 1])
                    continue;

                int startPointer = i + 1;
                int endPointer = nums.Length - 1;

                while (startPointer < endPointer)
                {
                    long sum = (long)nums[startPointer] + nums[endPointer] + nums[i] + nums[j];
                    if (sum > target)
                        endPointer--;
                    else if (sum < target)
                        startPointer++;
                    else
                    {
                        result.Add([nums[startPointer], nums[endPointer], nums[i], nums[j]]);
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
        }
        return result;
    }
}

