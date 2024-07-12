// [23] Merge k Sorted Lists

using LeetCodeSharp.Utils;

namespace LeetCodeSharp.Problems23
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
        private ListNode MergeTwoLists(ListNode a, ListNode b)
        {
            if (a == null || b == null)
            {
                return a ?? b;
            }

            var dummyHead = new ListNode();
            var node = dummyHead;

            while (a != null && b != null)
            {
                if (a.val < b.val)
                {
                    node.next = a;
                    a = a.next;
                }
                else
                {
                    node.next = b;
                    b = b.next;
                }

                node = node.next;
            }

            node.next = a ?? b;

            return dummyHead.next;
        }

        private ListNode Merge(ListNode[] lists, int l, int r)
        {
            if (l == r)
            {
                return lists[l];
            }

            if (l > r)
            {
                return null;
            }

            var middle = (l + r) / 2;

            return MergeTwoLists(Merge(lists, l, middle), Merge(lists, middle + 1, r));
        }

        public ListNode MergeKLists(ListNode[] lists)
        {
            return Merge(lists, 0, lists.Length - 1);
        }
    }

    // Submission codes end here
}