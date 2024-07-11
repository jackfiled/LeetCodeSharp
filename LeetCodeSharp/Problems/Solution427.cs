// [427] Construct Quad Tree


namespace LeetCodeSharp.Problems427
{
    // Submission codes start here

    /*
// Definition for a QuadTree node.
public class Node {
    public bool val;
    public bool isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;

    public Node() {
        val = false;
        isLeaf = false;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }

    public Node(bool _val, bool _isLeaf) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }

    public Node(bool _val,bool _isLeaf,Node _topLeft,Node _topRight,Node _bottomLeft,Node _bottomRight) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = _topLeft;
        topRight = _topRight;
        bottomLeft = _bottomLeft;
        bottomRight = _bottomRight;
    }
}
*/
    public class Node
    {
        public bool val;
        public bool isLeaf;
        public Node topLeft;
        public Node topRight;
        public Node bottomLeft;
        public Node bottomRight;

        public Node()
        {
            val = false;
            isLeaf = false;
            topLeft = null;
            topRight = null;
            bottomLeft = null;
            bottomRight = null;
        }

        public Node(bool _val, bool _isLeaf)
        {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = null;
            topRight = null;
            bottomLeft = null;
            bottomRight = null;
        }

        public Node(bool _val, bool _isLeaf, Node _topLeft, Node _topRight, Node _bottomLeft, Node _bottomRight)
        {
            val = _val;
            isLeaf = _isLeaf;
            topLeft = _topLeft;
            topRight = _topRight;
            bottomLeft = _bottomLeft;
            bottomRight = _bottomRight;
        }
    }

    public class Solution
    {
        public Node Construct(int[][] grid)
        {
            var length = grid.Length;

            return ConstructRecursive(grid, 0, 0, length);
        }

        private Node ConstructRecursive(int[][] grid, int startX, int startY, int length)
        {
            if (IsSameGrid(grid, startX, startY, length))
            {
                return new Node(grid[startX][startY] == 1, true);
            }

            var middleX = startX + length / 2;
            var middleY = startY + length / 2;
            var middleLength = length / 2;

            var root = new Node
            {
                topLeft = ConstructRecursive(grid, startX, startY, middleLength),
                topRight = ConstructRecursive(grid, startX, middleY, middleLength),
                bottomLeft = ConstructRecursive(grid, middleX, startY, middleLength),
                bottomRight = ConstructRecursive(grid, middleX, middleY, middleLength)
            };

            return root;
        }

        private bool IsSameGrid(int[][] grid, int startX, int startY, int length)
        {
            var value = grid[startX][startY];

            for (var i = 0; i < length; i++)
            {
                for (var j = 0; j < length; j++)
                {
                    if (grid[startX + i][startY + j] != value)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }

    // Submission codes end here
}