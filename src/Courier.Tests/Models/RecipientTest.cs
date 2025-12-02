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
}
