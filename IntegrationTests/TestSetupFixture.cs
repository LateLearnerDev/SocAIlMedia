using System.Diagnostics;
using IntegrationTests.Persistence.Provider;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Persistence;

namespace IntegrationTests;

[SetUpFixture]
public class TestSetupFixture
{
    private SolcailMedialDbContext _context;

    [OneTimeSetUp]
    public void OneTimeSetUp() => CreateTestDatabase();

    private void CreateTestDatabase()
    {
        var process = Process.Start("createTestsDbInstance.bat");
        process.WaitForExit();

        _context = new SolcailMedialDbContext(new TestsConnectionStringProvider());
        _context.Database.Migrate();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown() => DropTestDatabase();

    private void DropTestDatabase()
    {
        _context.Database.EnsureDeleted();
        var process = Process.Start("deleteTestsDbInstance.bat");
        process?.WaitForExit();
    }
}