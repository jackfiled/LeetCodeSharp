using System.Net.Http.Json;
using System.Text.Json;
using LeetCodeSharp.Fetcher.Models;

namespace LeetCodeSharp.Fetcher;

internal class Fetcher
{
    private const string ProblemsUrl = "https://leetcode.cn/api/problems/algorithms/";
    private const string GraphQlUrl = "https://leetcode.cn/graphql";

    private readonly HttpClient _httpClient = new();

    private readonly JsonSerializerOptions _serializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };

    public async Task<Problems> GetProblems()
    {
        var problems =
            await _httpClient.GetFromJsonAsync<Problems>(ProblemsUrl, _serializerOptions)
                ?? throw new Exception("Failed to get problems.");

        return problems;
    }

    public async Task<Problem> GetProblem(uint questionId)
    {
        var problems = await GetProblems();

        var targetProblem = problems.StatStatusPairs.First(p =>
        {
            if (uint.TryParse(p.Stat.FrontendQuestionId, out var id))
            {
                return id == questionId;
            }

            return false;
        });

        if (targetProblem.PaidOnly)
        {
            throw new Exception("Target problem is paid only.");
        }

        if (targetProblem.Stat.QuestionTitleSlug is null)
        {
            throw new Exception("Failed to get problem title.");
        }

        var query = new Query(targetProblem.Stat.QuestionTitleSlug);
        var response = await _httpClient.PostAsJsonAsync(
            GraphQlUrl, query, _serializerOptions);
        response.EnsureSuccessStatusCode();

        var rawProblem = await JsonSerializer.DeserializeAsync<RawProblem>(
                             await response.Content.ReadAsStreamAsync(), _serializerOptions)
                         ?? throw new Exception("Failed to get raw problem.");

        var returnType = rawProblem.Data.Question.MetaData.Replace("\"", "");

        return new Problem
        {
            Title = targetProblem.Stat.QuestionTitle
                    ?? throw new Exception("Failed to get question title"),
            TitleSlug = targetProblem.Stat.QuestionTitleSlug
                        ?? throw new Exception("Failed to get question title slug"),
            Content = rawProblem.Data.Question.Content,
            QuestionId = questionId,
            ReturnType = returnType,
            CodeDefinition = JsonSerializer.Deserialize<List<CodeDefinition>>(
                                 rawProblem.Data.Question.CodeDefinition, _serializerOptions)
                             ?? throw new Exception("Failed to get code definition.")
        };
    }


}

