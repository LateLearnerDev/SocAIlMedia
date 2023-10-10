using Application.Scopes.ChatAi.Interfaces;
using Application.Scopes.ChatAi.Models;
using Application.Scopes.Conversations.Dtos;
using Application.Scopes.Conversations.Interfaces;
using MediatR;

namespace Application.Scopes.Conversations;

public class StartConversation
{
    public class Query : IRequest<ConversationDto>
    {
        public List<ChatAiMessage> Messages { get; set; }
        public string Endpoint { get; set; }
        public string Model { get; set; }
        public string Key { get; set; }
        public string Context { get; set; }
        public string UserRole { get; set; } = "user";
        public string InitialMessage { get; set; }
    }

    public class Handler : IRequestHandler<Query, ConversationDto>
    {
        private const string ResponseRole = "assistant";
        private readonly IChatAiService _chatAiService;
        private readonly IConversationService _conversationService;

        public Handler(IChatAiService chatAiService, IConversationService service)
        {
            _chatAiService = chatAiService;
            _conversationService = service;
        }

        public async Task<ConversationDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var response = await _chatAiService.GetResponseAsync(request.Endpoint, request.Model, request.Key,
                cancellationToken, request.Messages);

            return ConversationDto.From(await _conversationService.StartConversationAsync(request.Context,
                request.InitialMessage, response.Choices.FirstOrDefault()?.Message.Content,
                request.UserRole, response.Choices.FirstOrDefault()?.Message.Role ?? ResponseRole));
        }
    }
}