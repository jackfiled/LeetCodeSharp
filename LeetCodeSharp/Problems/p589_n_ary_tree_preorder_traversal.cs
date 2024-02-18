/**
* [N-ary Tree Preorder Traversal] 589
*/


using LeetCodeSharp.Utils;
using System.Collections.Generic;

namespace LeetCodeSharp.Problems
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

    public Node(int _val,IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

    public partial class Solution
    {
        public IList<int> Preorder(Node root)
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

                Result.Add(node.val);

                foreach (var child in node.children)
                {
                    Search(child);
                }
            }
        }
    }

    // Submission codes end here
}