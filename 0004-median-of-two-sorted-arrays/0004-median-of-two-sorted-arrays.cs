public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int[] totalArray = new int[nums1.Length + nums2.Length];

        int ptr1 = 0, ptr2 = 0;
        int index = 0;


        int pointToStop = totalArray.Length / 2;

        while (ptr1 < nums1.Length && ptr2 < nums2.Length)
        {
            if (nums1[ptr1] < nums2[ptr2])
            {
                totalArray[index++] = nums1[ptr1++];
            }
            else
            {
                totalArray[index++] = nums2[ptr2++];
            }
            if (index > pointToStop)
                break;
        }

        while (ptr1 < nums1.Length)
        {
            totalArray[index++] = nums1[ptr1++];
            if (index > pointToStop)
                break;
        }

        while (ptr2 < nums2.Length)
        {
            totalArray[index++] = nums2[ptr2++];
            if (index > pointToStop)
                break;
        }

        if (totalArray.Length % 2 == 0)
        {
            int low = totalArray[(totalArray.Length - 1) / 2];
            int high = totalArray[(totalArray.Length) / 2];
            return (double)(low + high) / 2;
        }
        else
        {
            return totalArray[(totalArray.Length - 1) / 2];
        }
    }
}