using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Interfaces;

namespace IntegrationTests;

public class TestDbContext : SolcailMedialDbContext
{
    public TestDbContext(DbContextOptions options) : base(options)
    {
    }

    public TestDbContext(IMigrationsConnectionStringProvider provider) : base(provider)
    {
    }
}