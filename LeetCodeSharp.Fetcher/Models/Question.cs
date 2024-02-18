using System.Text.Json.Serialization;

namespace LeetCodeSharp.Fetcher.Models;

internal class Question
{
    public required string Content { get; set; }

    public required string Stats { get; set; }

    [JsonPropertyName("codeDefinition")]
    public required string CodeDefinition { get; set; }

    [JsonPropertyName("sampleTestCase")]
    public required string SampleTestCase { get; set; }

    [JsonPropertyName("metaData")]
    public required string MetaData { get; set; }
}

internal class Data
{
    public required Question Question { get; set; }
}

internal class RawProblem
{
    public required Data Data { get; set; }
}