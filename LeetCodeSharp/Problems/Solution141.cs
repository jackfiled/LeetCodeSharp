// [141] Linked List Cycle

using System.Collections.Generic;
using LeetCodeSharp.Utils;

namespace LeetCodeSharp.Problems141
{
    // Submission codes start here

    /**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
    public class Solution
    {
        private readonly HashSet<ListNode> _visited = new HashSet<ListNode>();

        public bool HasCycle(ListNode head)
        {
            _visited.Clear();
            ListNode node = head;

            while (node != null)
            {
                if (_visited.Contains(node))
                {
                    return true;
                }

                _visited.Add(node);
                node = node.next;
            }

            return false;
        }
    }

    // Submission codes end here
}