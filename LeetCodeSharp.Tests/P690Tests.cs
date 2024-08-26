using LeetCodeSharp.Problems690;

namespace LeetCodeSharp.Tests;

public class P690Tests
{
    [Fact]
    public void Test1()
    {
        var solution = new Solution();
        Assert.Equal(11,
            solution.GetImportance([
                new Employee(1, 5, [2, 3]),
                new Employee(2, 3, []),
                new Employee(3, 3, [])
            ], 1));
    }
}