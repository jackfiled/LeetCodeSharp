// [19] Remove Nth Node From End of List

using LeetCodeSharp.Utils;

namespace LeetCodeSharp.Problems19
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
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var dummyNode = new ListNode(-1)
            {
                next = head
            };

            var precursor = dummyNode;
            var now = head;
            var count = 0;

            while (now.next != null)
            {
                if (count < n - 1)
                {
                    count += 1;
                }
                else
                {
                    precursor = precursor.next;
                }

                now = now.next;
            }

            precursor.next = precursor.next.next;

            return dummyNode.next;
        }
    }

    // Submission codes end here
}