using DTO;

namespace Frontend.Data;

public class HttpClientService(IHttpClientFactory httpClientFactory)
{
    private HttpClient _httpClient = httpClientFactory.CreateClient("backend");

    public async Task<List<Match>> GetMatches()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<List<Match>>("/matches");
            return response;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e);
            return [];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task PostMatchAsync(Match match)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("/match", match);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        } 
    }
}