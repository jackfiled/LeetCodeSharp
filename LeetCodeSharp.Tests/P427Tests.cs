namespace LeetCodeSharp.Tests;

using LeetCodeSharp.Problems427;

public class P427Tests
{
    [Fact]
    public void Test1()
    {
        int[][] grid = [[0, 1], [1, 0]];

        Solution solution = new();
        Node root = solution.Construct(grid);

        Assert.False(root.isLeaf);
    }
}