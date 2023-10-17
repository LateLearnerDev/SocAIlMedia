using SocAilMedia.Web.Controllers;
using FluentAssertions;
using MediatR;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace IntegrationTests.Tests;

public class ChatAiControllerTests : AutoRollBackTest
{
    private IConfiguration _configuration;
    private IMediator _mediator;

    [SetUp]
    public void SetUpTestConfig()
    {
        _configuration = new TestConfigSetup().Configuration;
        _mediator = new MediatorConfiguration().ConfigureMediator();
    }

    [Test]
    public async Task GetResponse_WhenCalled_ReturnsOk()
    {
        var controller = new ConversationController(_configuration, _mediator);

        var result = await controller.StartConversation("Hi", "whatever");

        result.Should().NotBeNull();
    }
}