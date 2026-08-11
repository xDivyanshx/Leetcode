// 1022. Sum of Root To Leaf Binary Numbers
// Difficulty: Easy
// https://leetcode.com/problems/sum-of-root-to-leaf-binary-numbers/
// Runtime: 0 ms | Memory: 41.9 MB | Submitted: 2026-06-25

public class Solution
{
    public int SumRootToLeaf(TreeNode root)
    {
        return Sum(root, 0);
    }

    private static int Sum(TreeNode node, int currentSum)
    {
        if (node == null)
            return 0;
        currentSum = currentSum * 2 + node.val;
        if (node.right == null && node.left == null)
        {
            return currentSum;
        }
        return Sum(node.right, currentSum) + Sum(node.left, currentSum);
    }
}