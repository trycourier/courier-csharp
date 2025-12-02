using System.Collections.Generic;
using Courier.Models;

namespace Courier.Tests.Models;

public class RecipientPreferencesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RecipientPreferences
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

        Dictionary<string, NotificationPreferenceDetails> expectedCategories = new()
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
        };
        Dictionary<string, NotificationPreferenceDetails> expectedNotifications = new()
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
        };

        Assert.Equal(expectedCategories.Count, model.Categories.Count);
        foreach (var item in expectedCategories)
        {
            Assert.True(model.Categories.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Categories[item.Key]);
        }
        Assert.Equal(expectedNotifications.Count, model.Notifications.Count);
        foreach (var item in expectedNotifications)
        {
            Assert.True(model.Notifications.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Notifications[item.Key]);
        }
    }
}
