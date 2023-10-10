using Application.Scopes.ChatAi.Models;

namespace Application.Scopes.ChatAi.Interfaces;

public interface IChatAiService
{
    public Task<ChatApiResponse> GetResponseAsync(string endpoint, string model, string key,
        CancellationToken cancellationToken, List<ChatAiMessage> messages);
}