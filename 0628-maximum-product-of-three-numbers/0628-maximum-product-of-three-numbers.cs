public class Solution 
{
    public int MaximumProduct(int[] nums) 
    {
        int min1 = int.MaxValue, min2 = int.MaxValue;
        int max1 = int.MinValue, max2 = int.MinValue, max3 = int.MinValue;

        foreach (int n in nums) 
        {
            // Update Minimums (Smallest and Second Smallest)
            if (n <= min1) 
            {
                min2 = min1; // Old smallest becomes second smallest
                min1 = n;    // New smallest
            } 
            else if (n <= min2) 
            {
                min2 = n;
            }

            // Update Maximums (Largest, Second Largest, Third Largest)
            if (n >= max1) 
            {
                max3 = max2;
                max2 = max1;
                max1 = n;
            } 
            else if (n >= max2) 
            {
                max3 = max2;
                max2 = n;
            } 
            else if (n >= max3) 
            {
                max3 = n;
            }
        }

        // Compare the two mathematical scenarios
        return Math.Max(min1 * min2 * max1, max1 * max2 * max3);
    }
}