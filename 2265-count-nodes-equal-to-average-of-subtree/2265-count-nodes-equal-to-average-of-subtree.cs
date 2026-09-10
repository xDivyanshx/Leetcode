public class Solution 
{
    // A clean, explicit container to pass data up the tree
    private class SubtreeInfo 
    {
        public int Sum;
        public int Count;

        public SubtreeInfo(int sum, int count) 
        {
            Sum = sum;
            Count = count;
        }
    }

    private int matchingNodes = 0;

    public int AverageOfSubtree(TreeNode root) 
    {
        matchingNodes = 0;
        CalculateSubtree(root);
        return matchingNodes;
    }

    private SubtreeInfo CalculateSubtree(TreeNode node) 
    {
        // Base case: If the node is null, it contributes 0 to the sum and 0 to the count.
        if (node == null) 
        {
            return new SubtreeInfo(0, 0);
        }

        // 1. Get the answers from the bottom (left and right children) first
        SubtreeInfo leftInfo = CalculateSubtree(node.left);
        SubtreeInfo rightInfo = CalculateSubtree(node.right);

        // 2. Calculate the current node's total sum and count
        int currentSum = leftInfo.Sum + rightInfo.Sum + node.val;
        int currentCount = leftInfo.Count + rightInfo.Count + 1;

        // 3. Check if the current node satisfies the problem's condition
        int currentAverage = currentSum / currentCount;
        
        if (currentAverage == node.val) 
        {
            matchingNodes++;
        }

        // 4. Package the data and hand it up to the parent
        return new SubtreeInfo(currentSum, currentCount);
    }
}