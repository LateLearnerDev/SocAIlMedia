using Application.Scopes.Conversations.Dtos;
using Application.Scopes.Conversations.Interfaces;
using MediatR;

namespace Application.Scopes.Conversations;

public class GetConversation
{
    public class Query : IRequest<ConversationDto>
    {
        public int Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, ConversationDto>
    {
        private readonly IConversationService _service;

        public Handler(IConversationService service) => _service = service;
        
        public async Task<ConversationDto> Handle(Query request, CancellationToken cancellationToken) => 
            ConversationDto.From(await _service.GetConversationAsync(request.Id));
    }
}