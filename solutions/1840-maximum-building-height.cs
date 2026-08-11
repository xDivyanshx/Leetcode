// 1840. Maximum Building Height
// Difficulty: Hard
// https://leetcode.com/problems/maximum-building-height/
// Runtime: 50 ms | Memory: 93.5 MB | Submitted: 2026-06-20

using System;

public class Solution
{
    public int MaxBuilding(int n, int[][] restrictions)
    {
        // Adding 1st building with 0 restriction
        // We are guaranteed it is not already present
        // Last building could be present, if not present, add it with its virtual restriction of n-1

        // blindly adding both the restrictions because first is onvously not present, and even if second is present, after sorting it would be next to the existing one
        // and left to right traversal would fix the height ot existing one
        Array.Resize(ref restrictions, restrictions.Length + 2);
        restrictions[restrictions.Length - 2] = new int[] { 1, 0 };
        restrictions[restrictions.Length - 1] = new int[] { n, n - 1 };

        // Sorting based on building id
        Array.Sort(restrictions, (a, b) => a[0].CompareTo(b[0]));

        LeftRightTraversal(restrictions);

        return RightLeftTraversal(restrictions);
    }

    // Looping over left to right, and fixing restrictions that are out of order
    // eg. [1,1], [2,5] does not make sense, as increment can be by 1 only, 2nd building cant be greater than 2
    private static void LeftRightTraversal(int[][] restrictions)
    {
        for (int i = 1; i < restrictions.Length; i++)
        {
            int buildingId = restrictions[i][0];
            int maxHeight = restrictions[i][1];
            int previousBuildingId = restrictions[i - 1][0];
            int previousMaxHeight = restrictions[i - 1][1];
            int maxPossibleHeight = previousMaxHeight + (buildingId - previousBuildingId);
            if (maxHeight > maxPossibleHeight)
            {
                restrictions[i][1] = maxPossibleHeight;
            }
        }
    }

    // Between two building with some restrictions
    // Max possible height is H, and its difference to the left would be H-HL, and difference to the right would be H-HR
    // so (H-HL)+(H-HR) should be <= d (distance between thhe two buildings)
    // similying this, it becomes H <= (HR+HL+d)/2
    // as question says it needs to be integer, we can use floor and thus the formula (HR+HL+d)/2
    private static int RightLeftTraversal(int[][] restrictions)
    {
        int maxHeightPossible = -1;
        for (int i = restrictions.Length - 2; i >= 0; i--)
        {
            int buildingId = restrictions[i][0];
            int maxHeight = restrictions[i][1];
            int nextBuildingId = restrictions[i + 1][0];
            int nextMaxHeight = restrictions[i + 1][1];
            int maxPossibleHeight = nextMaxHeight + (nextBuildingId - buildingId);
            if (maxHeight > maxPossibleHeight)
            {
                restrictions[i][1] = maxPossibleHeight;
                maxHeight = maxPossibleHeight;
            }

            int max = (nextMaxHeight + maxHeight + (nextBuildingId - buildingId)) / 2;
            if (max > maxHeightPossible)
                maxHeightPossible = max;
        }
        return maxHeightPossible;
    }
}
