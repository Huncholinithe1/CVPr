using System.Text.Json;

namespace CVProfile.Web.Services;

public class GitHubRepository
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string HtmlUrl { get; set; } = string.Empty;
    public string Language { get; set; } = string.Empty;
    public int StargazersCount { get; set; }
}

public interface IGitHubService
{
    Task<List<GitHubRepository>> GetUserRepositoriesAsync(string username);
}

public class GitHubService : IGitHubService
{
    private readonly HttpClient _httpClient;

    public GitHubService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "CVProfile");
    }

    public async Task<List<GitHubRepository>> GetUserRepositoriesAsync(string username)
    {
        try
        {
            var response = await _httpClient.GetAsync($"https://api.github.com/users/{username}/repos");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var repositories = JsonSerializer.Deserialize<List<GitHubRepository>>(content, 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return repositories ?? new List<GitHubRepository>();
        }
        catch (Exception)
        {
            return new List<GitHubRepository>();
        }
    }
} 