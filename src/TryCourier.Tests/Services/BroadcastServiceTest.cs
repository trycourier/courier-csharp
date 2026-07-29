using System.Threading.Tasks;
using TryCourier.Models.Broadcasts;
using Models = TryCourier.Models;

namespace TryCourier.Tests.Services;

public class BroadcastServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var broadcast = await this.client.Broadcasts.Create(
            new() { Channel = Channel.Email, Name = "Spring Sale Announcement" },
            TestContext.Current.CancellationToken
        );
        broadcast.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var broadcast = await this.client.Broadcasts.Retrieve(
            "broadcastId",
            new(),
            TestContext.Current.CancellationToken
        );
        broadcast.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var broadcast = await this.client.Broadcasts.Update(
            "broadcastId",
            new() { Name = "Spring Sale Announcement (v2)" },
            TestContext.Current.CancellationToken
        );
        broadcast.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var broadcastListResponse = await this.client.Broadcasts.List(
            new(),
            TestContext.Current.CancellationToken
        );
        broadcastListResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Archive_Works()
    {
        var broadcast = await this.client.Broadcasts.Archive(
            "broadcastId",
            new(),
            TestContext.Current.CancellationToken
        );
        broadcast.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Cancel_Works()
    {
        var broadcast = await this.client.Broadcasts.Cancel(
            "broadcastId",
            new(),
            TestContext.Current.CancellationToken
        );
        broadcast.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Duplicate_Works()
    {
        var broadcast = await this.client.Broadcasts.Duplicate(
            "broadcastId",
            new(),
            TestContext.Current.CancellationToken
        );
        broadcast.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task PutContent_Works()
    {
        var notificationContentMutationResponse = await this.client.Broadcasts.PutContent(
            "broadcastId",
            new()
            {
                Content = new()
                {
                    Elements =
                    [
                        new Models::ElementalMetaNodeWithType()
                        {
                            Channels = ["string"],
                            If = "if",
                            Loop = "loop",
                            Ref = "ref",
                            Type = Models::ElementalMetaNodeWithTypeIntersectionMember1Type.Meta,
                        },
                        new Models::ElementalTextNodeWithType()
                        {
                            Channels = ["string"],
                            If = "if",
                            Loop = "loop",
                            Ref = "ref",
                            Type = Models::ElementalTextNodeWithTypeIntersectionMember1Type.Text,
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
    public async Task RetrieveContent_Works()
    {
        var notificationContentGetResponse = await this.client.Broadcasts.RetrieveContent(
            "broadcastId",
            new(),
            TestContext.Current.CancellationToken
        );
        notificationContentGetResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Schedule_Works()
    {
        var broadcast = await this.client.Broadcasts.Schedule(
            "broadcastId",
            new()
            {
                RecipientID = "aud_01kx4h2jdafq8bk9amzvy6hbv0",
                RecipientType = RecipientType.Audience,
                ScheduledTo = "2026-08-01T15:00:00",
            },
            TestContext.Current.CancellationToken
        );
        broadcast.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Send_Works()
    {
        var broadcast = await this.client.Broadcasts.Send(
            "broadcastId",
            new()
            {
                RecipientID = "cool-customers",
                RecipientType = BroadcastSendParamsRecipientType.List,
            },
            TestContext.Current.CancellationToken
        );
        broadcast.Validate();
    }
}
