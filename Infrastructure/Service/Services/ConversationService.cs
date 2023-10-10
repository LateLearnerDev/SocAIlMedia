using Application.Scopes.ChatAi.Models;
using Application.Scopes.Conversations.Interfaces;
using Domain.Entities.Messages;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Message = Domain.Entities.Messages.Message;

namespace Infrastructure.Service.Services;

public class ConversationService : IConversationService
{
    private readonly SolcailMedialDbContext _context;

    public ConversationService(SolcailMedialDbContext context)
    {
        _context = context;
    }

    public async Task<Conversation?> StartConversationAsync(string context, string initialMessage, string response,
        string userRole, string responseRole)
    {
        var conversation = Conversation.Create(context, userRole, initialMessage, responseRole, response);
        await _context.Conversations.AddAsync(conversation);
        await _context.SaveChangesAsync();

        return conversation;
    }

    public async Task ContinueConversationAsync(int conversationId, List<ChatAiMessage> messages)
    {
        var conversation = await _context.Conversations.FindAsync(conversationId);
        var chats = messages.Select(x => Message.Create(x.Role, x.Content));
        conversation?.Messages.AddRange(chats);
        await _context.SaveChangesAsync();
    }

    public async Task<Conversation?> GetConversationAsync(int conversationId) => 
        await _context.Conversations.FindAsync(conversationId);

    public async Task<List<Conversation?>> GetAllConversationsAsync() => 
        await _context.Conversations.ToListAsync();
}