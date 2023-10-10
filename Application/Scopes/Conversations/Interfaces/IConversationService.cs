using Application.Scopes.ChatAi.Models;
using Domain.Entities.Messages;

namespace Application.Scopes.Conversations.Interfaces;

public interface IConversationService
{
    public Task<Conversation?> StartConversationAsync(string context, string initialMessage, string response,
        string userRole, string responseRole);

    public Task ContinueConversationAsync(int conversationId, List<ChatAiMessage> messages);

    public Task<Conversation?> GetConversationAsync(int conversationId);
    public Task<List<Conversation?>> GetAllConversationsAsync();
}