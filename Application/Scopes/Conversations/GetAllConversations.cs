using Application.Scopes.Conversations.Dtos;
using Application.Scopes.Conversations.Interfaces;
using MediatR;

namespace Application.Scopes.Conversations;

public class GetAllConversations
{
    public class Query : IRequest<List<ConversationDto>>
    {
    }

    public class Handler : IRequestHandler<Query, List<ConversationDto>>
    {
        private readonly IConversationService _service;

        public Handler(IConversationService service) => _service = service;
        
        public async Task<List<ConversationDto>> Handle(Query request, CancellationToken cancellationToken) =>
            (await _service.GetAllConversationsAsync()).Select(ConversationDto.From).ToList();

    }
}