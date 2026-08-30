public class Solution
{
    public int FindMin(int[] nums)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (left < right)
        {
            int mid = left + (right - left) / 2;
            int element = nums[mid];

            if (element > nums[right])
            {
                // The minimum is strictly in the right half, and cannot be 'mid'
                left = mid + 1;
            }
            else
            {
                // The right half is sorted. 'mid' is the smallest in the right half.
                // The true minimum is either 'mid' itself, or somewhere to its left.
                right = mid;
            }
        }

        // When left == right, the loop breaks and you have found the minimum
        return nums[left];
    }
}