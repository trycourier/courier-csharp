using System.Threading.Tasks;
using Courier.Models;

namespace Courier.Tests.Services;

public class RoutingStrategyServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var routingStrategyMutationResponse = await this.client.RoutingStrategies.Create(
            new()
            {
                Name = "Email via SendGrid",
                Routing = new() { Channels = ["email"], Method = Method.Single },
            },
            TestContext.Current.CancellationToken
        );
        routingStrategyMutationResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var routingStrategyGetResponse = await this.client.RoutingStrategies.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        routingStrategyGetResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var routingStrategyListResponse = await this.client.RoutingStrategies.List(
            new(),
            TestContext.Current.CancellationToken
        );
        routingStrategyListResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Archive_Works()
    {
        await this.client.RoutingStrategies.Archive(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListNotifications_Works()
    {
        var associatedNotificationListResponse =
            await this.client.RoutingStrategies.ListNotifications(
                "id",
                new(),
                TestContext.Current.CancellationToken
            );
        associatedNotificationListResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Replace_Works()
    {
        var routingStrategyMutationResponse = await this.client.RoutingStrategies.Replace(
            "id",
            new()
            {
                Name = "Email via SendGrid v2",
                Routing = new() { Channels = ["email"], Method = Method.Single },
            },
            TestContext.Current.CancellationToken
        );
        routingStrategyMutationResponse.Validate();
    }
}
