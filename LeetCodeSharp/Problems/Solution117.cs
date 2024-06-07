// [117] Populating Next Right Pointers in Each Node II

using System.Collections.Generic;

namespace LeetCodeSharp.Problems117
{
    // Submission codes start here

// Definition for a Node.
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node()
        {
        }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }

    public class Solution
    {
        public Node Connect(Node root)
        {
            var queue = new Queue<Node>();

            if (root != null)
            {
                queue.Enqueue(root);
            }

            while (queue.Count != 0)
            {
                var length = queue.Count;

                for (var i = 0; i < length; i++)
                {
                    var node = queue.Dequeue();

                    if (i != length - 1)
                    {
                        node.next = queue.Peek();
                    }

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
            }

            return root;
        }
    }

    // Submission codes end here
}