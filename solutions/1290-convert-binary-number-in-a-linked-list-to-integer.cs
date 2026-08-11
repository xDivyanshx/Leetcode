// 1290. Convert Binary Number in a Linked List to Integer
// Difficulty: Easy
// https://leetcode.com/problems/convert-binary-number-in-a-linked-list-to-integer/
// Runtime: 0 ms | Memory: 41.7 MB | Submitted: 2025-07-14

public class Solution
{
    public int GetDecimalValue(ListNode head)
    {
        int res = 0;
        while (head != null)
        {
            res = (res << 1 )+ head.val;
            head = head.next;
        }
        return res;
    }
}