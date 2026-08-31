public class Solution
{
    public int[] NodesBetweenCriticalPoints(ListNode head)
    {
        int firstCriticalIndex = -1;
        int previousCriticalIndex = -1;
        int minDistance = int.MaxValue;

        ListNode previousNode = null;
        int i = 0;

        while (head != null)
        {
            i++;
            if (previousNode != null && head.next != null)
            {
                int currentValue = head.val;
                int previousValue = previousNode.val;
                int nextValue = head.next.val;

                // Check if it is a critical point
                if ((currentValue < previousValue && currentValue < nextValue) || 
                    (currentValue > previousValue && currentValue > nextValue))
                {
                    // If this is the very first critical point we've found
                    if (firstCriticalIndex == -1)
                    {
                        firstCriticalIndex = i;
                    }
                    else
                    {
                        // Calculate the distance from the previous critical point
                        int currentDistance = i - previousCriticalIndex;
                        if (currentDistance < minDistance)
                        {
                            minDistance = currentDistance;
                        }
                    }
                    
                    // Update the previous index to the current one for the next iteration
                    previousCriticalIndex = i;
                }
            }
            
            previousNode = head;
            head = head.next;
        }

        // If we found fewer than 2 critical points, return [-1, -1]
        if (firstCriticalIndex == -1 || firstCriticalIndex == previousCriticalIndex)
        {
            return new int[] { -1, -1 };
        }

        int maxDistance = previousCriticalIndex - firstCriticalIndex;
        
        return new int[] { minDistance, maxDistance };
    }
}