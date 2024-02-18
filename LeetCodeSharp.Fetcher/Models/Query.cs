using System.Text.Json.Serialization;

namespace LeetCodeSharp.Fetcher.Models;

internal class Query
{
    [JsonPropertyName("operationName")]
    public string OperationName { get; init; }

    public Dictionary<string, string> Variables { get; } = [];

    [JsonPropertyName("query")]
    public string QueryString { get; init; }

    public Query(string title)
    {
        OperationName = "questionData";
        Variables.Add("titleSlug", title);
        QueryString = """
                      query questionData($titleSlug: String!) {
                          question(titleSlug: $titleSlug) {
                              content
                              stats
                              codeDefinition
                              sampleTestCase
                              metaData
                          }
                      }
                      """;
    }
}