using Application.Scopes.ChatAi.Models;
using Application.Scopes.Conversations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SocAilMedia.Web.Controllers;

public class ConversationController : BaseApiController
{
    private readonly IConfiguration _configuration;

    public ConversationController(IConfiguration configuration, IMediator mediator) : base(mediator) => 
        _configuration = configuration;

    [HttpPost("StartConversation")]
    public async Task<IActionResult> StartConversation(string message, string context)
    {
        if (string.IsNullOrWhiteSpace(message))
            return BadRequest("Please provide a valid message");

        return Ok(await Mediator.Send(new StartConversation.Query
        {
            Endpoint = _configuration.GetSection("GptApiUrl").Value ?? "",
            Model = _configuration.GetSection("GptModel").Value ?? "",
            Key = _configuration.GetSection("OpenAiKey").Value ?? "",
            Messages = new List<ChatAiMessage> {new() {Content = message, Role = "user"}},
            Context = context,
            InitialMessage = message,
            UserRole = "user"
        })); 
    }

    [HttpPost("ContinueConversation")]
    public async Task<IActionResult> ContinueConversation(string message, int conversationId)
    {
        if (string.IsNullOrWhiteSpace(message))
            return BadRequest("Please provide a valid message");

        await Mediator.Send(new ContinueConversation.Query
            {
                Endpoint = _configuration.GetSection("GptApiUrl").Value ?? "",
                Model = _configuration.GetSection("GptModel").Value ?? "",
                Key = _configuration.GetSection("OpenAiKey").Value ?? "",
                ConversationId = conversationId,
                UserMessage = message
            });

        return Ok("Conversation Saved"); // incomplete
    }

    [HttpGet("GetAllConversations")]
    public async Task<IActionResult> GetAllConversations()
    {
        var result = await Mediator.Send(new GetAllConversations.Query());
        return Ok(result);
    }
}