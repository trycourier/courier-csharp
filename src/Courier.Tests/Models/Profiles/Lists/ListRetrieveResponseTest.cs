using System.Collections.Generic;
using Courier.Models;
using Courier.Models.Profiles.Lists;

namespace Courier.Tests.Models.Profiles.Lists;

public class ListRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ListRetrieveResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    Created = "created",
                    Name = "name",
                    Updated = "updated",
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

        Paging expectedPaging = new() { More = true, Cursor = "cursor" };
        List<Result> expectedResults =
        [
            new()
            {
                ID = "id",
                Created = "created",
                Name = "name",
                Updated = "updated",
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

        Assert.Equal(expectedPaging, model.Paging);
        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], model.Results[i]);
        }
    }
}

public class ResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Result
        {
            ID = "id",
            Created = "created",
            Name = "name",
            Updated = "updated",
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

        string expectedID = "id";
        string expectedCreated = "created";
        string expectedName = "name";
        string expectedUpdated = "updated";
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

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedUpdated, model.Updated);
        Assert.Equal(expectedPreferences, model.Preferences);
    }
}
