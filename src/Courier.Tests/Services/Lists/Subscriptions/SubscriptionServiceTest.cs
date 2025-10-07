using System.Collections.Generic;
using System.Threading.Tasks;
using Courier.Models.Lists.Subscriptions.RecipientPreferencesProperties.CategoriesProperties;
using Courier.Models.Lists.Subscriptions.RecipientPreferencesProperties.NotificationsProperties;
using Courier.Models.Tenants.DefaultPreferences.Items;
using Courier.Models.Users.Preferences;

namespace Courier.Tests.Services.Lists.Subscriptions;

public class SubscriptionServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var subscriptions = await this.client.Lists.Subscriptions.List(
            new() { ListID = "list_id" }
        );
        subscriptions.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Add_Works()
    {
        await this.client.Lists.Subscriptions.Add(
            new()
            {
                ListID = "list_id",
                Recipients =
                [
                    new()
                    {
                        RecipientID = "recipientId",
                        Preferences = new()
                        {
                            Categories = new Dictionary<string, CategoriesItem>()
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
                            Notifications = new Dictionary<string, NotificationsItem>()
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
            }
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Subscribe_Works()
    {
        await this.client.Lists.Subscriptions.Subscribe(
            new()
            {
                ListID = "list_id",
                Recipients =
                [
                    new()
                    {
                        RecipientID = "recipientId",
                        Preferences = new()
                        {
                            Categories = new Dictionary<string, CategoriesItem>()
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
                            Notifications = new Dictionary<string, NotificationsItem>()
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
            }
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task SubscribeUser_Works()
    {
        await this.client.Lists.Subscriptions.SubscribeUser(
            new() { ListID = "list_id", UserID = "user_id" }
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task UnsubscribeUser_Works()
    {
        await this.client.Lists.Subscriptions.UnsubscribeUser(
            new() { ListID = "list_id", UserID = "user_id" }
        );
    }
}
