using System;
using System.Collections.Generic;
using Courier.Models;
using Courier.Models.Lists;

namespace Courier.Tests.Models.Lists;

public class ListUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ListUpdateParams
        {
            ListID = "list_id",
            Name = "name",
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
        string expectedName = "name";
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
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedPreferences, parameters.Preferences);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ListUpdateParams { ListID = "list_id", Name = "name" };

        Assert.Null(parameters.Preferences);
        Assert.False(parameters.RawBodyData.ContainsKey("preferences"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ListUpdateParams
        {
            ListID = "list_id",
            Name = "name",

            Preferences = null,
        };

        Assert.Null(parameters.Preferences);
        Assert.True(parameters.RawBodyData.ContainsKey("preferences"));
    }

    [Fact]
    public void Url_Works()
    {
        ListUpdateParams parameters = new() { ListID = "list_id", Name = "name" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/lists/list_id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ListUpdateParams
        {
            ListID = "list_id",
            Name = "name",
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

        ListUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
