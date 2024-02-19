using System.Text;

namespace LeetCodeSharp.Fetcher.Models;

internal class Problem
{
    private const string Template = """
                                    // [__PROBLEM_ID__] __PROBLEM_TITLE__

                                    __EXTRA_USE__
                                    
                                    namespace LeetCodeSharp.Problems__PROBLEM_ID__
                                    {

                                        // Submission codes start here
                                    
                                        __PROBLEM_CODE__
                                    
                                        // Submission codes end here
                                    }
                                    """;

    public required string Title { get; set; }

    public required string TitleSlug { get; set; }

    public required string Content { get; set; }

    public required List<CodeDefinition> CodeDefinition { get; set; }

    public required uint QuestionId { get; set; }

    public required string ReturnType { get; set; }

    public string GetFilename()
    {
        return $"Solution{QuestionId}.cs";
    }

    public string GetFileContent()
    {
        var code = CodeDefinition.FirstOrDefault(c => c.Value == "csharp")
            ?? throw new Exception("Target question has no C# version.");

        string template;
        if (code.DefaultCode.Contains("public class ListNode")
            || code.DefaultCode.Contains("public class Point")
            || code.DefaultCode.Contains("public class TreeNode")
            || code.DefaultCode.Contains("public class Node"))
        {
            template = Template.Replace("__EXTRA_USE__", "using LeetCodeSharp.Utils;");
        }
        else
        {
            template = Template.Replace("__EXTRA_USE__", string.Empty);
        }

        return template.Replace("__PROBLEM_ID__", QuestionId.ToString())
            .Replace("__PROBLEM_TITLE__", Title)
            .Replace("__PROBLEM_CODE__", code.DefaultCode);
    }

    public override string ToString()
    {
        var builder = new StringBuilder();

        builder.Append("Title:").Append(Title).Append("\r\n");
        builder.Append("Title slug: ").Append(TitleSlug).Append("\r\n");
        builder.Append("Code definitions: \r\n");
        foreach (var definition in CodeDefinition)
        {
            builder.Append('\t').Append(definition.Value).Append("\r\n");
        }
        builder.Append("Return type: ").Append(ReturnType).Append("\r\n");

        return builder.ToString();
    }
}