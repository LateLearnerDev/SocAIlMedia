using Application.Scopes.ChatAi;
using Application.Scopes.ChatAi.Interfaces;
using Application.Scopes.Conversations.Interfaces;
using Infrastructure.Service.ExternalServices;
using Infrastructure.Service.Services;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace SocAilMedia.Web.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration config)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddDbContext<SolcailMedialDbContext>(opt =>
        {
            opt.UseLazyLoadingProxies();
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });
        services.AddCors(opt =>
        {
            opt.AddPolicy("CorsPolicy", policy =>
            {
                policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
            });
        });
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetResponse>());
        // services.AddAutoMapper(typeof(MappingProfiles).Assembly);

        services.AddScoped<IChatAiService, ChatAiService>();
        services.AddScoped<IConversationService, ConversationService>();

        return services;
    }
}