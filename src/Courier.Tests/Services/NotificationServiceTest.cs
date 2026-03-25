using System.Threading.Tasks;
using Courier.Models;

namespace Courier.Tests.Services;

public class NotificationServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var notificationTemplateMutationResponse = await this.client.Notifications.Create(
            new()
            {
                Notification = new()
                {
                    Brand = new("brand_abc"),
                    Content = new()
                    {
                        Elements =
                        [
                            new ElementalChannelNodeWithType()
                            {
                                Type = ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
                            },
                        ],
                        Version = "2022-01-01",
                    },
                    Name = "Welcome Email",
                    Routing = new("rs_123"),
                    Subscription = new("marketing"),
                    Tags = ["onboarding", "welcome"],
                },
            },
            TestContext.Current.CancellationToken
        );
        notificationTemplateMutationResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var notificationTemplateGetResponse = await this.client.Notifications.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        notificationTemplateGetResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var notifications = await this.client.Notifications.List(
            new(),
            TestContext.Current.CancellationToken
        );
        notifications.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Archive_Works()
    {
        await this.client.Notifications.Archive("id", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Publish_Works()
    {
        await this.client.Notifications.Publish("id", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Replace_Works()
    {
        var notificationTemplateMutationResponse = await this.client.Notifications.Replace(
            "id",
            new()
            {
                Notification = new()
                {
                    Brand = new("id"),
                    Content = new()
                    {
                        Elements =
                        [
                            new ElementalChannelNodeWithType()
                            {
                                Type = ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
                            },
                        ],
                        Version = "2022-01-01",
                    },
                    Name = "Updated Name",
                    Routing = new("strategy_id"),
                    Subscription = new("topic_id"),
                    Tags = ["updated"],
                },
            },
            TestContext.Current.CancellationToken
        );
        notificationTemplateMutationResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveContent_Works()
    {
        var notificationGetContent = await this.client.Notifications.RetrieveContent(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        notificationGetContent.Validate();
    }
}
