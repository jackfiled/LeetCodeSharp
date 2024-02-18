using System.Text.Json.Serialization;

namespace LeetCodeSharp.Fetcher.Models;

internal class Stat
{
    public required uint QuestionId { get; set; }

    [JsonPropertyName("question__article_slug")]
    public string? QuestionArticleSlug { get; set; }

    [JsonPropertyName("question__title")]
    public string? QuestionTitle { get; set; }

    [JsonPropertyName("question__title_slug")]
    public string? QuestionTitleSlug { get; set; }

    [JsonPropertyName("question__hide")]
    public bool QuestionHide { get; set; }

    public required uint TotalAcs { get; set; }
    
    public required uint TotalSubmitted { get; set; }

    public required string FrontendQuestionId { get; set; }

    public required bool IsNewQuestion { get; set; }
}

internal class StatWithStatus
{
    public required Stat Stat { get; set; }

    public required bool PaidOnly { get; set; }
}