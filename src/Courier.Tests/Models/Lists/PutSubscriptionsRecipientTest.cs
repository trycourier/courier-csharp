using System.Collections.Generic;
using System.Text.Json;
using Courier.Models;
using Courier.Models.Lists;

namespace Courier.Tests.Models.Lists;

public class PutSubscriptionsRecipientTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PutSubscriptionsRecipient
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
        };

        string expectedRecipientID = "recipientId";
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

        Assert.Equal(expectedRecipientID, model.RecipientID);
        Assert.Equal(expectedPreferences, model.Preferences);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PutSubscriptionsRecipient
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PutSubscriptionsRecipient>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PutSubscriptionsRecipient
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<PutSubscriptionsRecipient>(json);
        Assert.NotNull(deserialized);

        string expectedRecipientID = "recipientId";
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

        Assert.Equal(expectedRecipientID, deserialized.RecipientID);
        Assert.Equal(expectedPreferences, deserialized.Preferences);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PutSubscriptionsRecipient
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PutSubscriptionsRecipient { RecipientID = "recipientId" };

        Assert.Null(model.Preferences);
        Assert.False(model.RawData.ContainsKey("preferences"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PutSubscriptionsRecipient { RecipientID = "recipientId" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PutSubscriptionsRecipient
        {
            RecipientID = "recipientId",

            Preferences = null,
        };

        Assert.Null(model.Preferences);
        Assert.True(model.RawData.ContainsKey("preferences"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PutSubscriptionsRecipient
        {
            RecipientID = "recipientId",

            Preferences = null,
        };

        model.Validate();
    }
}
