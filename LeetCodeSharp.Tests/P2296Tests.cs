using LeetCodeSharp.Problems2296;

namespace LeetCodeSharp.Tests;

public sealed class P2296Tests
{
    [Fact]
    public void Test1()
    {
        TextEditor editor = new();

        editor.AddText("leetcode");
        Assert.Equal(4, editor.DeleteText(4));
        editor.AddText("practice");

        Assert.Equal("etpractice", editor.CursorRight(3));
        Assert.Equal("leet", editor.CursorLeft(8));

        Assert.Equal(4, editor.DeleteText(4));
        Assert.Equal(string.Empty, editor.CursorLeft(2));

        Assert.Equal("practi", editor.CursorRight(6));
    }
}