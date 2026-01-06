using System;
using System.Collections.Generic;
using Courier.Models;
using Courier.Models.Profiles;
using Courier.Models.Profiles.Lists;

namespace Courier.Tests.Models.Profiles.Lists;

public class ListSubscribeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ListSubscribeParams
        {
            UserID = "user_id",
            Lists =
            [
                new()
                {
                    ListID = "listId",
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

        string expectedUserID = "user_id";
        List<SubscribeToListsRequestItem> expectedLists =
        [
            new()
            {
                ListID = "listId",
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

        Assert.Equal(expectedUserID, parameters.UserID);
        Assert.Equal(expectedLists.Count, parameters.Lists.Count);
        for (int i = 0; i < expectedLists.Count; i++)
        {
            Assert.Equal(expectedLists[i], parameters.Lists[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        ListSubscribeParams parameters = new()
        {
            UserID = "user_id",
            Lists =
            [
                new()
                {
                    ListID = "listId",
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

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/profiles/user_id/lists"), url);
    }
}
