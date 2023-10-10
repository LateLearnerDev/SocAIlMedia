using Microsoft.Extensions.Configuration;

namespace IntegrationTests;

public class TestConfigSetup
{
    public IConfiguration Configuration { get; }

    public TestConfigSetup()
    {
        Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Test.json", optional: false, reloadOnChange: true)
            .Build();
    }
}