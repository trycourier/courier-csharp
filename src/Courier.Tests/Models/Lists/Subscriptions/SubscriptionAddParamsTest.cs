using System.Collections.Generic;
using Courier.Models;
using Courier.Models.Lists;
using Courier.Models.Lists.Subscriptions;

namespace Courier.Tests.Models.Lists.Subscriptions;

public class SubscriptionAddParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionAddParams
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
}
