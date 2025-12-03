using System.Collections.Generic;
using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class RecipientTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Recipient
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

        string expectedAccountID = "account_id";
        MessageContext expectedContext = new() { TenantID = "tenant_id" };
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedEmail = "email";
        string expectedListID = "list_id";
        string expectedLocale = "locale";
        string expectedPhoneNumber = "phone_number";
        Preferences expectedPreferences = new()
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
        string expectedTenantID = "tenant_id";
        string expectedUserID = "user_id";

        Assert.Equal(expectedAccountID, model.AccountID);
        Assert.Equal(expectedContext, model.Context);
        Assert.Equal(expectedData.Count, model.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(model.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Data[item.Key]));
        }
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedListID, model.ListID);
        Assert.Equal(expectedLocale, model.Locale);
        Assert.Equal(expectedPhoneNumber, model.PhoneNumber);
        Assert.Equal(expectedPreferences, model.Preferences);
        Assert.Equal(expectedTenantID, model.TenantID);
        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Recipient
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Recipient>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Recipient
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

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Recipient>(json);
        Assert.NotNull(deserialized);

        string expectedAccountID = "account_id";
        MessageContext expectedContext = new() { TenantID = "tenant_id" };
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedEmail = "email";
        string expectedListID = "list_id";
        string expectedLocale = "locale";
        string expectedPhoneNumber = "phone_number";
        Preferences expectedPreferences = new()
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
        string expectedTenantID = "tenant_id";
        string expectedUserID = "user_id";

        Assert.Equal(expectedAccountID, deserialized.AccountID);
        Assert.Equal(expectedContext, deserialized.Context);
        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(deserialized.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Data[item.Key]));
        }
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedListID, deserialized.ListID);
        Assert.Equal(expectedLocale, deserialized.Locale);
        Assert.Equal(expectedPhoneNumber, deserialized.PhoneNumber);
        Assert.Equal(expectedPreferences, deserialized.Preferences);
        Assert.Equal(expectedTenantID, deserialized.TenantID);
        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Recipient
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Recipient { };

        Assert.Null(model.AccountID);
        Assert.False(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.Context);
        Assert.False(model.RawData.ContainsKey("context"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.ListID);
        Assert.False(model.RawData.ContainsKey("list_id"));
        Assert.Null(model.Locale);
        Assert.False(model.RawData.ContainsKey("locale"));
        Assert.Null(model.PhoneNumber);
        Assert.False(model.RawData.ContainsKey("phone_number"));
        Assert.Null(model.Preferences);
        Assert.False(model.RawData.ContainsKey("preferences"));
        Assert.Null(model.TenantID);
        Assert.False(model.RawData.ContainsKey("tenant_id"));
        Assert.Null(model.UserID);
        Assert.False(model.RawData.ContainsKey("user_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Recipient { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Recipient
        {
            AccountID = null,
            Context = null,
            Data = null,
            Email = null,
            ListID = null,
            Locale = null,
            PhoneNumber = null,
            Preferences = null,
            TenantID = null,
            UserID = null,
        };

        Assert.Null(model.AccountID);
        Assert.True(model.RawData.ContainsKey("account_id"));
        Assert.Null(model.Context);
        Assert.True(model.RawData.ContainsKey("context"));
        Assert.Null(model.Data);
        Assert.True(model.RawData.ContainsKey("data"));
        Assert.Null(model.Email);
        Assert.True(model.RawData.ContainsKey("email"));
        Assert.Null(model.ListID);
        Assert.True(model.RawData.ContainsKey("list_id"));
        Assert.Null(model.Locale);
        Assert.True(model.RawData.ContainsKey("locale"));
        Assert.Null(model.PhoneNumber);
        Assert.True(model.RawData.ContainsKey("phone_number"));
        Assert.Null(model.Preferences);
        Assert.True(model.RawData.ContainsKey("preferences"));
        Assert.Null(model.TenantID);
        Assert.True(model.RawData.ContainsKey("tenant_id"));
        Assert.Null(model.UserID);
        Assert.True(model.RawData.ContainsKey("user_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Recipient
        {
            AccountID = null,
            Context = null,
            Data = null,
            Email = null,
            ListID = null,
            Locale = null,
            PhoneNumber = null,
            Preferences = null,
            TenantID = null,
            UserID = null,
        };

        model.Validate();
    }
}

public class PreferencesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Preferences
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
        var model = new Preferences
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
        var deserialized = JsonSerializer.Deserialize<Preferences>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Preferences
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
        var deserialized = JsonSerializer.Deserialize<Preferences>(json);
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
        var model = new Preferences
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
        var model = new Preferences
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
        var model = new Preferences
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
        var model = new Preferences
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
        var model = new Preferences
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
