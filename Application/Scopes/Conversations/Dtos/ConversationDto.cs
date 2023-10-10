using Domain.Entities.Messages;

namespace Application.Scopes.Conversations.Dtos;

public class ConversationDto
{
    public List<MessageDto>? Messages { get; set; }

    public static ConversationDto From(Conversation? conversation) =>
        new()
        {
            Messages = conversation.Messages
                .OrderBy(x => x.DateTimeOf)
                .Select(MessageDto.From).ToList()
        };
}

public class MessageDto
{
    public string Message { get; set; }
    public string Role { get; set; }

    internal static MessageDto From(Message message) =>
        new()
        {
            Message = message.Text,
            Role = message.Role
        };
}