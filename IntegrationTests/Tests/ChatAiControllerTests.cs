using SocAilMedia.Web.Controllers;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace IntegrationTests.Tests;

public class ChatAiControllerTests : AutoRollBackTest
{
    private IConfiguration _configuration;

    [SetUp]
    public void SetUpTestConfig() => _configuration = new TestConfigSetup().Configuration;

    [Test]
    public async Task GetResponse_WhenCalled_ReturnsOk()
    {
        var controller = new ConversationController(_configuration);

        var result = await controller.StartConversation("Hi", "whatever");

        result.Should().NotBeNull();
    }
}