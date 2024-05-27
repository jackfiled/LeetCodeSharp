// [25] Reverse Nodes in k-Group

using LeetCodeSharp.Utils;

namespace LeetCodeSharp.Problems25
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
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            var dummyNode = new ListNode(-1)
            {
                next = head
            };

            var precursor = dummyNode;
            var node = dummyNode.next;

            while (node != null)
            {
                var current = node;
                var n = current;
                var count = 0;

                // 先遍历一下看看够不够k个
                while (n != null)
                {
                    count += 1;
                    n = n.next;

                    if (count == k)
                    {
                        break;
                    }
                }

                if (count == k)
                {
                    node = n;
                }
                else
                {
                    break;
                }

                for (var i = 0; i < k - 1; i++)
                {
                    var next = current.next;

                    current.next = next.next;
                    next.next = precursor.next;
                    precursor.next = next;
                }

                precursor = current;
            }

            return dummyNode.next;
        }
    }

    // Submission codes end here
}