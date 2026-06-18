using System.Threading.Tasks;
using TryCourier.Models;
using TryCourier.Models.Journeys.Templates;

namespace TryCourier.Tests.Services.Journeys;

public class TemplateServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var journeyTemplateGetResponse = await this.client.Journeys.Templates.Create(
            "x",
            new()
            {
                Channel = "email",
                Notification = new()
                {
                    Brand = new("id"),
                    Content = new()
                    {
                        Elements =
                        [
                            new ElementalTextNodeWithType()
                            {
                                Channels = ["string"],
                                If = "if",
                                Loop = "loop",
                                Ref = "ref",
                                Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                            },
                        ],
                        Version = Version.V2022_01_01,
                        Scope = Scope.Default,
                    },
                    Name = "Welcome email",
                    Subscription = new("topic_id"),
                    Tags = ["string"],
                },
            },
            TestContext.Current.CancellationToken
        );
        journeyTemplateGetResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var journeyTemplateGetResponse = await this.client.Journeys.Templates.Retrieve(
            "x",
            new() { TemplateID = "x" },
            TestContext.Current.CancellationToken
        );
        journeyTemplateGetResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var journeyTemplateListResponse = await this.client.Journeys.Templates.List(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        journeyTemplateListResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Archive_Works()
    {
        await this.client.Journeys.Templates.Archive(
            "x",
            new() { TemplateID = "x" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListVersions_Works()
    {
        var notificationTemplateVersionListResponse =
            await this.client.Journeys.Templates.ListVersions(
                "x",
                new() { TemplateID = "x" },
                TestContext.Current.CancellationToken
            );
        notificationTemplateVersionListResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Publish_Works()
    {
        await this.client.Journeys.Templates.Publish(
            "x",
            new() { TemplateID = "x" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Replace_Works()
    {
        var journeyTemplateGetResponse = await this.client.Journeys.Templates.Replace(
            "x",
            new()
            {
                TemplateID = "x",
                Notification = new()
                {
                    Brand = new("id"),
                    Content = new()
                    {
                        Elements =
                        [
                            new ElementalTextNodeWithType()
                            {
                                Channels = ["string"],
                                If = "if",
                                Loop = "loop",
                                Ref = "ref",
                                Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                            },
                        ],
                        Version = TemplateReplaceParamsNotificationContentVersion.V2022_01_01,
                        Scope = TemplateReplaceParamsNotificationContentScope.Default,
                    },
                    Name = "name",
                    Subscription = new("topic_id"),
                    Tags = ["string"],
                },
            },
            TestContext.Current.CancellationToken
        );
        journeyTemplateGetResponse.Validate();
    }
}
