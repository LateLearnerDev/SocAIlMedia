using Domain.Entities.Messages.Config;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities.Messages;

[EntityTypeConfiguration(typeof(MessageEntityTypeConfig))]
public class Message
{
    public int Id { get; set; }
    
    public DateTime DateTimeOf { get; set; }
    public string Role { get; set; }
    public string Text { get; set; }
    
    public int ConversationId { get; set; }
    public virtual Conversation Conversation { get; set; }

    public static Message Create(string role, string text) =>
        new()
        {
            DateTimeOf = DateTime.Now,
            Role = role,
            Text = text
        };
}