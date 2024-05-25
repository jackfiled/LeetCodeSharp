// [138] Copy List with Random Pointer

using System.Collections.Generic;

namespace LeetCodeSharp.Problems138
{
    // Submission codes start here

    /*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;

    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/
    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }

    public class Solution
    {
        private readonly List<Node> _nodes = new List<Node>();

        public Node CopyRandomList(Node head)
        {
            _nodes.Clear();

            Node newHead = null;
            Node newNow = null;
            Node now = head;

            while (now != null)
            {
                Node newNode = new Node(now.val);
                now.val = _nodes.Count;
                newNode.random = now.random;
                _nodes.Add(newNode);

                if (newHead == null)
                {
                    newHead = newNode;
                    newNow = newNode;
                }
                else
                {
                    newNow.next = newNode;
                    newNow = newNode;
                }

                now = now.next;
            }

            newNow = newHead;

            while (newNow != null)
            {
                if (newNow.random != null)
                {
                    newNow.random = _nodes[newNow.random.val];
                }

                newNow = newNow.next;
            }

            return newHead;
        }
    }

    // Submission codes end here
}