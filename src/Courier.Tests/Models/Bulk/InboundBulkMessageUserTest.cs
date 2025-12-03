using System.Collections.Generic;
using System.Text.Json;
using Courier.Models;
using Courier.Models.Bulk;

namespace Courier.Tests.Models.Bulk;

public class InboundBulkMessageUserTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundBulkMessageUser
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
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
            Profile = JsonSerializer.Deserialize<JsonElement>("{}"),
            Recipient = "recipient",
            To = new()
            {
                AccountID = "account_id",
                Context = new() { TenantID = "tenant_id" },
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Email = "email",
                ListID = "list_id",
                Locale = "locale",
                PhoneNumber = "phone_number",
                Preferences = new()
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
                },
                TenantID = "tenant_id",
                UserID = "user_id",
            },
        };

        JsonElement expectedData = JsonSerializer.Deserialize<JsonElement>("{}");
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
        JsonElement expectedProfile = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedRecipient = "recipient";
        UserRecipient expectedTo = new()
        {
            AccountID = "account_id",
            Context = new() { TenantID = "tenant_id" },
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Email = "email",
            ListID = "list_id",
            Locale = "locale",
            PhoneNumber = "phone_number",
            Preferences = new()
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
            },
            TenantID = "tenant_id",
            UserID = "user_id",
        };

        Assert.True(model.Data.HasValue && JsonElement.DeepEquals(expectedData, model.Data.Value));
        Assert.Equal(expectedPreferences, model.Preferences);
        Assert.True(
            model.Profile.HasValue && JsonElement.DeepEquals(expectedProfile, model.Profile.Value)
        );
        Assert.Equal(expectedRecipient, model.Recipient);
        Assert.Equal(expectedTo, model.To);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundBulkMessageUser
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
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
            Profile = JsonSerializer.Deserialize<JsonElement>("{}"),
            Recipient = "recipient",
            To = new()
            {
                AccountID = "account_id",
                Context = new() { TenantID = "tenant_id" },
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Email = "email",
                ListID = "list_id",
                Locale = "locale",
                PhoneNumber = "phone_number",
                Preferences = new()
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
                },
                TenantID = "tenant_id",
                UserID = "user_id",
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<InboundBulkMessageUser>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundBulkMessageUser
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
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
            Profile = JsonSerializer.Deserialize<JsonElement>("{}"),
            Recipient = "recipient",
            To = new()
            {
                AccountID = "account_id",
                Context = new() { TenantID = "tenant_id" },
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Email = "email",
                ListID = "list_id",
                Locale = "locale",
                PhoneNumber = "phone_number",
                Preferences = new()
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
                },
                TenantID = "tenant_id",
                UserID = "user_id",
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<InboundBulkMessageUser>(json);
        Assert.NotNull(deserialized);

        JsonElement expectedData = JsonSerializer.Deserialize<JsonElement>("{}");
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
        JsonElement expectedProfile = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedRecipient = "recipient";
        UserRecipient expectedTo = new()
        {
            AccountID = "account_id",
            Context = new() { TenantID = "tenant_id" },
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Email = "email",
            ListID = "list_id",
            Locale = "locale",
            PhoneNumber = "phone_number",
            Preferences = new()
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
            },
            TenantID = "tenant_id",
            UserID = "user_id",
        };

        Assert.True(
            deserialized.Data.HasValue
                && JsonElement.DeepEquals(expectedData, deserialized.Data.Value)
        );
        Assert.Equal(expectedPreferences, deserialized.Preferences);
        Assert.True(
            deserialized.Profile.HasValue
                && JsonElement.DeepEquals(expectedProfile, deserialized.Profile.Value)
        );
        Assert.Equal(expectedRecipient, deserialized.Recipient);
        Assert.Equal(expectedTo, deserialized.To);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundBulkMessageUser
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
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
            Profile = JsonSerializer.Deserialize<JsonElement>("{}"),
            Recipient = "recipient",
            To = new()
            {
                AccountID = "account_id",
                Context = new() { TenantID = "tenant_id" },
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Email = "email",
                ListID = "list_id",
                Locale = "locale",
                PhoneNumber = "phone_number",
                Preferences = new()
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
                },
                TenantID = "tenant_id",
                UserID = "user_id",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InboundBulkMessageUser
        {
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
            Recipient = "recipient",
            To = new()
            {
                AccountID = "account_id",
                Context = new() { TenantID = "tenant_id" },
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Email = "email",
                ListID = "list_id",
                Locale = "locale",
                PhoneNumber = "phone_number",
                Preferences = new()
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
                },
                TenantID = "tenant_id",
                UserID = "user_id",
            },
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Profile);
        Assert.False(model.RawData.ContainsKey("profile"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new InboundBulkMessageUser
        {
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
            Recipient = "recipient",
            To = new()
            {
                AccountID = "account_id",
                Context = new() { TenantID = "tenant_id" },
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Email = "email",
                ListID = "list_id",
                Locale = "locale",
                PhoneNumber = "phone_number",
                Preferences = new()
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
                },
                TenantID = "tenant_id",
                UserID = "user_id",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new InboundBulkMessageUser
        {
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
            Recipient = "recipient",
            To = new()
            {
                AccountID = "account_id",
                Context = new() { TenantID = "tenant_id" },
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Email = "email",
                ListID = "list_id",
                Locale = "locale",
                PhoneNumber = "phone_number",
                Preferences = new()
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
                },
                TenantID = "tenant_id",
                UserID = "user_id",
            },

            // Null should be interpreted as omitted for these properties
            Data = null,
            Profile = null,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Profile);
        Assert.False(model.RawData.ContainsKey("profile"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InboundBulkMessageUser
        {
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
            Recipient = "recipient",
            To = new()
            {
                AccountID = "account_id",
                Context = new() { TenantID = "tenant_id" },
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Email = "email",
                ListID = "list_id",
                Locale = "locale",
                PhoneNumber = "phone_number",
                Preferences = new()
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
                },
                TenantID = "tenant_id",
                UserID = "user_id",
            },

            // Null should be interpreted as omitted for these properties
            Data = null,
            Profile = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InboundBulkMessageUser
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            Profile = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        Assert.Null(model.Preferences);
        Assert.False(model.RawData.ContainsKey("preferences"));
        Assert.Null(model.Recipient);
        Assert.False(model.RawData.ContainsKey("recipient"));
        Assert.Null(model.To);
        Assert.False(model.RawData.ContainsKey("to"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new InboundBulkMessageUser
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            Profile = JsonSerializer.Deserialize<JsonElement>("{}"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new InboundBulkMessageUser
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            Profile = JsonSerializer.Deserialize<JsonElement>("{}"),

            Preferences = null,
            Recipient = null,
            To = null,
        };

        Assert.Null(model.Preferences);
        Assert.True(model.RawData.ContainsKey("preferences"));
        Assert.Null(model.Recipient);
        Assert.True(model.RawData.ContainsKey("recipient"));
        Assert.Null(model.To);
        Assert.True(model.RawData.ContainsKey("to"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InboundBulkMessageUser
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            Profile = JsonSerializer.Deserialize<JsonElement>("{}"),

            Preferences = null,
            Recipient = null,
            To = null,
        };

        model.Validate();
    }
}
