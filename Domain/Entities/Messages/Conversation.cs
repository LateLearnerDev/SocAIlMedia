using Domain.Entities.Messages.Config;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities.Messages;

[EntityTypeConfiguration(typeof(ConversationEntityTypeConfig))]
public class Conversation
{
    public int Id { get; set; }
    public string Context { get; set; }

    public virtual List<Message> Messages { get; set; } = new();

    public static Conversation? Create(string context, string userRole, string initialMessage, string responseRole, string responseMessage)
    {
        return new()
        {
            Context = context,
            Messages = new()
            {
                Message.Create(userRole, initialMessage),
                Message.Create(responseRole, responseMessage),
            }
        };
    }
}