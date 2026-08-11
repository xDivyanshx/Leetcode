// 2. Add Two Numbers
// Difficulty: Medium
// https://leetcode.com/problems/add-two-numbers/
// Runtime: 1 ms | Memory: 53.5 MB | Submitted: 2025-04-02

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        int carry = 0;
        ListNode head = new ListNode();
        ListNode current = head;
        while ( l1 != null || l2 != null  || carry !=0)
        {
            int sum = carry;
            if (l1 != null)
            {
                sum += l1.val;
                l1 = l1.next;
            }
            if (l2 != null)
            {
                sum += l2.val;
                l2 = l2.next;
            }
            carry = sum / 10;
            current.next = new ListNode(sum % 10);
            current = current.next;
        }
        return head.next;
    }
}