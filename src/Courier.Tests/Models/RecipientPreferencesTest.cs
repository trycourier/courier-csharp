using System.Collections.Generic;
using System.Text.Json;
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

    [Fact]
    public void SerializationRoundtrip_Works()
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<RecipientPreferences>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<RecipientPreferences>(element);
        Assert.NotNull(deserialized);

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

        Assert.Equal(expectedCategories.Count, deserialized.Categories.Count);
        foreach (var item in expectedCategories)
        {
            Assert.True(deserialized.Categories.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Categories[item.Key]);
        }
        Assert.Equal(expectedNotifications.Count, deserialized.Notifications.Count);
        foreach (var item in expectedNotifications)
        {
            Assert.True(deserialized.Notifications.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Notifications[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RecipientPreferences { };

        Assert.Null(model.Categories);
        Assert.False(model.RawData.ContainsKey("categories"));
        Assert.Null(model.Notifications);
        Assert.False(model.RawData.ContainsKey("notifications"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RecipientPreferences { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RecipientPreferences { Categories = null, Notifications = null };

        Assert.Null(model.Categories);
        Assert.True(model.RawData.ContainsKey("categories"));
        Assert.Null(model.Notifications);
        Assert.True(model.RawData.ContainsKey("notifications"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RecipientPreferences { Categories = null, Notifications = null };

        model.Validate();
    }
}
