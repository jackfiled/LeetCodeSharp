// [61] Rotate List

using LeetCodeSharp.Utils;

namespace LeetCodeSharp.Problems61
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
        public ListNode RotateRight(ListNode head, int k)
        {
            // 排除链表为空/只有一个节点的情况
            if (head?.next == null)
            {
                return head;
            }

            // 首先将链表连接为环形链表
            var node = head;
            var length = 1;

            while (node.next != null)
            {
                node = node.next;
                length += 1;
            }

            node.next = head;

            var precursor = node;
            var newHead = head;

            for (var i = 0; i < length - k % length; i++)
            {
                newHead = newHead.next;
                precursor = precursor.next;
            }

            // 断开环形链表
            precursor.next = null;
            return newHead;
        }
    }

    // Submission codes end here
}