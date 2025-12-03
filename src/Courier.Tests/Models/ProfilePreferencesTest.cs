using System.Collections.Generic;
using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class ProfilePreferencesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProfilePreferences
        {
            Notifications = new Dictionary<string, Preference>()
            {
                {
                    "foo",
                    new()
                    {
                        Status = PreferenceStatus.OptedIn,
                        ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                        Rules = [new() { Until = "until", Start = "start" }],
                        Source = Source.Subscription,
                    }
                },
            },
            Categories = new Dictionary<string, Preference>()
            {
                {
                    "foo",
                    new()
                    {
                        Status = PreferenceStatus.OptedIn,
                        ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                        Rules = [new() { Until = "until", Start = "start" }],
                        Source = Source.Subscription,
                    }
                },
            },
            TemplateID = "templateId",
        };

        Dictionary<string, Preference> expectedNotifications = new()
        {
            {
                "foo",
                new()
                {
                    Status = PreferenceStatus.OptedIn,
                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                    Rules = [new() { Until = "until", Start = "start" }],
                    Source = Source.Subscription,
                }
            },
        };
        Dictionary<string, Preference> expectedCategories = new()
        {
            {
                "foo",
                new()
                {
                    Status = PreferenceStatus.OptedIn,
                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                    Rules = [new() { Until = "until", Start = "start" }],
                    Source = Source.Subscription,
                }
            },
        };
        string expectedTemplateID = "templateId";

        Assert.Equal(expectedNotifications.Count, model.Notifications.Count);
        foreach (var item in expectedNotifications)
        {
            Assert.True(model.Notifications.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Notifications[item.Key]);
        }
        Assert.Equal(expectedCategories.Count, model.Categories.Count);
        foreach (var item in expectedCategories)
        {
            Assert.True(model.Categories.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Categories[item.Key]);
        }
        Assert.Equal(expectedTemplateID, model.TemplateID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProfilePreferences
        {
            Notifications = new Dictionary<string, Preference>()
            {
                {
                    "foo",
                    new()
                    {
                        Status = PreferenceStatus.OptedIn,
                        ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                        Rules = [new() { Until = "until", Start = "start" }],
                        Source = Source.Subscription,
                    }
                },
            },
            Categories = new Dictionary<string, Preference>()
            {
                {
                    "foo",
                    new()
                    {
                        Status = PreferenceStatus.OptedIn,
                        ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                        Rules = [new() { Until = "until", Start = "start" }],
                        Source = Source.Subscription,
                    }
                },
            },
            TemplateID = "templateId",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ProfilePreferences>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProfilePreferences
        {
            Notifications = new Dictionary<string, Preference>()
            {
                {
                    "foo",
                    new()
                    {
                        Status = PreferenceStatus.OptedIn,
                        ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                        Rules = [new() { Until = "until", Start = "start" }],
                        Source = Source.Subscription,
                    }
                },
            },
            Categories = new Dictionary<string, Preference>()
            {
                {
                    "foo",
                    new()
                    {
                        Status = PreferenceStatus.OptedIn,
                        ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                        Rules = [new() { Until = "until", Start = "start" }],
                        Source = Source.Subscription,
                    }
                },
            },
            TemplateID = "templateId",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ProfilePreferences>(json);
        Assert.NotNull(deserialized);

        Dictionary<string, Preference> expectedNotifications = new()
        {
            {
                "foo",
                new()
                {
                    Status = PreferenceStatus.OptedIn,
                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                    Rules = [new() { Until = "until", Start = "start" }],
                    Source = Source.Subscription,
                }
            },
        };
        Dictionary<string, Preference> expectedCategories = new()
        {
            {
                "foo",
                new()
                {
                    Status = PreferenceStatus.OptedIn,
                    ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                    Rules = [new() { Until = "until", Start = "start" }],
                    Source = Source.Subscription,
                }
            },
        };
        string expectedTemplateID = "templateId";

        Assert.Equal(expectedNotifications.Count, deserialized.Notifications.Count);
        foreach (var item in expectedNotifications)
        {
            Assert.True(deserialized.Notifications.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Notifications[item.Key]);
        }
        Assert.Equal(expectedCategories.Count, deserialized.Categories.Count);
        foreach (var item in expectedCategories)
        {
            Assert.True(deserialized.Categories.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Categories[item.Key]);
        }
        Assert.Equal(expectedTemplateID, deserialized.TemplateID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProfilePreferences
        {
            Notifications = new Dictionary<string, Preference>()
            {
                {
                    "foo",
                    new()
                    {
                        Status = PreferenceStatus.OptedIn,
                        ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                        Rules = [new() { Until = "until", Start = "start" }],
                        Source = Source.Subscription,
                    }
                },
            },
            Categories = new Dictionary<string, Preference>()
            {
                {
                    "foo",
                    new()
                    {
                        Status = PreferenceStatus.OptedIn,
                        ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                        Rules = [new() { Until = "until", Start = "start" }],
                        Source = Source.Subscription,
                    }
                },
            },
            TemplateID = "templateId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProfilePreferences
        {
            Notifications = new Dictionary<string, Preference>()
            {
                {
                    "foo",
                    new()
                    {
                        Status = PreferenceStatus.OptedIn,
                        ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                        Rules = [new() { Until = "until", Start = "start" }],
                        Source = Source.Subscription,
                    }
                },
            },
        };

        Assert.Null(model.Categories);
        Assert.False(model.RawData.ContainsKey("categories"));
        Assert.Null(model.TemplateID);
        Assert.False(model.RawData.ContainsKey("templateId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProfilePreferences
        {
            Notifications = new Dictionary<string, Preference>()
            {
                {
                    "foo",
                    new()
                    {
                        Status = PreferenceStatus.OptedIn,
                        ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                        Rules = [new() { Until = "until", Start = "start" }],
                        Source = Source.Subscription,
                    }
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ProfilePreferences
        {
            Notifications = new Dictionary<string, Preference>()
            {
                {
                    "foo",
                    new()
                    {
                        Status = PreferenceStatus.OptedIn,
                        ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                        Rules = [new() { Until = "until", Start = "start" }],
                        Source = Source.Subscription,
                    }
                },
            },

            Categories = null,
            TemplateID = null,
        };

        Assert.Null(model.Categories);
        Assert.True(model.RawData.ContainsKey("categories"));
        Assert.Null(model.TemplateID);
        Assert.True(model.RawData.ContainsKey("templateId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ProfilePreferences
        {
            Notifications = new Dictionary<string, Preference>()
            {
                {
                    "foo",
                    new()
                    {
                        Status = PreferenceStatus.OptedIn,
                        ChannelPreferences = [new(ChannelClassification.DirectMessage)],
                        Rules = [new() { Until = "until", Start = "start" }],
                        Source = Source.Subscription,
                    }
                },
            },

            Categories = null,
            TemplateID = null,
        };

        model.Validate();
    }
}
