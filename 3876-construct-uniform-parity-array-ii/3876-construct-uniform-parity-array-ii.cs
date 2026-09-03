public class Solution
{
    public bool UniformArray(int[] nums1)
    {
        // we need a smaller odd number for a number to subtract from it and change its parity
        // try to make it all even
        // for that if there is any odd number - impossible to make it all even
        // so it should already be all even

        // try to make it all odd
        // if its all odd already very good
        // if any even we would need an odd to veen make it odd, hence the smallest should not be even

        // so
        // if all even - true
        // if all odd - true
        // if combination and smallest is odd - true
        // else false

        bool allEven = true;
        bool allOdd = true;

        for (int i = 0; i < nums1.Length; i++)
        {
            if (nums1[i] % 2 == 0)
            {
                allOdd = false;
            }
            else
            {
                allEven = false;
            }
            if (!allOdd && !allEven)
                break;
        }

        if (allOdd || allEven)
            return true;

        Array.Sort(nums1);

        if (nums1[0] % 2 == 0)
        {
            return false;
        }
        else return true;
    }
}