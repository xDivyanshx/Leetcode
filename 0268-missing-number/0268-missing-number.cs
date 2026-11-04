public class Solution {
    public int MissingNumber(int[] nums) {
        int sum = 0;

        foreach (int x in nums)
        {
            sum += x;
        }

        int n = nums.Length;
        int expectedSum = (n * (n + 1)) / 2;

        return expectedSum - sum;
    }
}