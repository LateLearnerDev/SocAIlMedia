using System.Reflection;
using Domain.Entities.Messages;
using Microsoft.EntityFrameworkCore;
using Persistence.Interfaces;

namespace Persistence;

public class SolcailMedialDbContext : DbContext
{
    private readonly string _connectionString;
    
    public SolcailMedialDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public SolcailMedialDbContext(IMigrationsConnectionStringProvider provider)
    {
        _connectionString = provider.Provide();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(
                _connectionString,
                x => x.MigrationsHistoryTable("__SocailMediaMigrationsHistory"));
            
        // optionsBuilder.ReplaceService<IMigrationsSqlGenerator, SqlGenerator>();
    }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var assembly = Assembly.GetAssembly(GetType());
        if (assembly != null)
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
    }

    public DbSet<Conversation?> Conversations { get; set; }
    
    
}