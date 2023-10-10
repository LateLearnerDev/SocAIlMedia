using Application.Scopes.ChatAi.Models;

namespace Application.Scopes.Conversations.Dtos;

public class AiResponseDto
{
    public string? Response { get; set; }
    public string? Role { get; set; }
    public double TokenCost { get; set; }

    public static AiResponseDto From(ChatApiResponse apiResponse)
    {
        return new()
        {
            Response = apiResponse.Choices.FirstOrDefault()?.Message.Content,
            Role = apiResponse.Choices.FirstOrDefault()?.Message.Role,
            TokenCost = apiResponse.Usage.TotalPrice
        };
    }
}