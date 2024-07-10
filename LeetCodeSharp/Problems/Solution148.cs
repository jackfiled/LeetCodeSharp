// [148] Sort List

using System.Collections.Generic;
using LeetCodeSharp.Utils;

namespace LeetCodeSharp.Problems148
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
public class Solution {
    public ListNode SortList(ListNode head)
    {
        var array = new List<int>();

        while (head != null)
        {
            array.Add(head.val);

            head = head.next;
        }

        array.Sort();

        var dummyHead = new ListNode();
        var node = dummyHead;

        foreach (var i in array)
        {
            var newNode = new ListNode(i);
            node.next = newNode;
            node = newNode;
        }

        return dummyHead.next;
    }
}

    // Submission codes end here
}