using System.Collections.Generic;
using Courier.Models;
using Courier.Models.Lists.Subscriptions;

namespace Courier.Tests.Models.Lists.Subscriptions;

public class SubscriptionSubscribeUserParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionSubscribeUserParams
        {
            ListID = "list_id",
            UserID = "user_id",
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
        };

        string expectedListID = "list_id";
        string expectedUserID = "user_id";
        RecipientPreferences expectedPreferences = new()
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
        };

        Assert.Equal(expectedListID, parameters.ListID);
        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedPreferences, parameters.Preferences);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionSubscribeUserParams
        {
            ListID = "list_id",
            UserID = "user_id",
        };

        Assert.Null(parameters.Preferences);
        Assert.False(parameters.RawBodyData.ContainsKey("preferences"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SubscriptionSubscribeUserParams
        {
            ListID = "list_id",
            UserID = "user_id",

            Preferences = null,
        };

        Assert.Null(parameters.Preferences);
        Assert.False(parameters.RawBodyData.ContainsKey("preferences"));
    }
}
