using System;
using System.Collections.Generic;
using Courier.Models;
using Courier.Models.Lists;
using Courier.Models.Lists.Subscriptions;

namespace Courier.Tests.Models.Lists.Subscriptions;

public class SubscriptionSubscribeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionSubscribeParams
        {
            ListID = "list_id",
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
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
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
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                }
                            },
                        },
                    },
                },
            ],
        };

        string expectedListID = "list_id";
        List<PutSubscriptionsRecipient> expectedRecipients =
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
                                ChannelPreferences = [new(ChannelClassification.DirectMessage)],
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
                                ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                Rules = [new() { Until = "until", Start = "start" }],
                            }
                        },
                    },
                },
            },
        ];

        Assert.Equal(expectedListID, parameters.ListID);
        Assert.Equal(expectedRecipients.Count, parameters.Recipients.Count);
        for (int i = 0; i < expectedRecipients.Count; i++)
        {
            Assert.Equal(expectedRecipients[i], parameters.Recipients[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionSubscribeParams parameters = new()
        {
            ListID = "list_id",
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
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
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
                                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                }
                            },
                        },
                    },
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/lists/list_id/subscriptions"), url);
    }
}
