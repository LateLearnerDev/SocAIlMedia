using Application.Scopes.ChatAi;
using Application.Scopes.ChatAi.Interfaces;
using Application.Scopes.Conversations.Interfaces;
using Infrastructure.Service.ExternalServices;
using Infrastructure.Service.Services;
using IntegrationTests.Persistence.Provider;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace IntegrationTests;

public class MediatorConfiguration
{
    public IMediator ConfigureMediator()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetResponse>());
        serviceCollection.AddDbContext<SolcailMedialDbContext>(options => options.UseSqlServer(new TestsConnectionStringProvider().Provide()));

        serviceCollection.AddTransient<IChatAiService, ChatAiService>();
        serviceCollection.AddTransient<IConversationService>(provider => new ConversationService(provider.GetRequiredService<SolcailMedialDbContext>()));
        
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var mediator = serviceProvider.GetRequiredService<IMediator>();
        
        return mediator;
    }
}