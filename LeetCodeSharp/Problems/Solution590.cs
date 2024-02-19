/**
* [N-ary Tree Postorder Traversal] 590
*/

using System.Collections.Generic;
using LeetCodeSharp.Utils;

namespace LeetCodeSharp.Problems590
{

    // Submission codes start here

    /*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

    public class Solution
    {
        public IList<int> Postorder(Node root)
        {
            var dfs = new Dfs();

            dfs.Search(root);
            return dfs.Result;
        }

        private class Dfs
        {
            public IList<int> Result { get; } = new List<int>();

            public void Search(Node node)
            {
                if (node == null) return;

                foreach (var child in node.children)
                {
                    Search(child);
                }

                Result.Add(node.val);
            }
        }
    }

    // Submission codes end here
}