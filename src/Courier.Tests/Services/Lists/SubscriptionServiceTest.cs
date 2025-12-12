using System.Collections.Generic;
using System.Threading.Tasks;
using Courier.Models;

namespace Courier.Tests.Services.Lists;

public class SubscriptionServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var subscriptions = await this.client.Lists.Subscriptions.List(
            "list_id",
            new(),
            TestContext.Current.CancellationToken
        );
        subscriptions.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Add_Works()
    {
        await this.client.Lists.Subscriptions.Add(
            "list_id",
            new()
            {
                Recipients =
                [
                    new()
                    {
                        RecipientID = "recipientId",
                        Preferences = new()
                        {
                            Categories = new Dictionary<string, NotificationPreferenceDetails>()
                            {
                                {
                                    "foo",
                                    new()
                                    {
                                        Status = PreferenceStatus.OptedIn,
                                        ChannelPreferences =
                                        [
                                            new(ChannelClassification.DirectMessage),
                                        ],
                                        Rules = [new() { Until = "until", Start = "start" }],
                                    }
                                },
                            },
                            Notifications = new Dictionary<string, NotificationPreferenceDetails>()
                            {
                                {
                                    "foo",
                                    new()
                                    {
                                        Status = PreferenceStatus.OptedIn,
                                        ChannelPreferences =
                                        [
                                            new(ChannelClassification.DirectMessage),
                                        ],
                                        Rules = [new() { Until = "until", Start = "start" }],
                                    }
                                },
                            },
                        },
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Subscribe_Works()
    {
        await this.client.Lists.Subscriptions.Subscribe(
            "list_id",
            new()
            {
                Recipients =
                [
                    new()
                    {
                        RecipientID = "recipientId",
                        Preferences = new()
                        {
                            Categories = new Dictionary<string, NotificationPreferenceDetails>()
                            {
                                {
                                    "foo",
                                    new()
                                    {
                                        Status = PreferenceStatus.OptedIn,
                                        ChannelPreferences =
                                        [
                                            new(ChannelClassification.DirectMessage),
                                        ],
                                        Rules = [new() { Until = "until", Start = "start" }],
                                    }
                                },
                            },
                            Notifications = new Dictionary<string, NotificationPreferenceDetails>()
                            {
                                {
                                    "foo",
                                    new()
                                    {
                                        Status = PreferenceStatus.OptedIn,
                                        ChannelPreferences =
                                        [
                                            new(ChannelClassification.DirectMessage),
                                        ],
                                        Rules = [new() { Until = "until", Start = "start" }],
                                    }
                                },
                            },
                        },
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task SubscribeUser_Works()
    {
        await this.client.Lists.Subscriptions.SubscribeUser(
            "user_id",
            new() { ListID = "list_id" },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task UnsubscribeUser_Works()
    {
        await this.client.Lists.Subscriptions.UnsubscribeUser(
            "user_id",
            new() { ListID = "list_id" },
            TestContext.Current.CancellationToken
        );
    }
}
