using System.Threading.Tasks;
using TryCourier.Models;

namespace TryCourier.Tests.Services;

public class NotificationServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var notificationTemplateResponse = await this.client.Notifications.Create(
            new()
            {
                Notification = new()
                {
                    Brand = new("bnd_01kx4mrd0pfzw8wt7pn7p2fzag"),
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
                    Routing = new("rs_01kx4h2jdafq8bk9amzvy6hbv0"),
                    Subscription = new("pt_01kx4h2jdafq8bk9a26x0kvd1t"),
                    Tags = ["onboarding", "welcome"],
                },
            },
            TestContext.Current.CancellationToken
        );
        notificationTemplateResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var notificationTemplateResponse = await this.client.Notifications.Retrieve(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        notificationTemplateResponse.Validate();
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
    public async Task Duplicate_Works()
    {
        var notificationTemplateResponse = await this.client.Notifications.Duplicate(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        notificationTemplateResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListVersions_Works()
    {
        var notificationTemplateVersionListResponse = await this.client.Notifications.ListVersions(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        notificationTemplateVersionListResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Publish_Works()
    {
        await this.client.Notifications.Publish("id", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task PutContent_Works()
    {
        var notificationContentMutationResponse = await this.client.Notifications.PutContent(
            "id",
            new()
            {
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
            },
            TestContext.Current.CancellationToken
        );
        notificationContentMutationResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task PutElement_Works()
    {
        var notificationContentMutationResponse = await this.client.Notifications.PutElement(
            "elementId",
            new() { ID = "id", Type = "text" },
            TestContext.Current.CancellationToken
        );
        notificationContentMutationResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task PutLocale_Works()
    {
        var notificationContentMutationResponse = await this.client.Notifications.PutLocale(
            "localeId",
            new() { ID = "id", Elements = [new("elem_1"), new("elem_2")] },
            TestContext.Current.CancellationToken
        );
        notificationContentMutationResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Replace_Works()
    {
        var notificationTemplateResponse = await this.client.Notifications.Replace(
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
        notificationTemplateResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveContent_Works()
    {
        var response = await this.client.Notifications.RetrieveContent(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
