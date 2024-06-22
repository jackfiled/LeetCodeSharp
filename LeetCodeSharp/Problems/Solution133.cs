// [133] Clone Graph


using System.Collections.Generic;

namespace LeetCodeSharp.Problems133
{
    // Submission codes start here

    public class Node
    {
        public int val;
        public IList<Node> neighbors;

        public Node()
        {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val)
        {
            val = _val;
            neighbors = new List<Node>();
        }

        public Node(int _val, List<Node> _neighbors)
        {
            val = _val;
            neighbors = _neighbors;
        }
    }

    public class Solution
    {
        private readonly HashSet<int> _visited = new HashSet<int>();

        public Node CloneGraph(Node node)
        {
            if (node == null)
            {
                return null;
            }

            var map = new Dictionary<int, Node>();

            _visited.Clear();
            FindAllNode(map, node);
            _visited.Clear();
            ReplaceAllNode(map, node);

            return map[node.val];
        }

        private void FindAllNode(Dictionary<int, Node> map, Node node)
        {
            if (_visited.Contains(node.val))
            {
                return;
            }

            _visited.Add(node.val);
            map[node.val] = new Node(node.val);

            foreach (var neighbor in node.neighbors)
            {
                map[neighbor.val] = new Node(neighbor.val);
                FindAllNode(map, neighbor);
            }
        }

        private void ReplaceAllNode(Dictionary<int, Node> map, Node node)
        {
            if (_visited.Contains(node.val))
            {
                return;
            }

            _visited.Add(node.val);
            var newNode = map[node.val];

            foreach (var neighbor in node.neighbors)
            {
                newNode.neighbors.Add(map[neighbor.val]);
                ReplaceAllNode(map, neighbor);
            }
        }
    }

    // Submission codes end here
}