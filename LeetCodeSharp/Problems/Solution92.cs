// [92] Reverse Linked List II

using LeetCodeSharp.Utils;

namespace LeetCodeSharp.Problems92
{
    // Submission codes start here

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
    public class Solution
    {
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            var dummyNode = new ListNode(-1);
            dummyNode.next = head;

            var precursor = dummyNode;
            for (var i = 0; i < left - 1; i++)
            {
                precursor = precursor.next;
            }

            var current = precursor.next;

            for (var i = left; i < right; i++)
            {
                var next = current.next;
                current.next = next.next;
                next.next = precursor.next;
                precursor.next = next;
            }

            return dummyNode.next;
        }
    }

    // Submission codes end here
}