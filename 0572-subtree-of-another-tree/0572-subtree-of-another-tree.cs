public class Solution 
{
    public bool IsSubtree(TreeNode root, TreeNode subRoot) 
    {
        // Base case: If the main tree branch ends, we didn't find the subRoot
        if (root == null) 
        {
            return false;
        }

        // 1. Validation: Ask our helper method if the current node is a perfect match
        if (IsIdentical(root, subRoot)) 
        {
            return true;
        }

        // 2. Searching: If it isn't a match, recursively move down both sides 
        // to check the rest of the nodes
        bool foundInLeft = IsSubtree(root.left, subRoot);
        bool foundInRight = IsSubtree(root.right, subRoot);

        return foundInLeft || foundInRight;
    }

    private bool IsIdentical(TreeNode node1, TreeNode node2) 
    {
        // If both nodes hit null at the exact same time, this path is identical
        if (node1 == null && node2 == null) 
        {
            return true;
        }

        // If one node is null and the other isn't, the structure is broken
        if (node1 == null || node2 == null) 
        {
            return false;
        }

        // If the actual integer values do not match, it is not the same tree
        if (node1.val != node2.val) 
        {
            return false;
        }

        // The current nodes match. Now strictly enforce that their children match.
        bool isLeftIdentical = IsIdentical(node1.left, node2.left);
        bool isRightIdentical = IsIdentical(node1.right, node2.right);

        return isLeftIdentical && isRightIdentical;
    }
}