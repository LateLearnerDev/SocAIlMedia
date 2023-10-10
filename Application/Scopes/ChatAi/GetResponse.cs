using Application.Scopes.ChatAi.Interfaces;
using Application.Scopes.ChatAi.Models;
using MediatR;

namespace Application.Scopes.ChatAi;

public class GetResponse
{
    public class Query : IRequest<ChatApiResponse>
    {
        public List<ChatAiMessage> Messages { get; set; }
        public string Endpoint { get; set; }
        public string Model { get; set; }
        public string Key { get; set; }
    }

    public class Handler : IRequestHandler<Query, ChatApiResponse>
    {
        private readonly IChatAiService _service;

        public Handler(IChatAiService service) => _service = service;

        public async Task<ChatApiResponse> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _service.GetResponseAsync(request.Endpoint, request.Model, request.Key, cancellationToken,
                request.Messages);
        }
    }
}