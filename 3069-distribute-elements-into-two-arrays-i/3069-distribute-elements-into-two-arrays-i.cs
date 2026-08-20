public class Solution
{
    public int[] ResultArray(int[] nums)
    {
        int[] resultantArray = new int[nums.Length];
        int[] temporaryArray = new int[nums.Length];
        resultantArray[0] = nums[0];
        temporaryArray[0] = nums[1];

        int arr1Pointer = 0;
        int arr2Pointer = 0;

        for (int i = 2; i < nums.Length; i++)
        {
            if (resultantArray[arr1Pointer] > temporaryArray[arr2Pointer])
            {
                resultantArray[++arr1Pointer] = nums[i];
            }
            else
                temporaryArray[++arr2Pointer] = nums[i];
        }

        for (int i = 0; i <= arr2Pointer; i++)
        {
            resultantArray[arr1Pointer + i + 1] = temporaryArray[i];
        }

        return resultantArray;
    }
}