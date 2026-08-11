public class Solution
{
    public int[] TwoSum(int[] numbers, int target)
    {
        int startPointer = 0;
        int endPointer = numbers.Length - 1;

        while (numbers[startPointer] + numbers[endPointer] != target)
        {
            int sum = numbers[startPointer] + numbers[endPointer];
            if (sum > target)
                endPointer--;
            else
                startPointer++;
        }

        return [startPointer + 1, endPointer + 1];
    }
}