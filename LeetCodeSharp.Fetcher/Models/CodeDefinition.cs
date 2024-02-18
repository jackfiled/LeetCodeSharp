using System.Text.Json.Serialization;

namespace LeetCodeSharp.Fetcher.Models;

internal class CodeDefinition
{
    public required string Value { get; set; }

    public required string Text { get; set; }

    [JsonPropertyName("defaultCode")]
    public required string DefaultCode { get; set; }
}