using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Application.Scopes.ChatAi.Interfaces;
using Application.Scopes.ChatAi.Models;

namespace Infrastructure.Service.ExternalServices;

public class ChatAiService : IChatAiService
{
    public async Task<ChatApiResponse> GetResponseAsync(string endpoint, string model, string key,
        CancellationToken cancellationToken, List<ChatAiMessage> messages)
    {
        var requestBody = new
        {
            model,
            messages
        };

        var requestBodyJson = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(requestBodyJson, Encoding.UTF8, "application/json");

        var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", key);
        var response = await httpClient.PostAsync(endpoint, content, cancellationToken);
        var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);

        var responseData = JsonSerializer.Deserialize<ChatApiResponse>(responseContent);

        return responseData;
    }
}