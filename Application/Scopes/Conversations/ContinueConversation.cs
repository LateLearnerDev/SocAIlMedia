using Application.Constants;
using Application.Scopes.ChatAi.Interfaces;
using Application.Scopes.ChatAi.Models;
using Application.Scopes.Conversations.Dtos;
using Application.Scopes.Conversations.Interfaces;
using MediatR;

namespace Application.Scopes.Conversations;

public class ContinueConversation
{
    public class Query : IRequest
    {
        public string Endpoint { get; set; }
        public string Model { get; set; }
        public string Key { get; set; }
        public int ConversationId { get; set; }
        public string UserMessage { get; set; }
        
    }

    public class Handler : IRequestHandler<Query>
    {
        private readonly IConversationService _conversationService;
        private readonly IChatAiService _chatAiService;

        public Handler(IConversationService conversationService, IChatAiService chatAiService)
        {
            _conversationService = conversationService;
            _chatAiService = chatAiService;
        }

        public async Task Handle(Query request, CancellationToken cancellationToken)
        {
            var conversation = ConversationDto.From(await _conversationService.GetConversationAsync(request.ConversationId));
            var chatAiMessages = conversation.Messages?
                .Select(x => new ChatAiMessage
                {
                    Content = x.Message,
                    Role = x.Role
                }).ToList();
            chatAiMessages?.Add(new ChatAiMessage {Content = request.UserMessage, Role = DefaultRoles.User});
            
            var response = AiResponseDto.From(await _chatAiService.GetResponseAsync(request.Endpoint, request.Model, request.Key, cancellationToken,
                chatAiMessages));
            
            await _conversationService.ContinueConversationAsync(request.ConversationId, new List<ChatAiMessage>
            {
                new()
                {
                    Content = request.UserMessage,
                    Role = DefaultRoles.User
                },
                new()
                {
                    Content = response.Response,
                    Role = response.Role
                }
            });
        }
    }
}