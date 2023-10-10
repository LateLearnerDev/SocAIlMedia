
using Persistence.Interfaces;

namespace IntegrationTests.Persistence.Provider;

public class TestsConnectionStringProvider : IMigrationsConnectionStringProvider
{
    public const string LocalConnString =
        "Server=(localdb)\\SocailMediaTestsDatabase;Database=SocailMediaTestsDatabase;Trusted_Connection=True;MultipleActiveResultSets=true";
        
    public string Provide()
    {
        return LocalConnString;
    }
}