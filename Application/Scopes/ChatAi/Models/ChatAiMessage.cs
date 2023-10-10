using System.Text.Json.Serialization;

namespace Application.Scopes.ChatAi.Models;

public class ChatAiMessage
{
    [JsonPropertyName("role")]
    public string Role { get; set; }
    
    [JsonPropertyName("content")]
    public string Content { get; set; }
}