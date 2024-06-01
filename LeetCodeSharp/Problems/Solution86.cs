// [86] Partition List

using LeetCodeSharp.Utils;

namespace LeetCodeSharp.Problems86
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
        public ListNode Partition(ListNode head, int x)
        {
            var dummySmallNode = new ListNode(-1);
            var smallNode = dummySmallNode;
            var dummyBigNode = new ListNode(-1);
            var bigNode = dummyBigNode;

            while (head != null)
            {
                if (head.val < x)
                {
                    smallNode.next = head;
                    smallNode = smallNode.next;
                }
                else
                {
                    bigNode.next = head;
                    bigNode = bigNode.next;
                }

                head = head.next;
            }

            bigNode.next = null;
            smallNode.next = dummyBigNode.next;
            return dummySmallNode.next;
        }
    }

    // Submission codes end here
}