using System.Transactions;
using Application.System;
using NUnit.Framework;

namespace IntegrationTests;

[TestFixture]
public class AutoRollBackTest
{
    private TransactionScope _transaction;

    private readonly TransactionOptions _options = new ()
    {
        IsolationLevel = IsolationLevel.ReadUncommitted,
        Timeout = TimeSpan.FromSeconds(30)
    };

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
    }

    [SetUp]
    public void BeforeEach()
    {
        _transaction = new TransactionScope(TransactionScopeOption.RequiresNew, _options,
            TransactionScopeAsyncFlowOption.Enabled);
    }

    [TearDown]
    public virtual void AfterEach() => _transaction.Dispose();

    [TearDown]
    public void ResetSystemTime() => SystemTime.Reset();
}