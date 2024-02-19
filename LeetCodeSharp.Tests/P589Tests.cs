using LeetCodeSharp.Problems589;
using LeetCodeSharp.Utils;

namespace LeetCodeSharp.Tests;

public class P589Tests
{
    [Fact]
    public void Test1()
    {
        Node root = new Node(1, [
            new Node(3),
            new Node(2),
            new Node(4),
            ]);

        IList<int> except = [1, 3, 2, 4];

        var solution = new Solution();
        Assert.Equal(except, solution.Preorder(root));
    }
}