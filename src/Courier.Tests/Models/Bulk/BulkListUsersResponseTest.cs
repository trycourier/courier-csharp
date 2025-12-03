using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models.Bulk;
using Models = Courier.Models;

namespace Courier.Tests.Models.Bulk;

public class BulkListUsersResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BulkListUsersResponse
        {
            Items =
            [
                new()
                {
                    Data = JsonSerializer.Deserialize<JsonElement>("{}"),
                    Preferences = new()
                    {
                        Categories = new Dictionary<string, Models::NotificationPreferenceDetails>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = Models::PreferenceStatus.OptedIn,
                                    ChannelPreferences =
                                    [
                                        new(Models::ChannelClassification.DirectMessage),
                                    ],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                }
                            },
                        },
                        Notifications = new Dictionary<
                            string,
                            Models::NotificationPreferenceDetails
                        >()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = Models::PreferenceStatus.OptedIn,
                                    ChannelPreferences =
                                    [
                                        new(Models::ChannelClassification.DirectMessage),
                                    ],
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
                            Notifications = new Dictionary<string, Models::Preference>()
                            {
                                {
                                    "foo",
                                    new()
                                    {
                                        Status = Models::PreferenceStatus.OptedIn,
                                        ChannelPreferences =
                                        [
                                            new(Models::ChannelClassification.DirectMessage),
                                        ],
                                        Rules = [new() { Until = "until", Start = "start" }],
                                        Source = Models::Source.Subscription,
                                    }
                                },
                            },
                            Categories = new Dictionary<string, Models::Preference>()
                            {
                                {
                                    "foo",
                                    new()
                                    {
                                        Status = Models::PreferenceStatus.OptedIn,
                                        ChannelPreferences =
                                        [
                                            new(Models::ChannelClassification.DirectMessage),
                                        ],
                                        Rules = [new() { Until = "until", Start = "start" }],
                                        Source = Models::Source.Subscription,
                                    }
                                },
                            },
                            TemplateID = "templateId",
                        },
                        TenantID = "tenant_id",
                        UserID = "user_id",
                    },
                    Status = Status.Pending,
                    MessageID = "messageId",
                },
            ],
            Paging = new() { More = true, Cursor = "cursor" },
        };

        List<Item> expectedItems =
        [
            new()
            {
                Data = JsonSerializer.Deserialize<JsonElement>("{}"),
                Preferences = new()
                {
                    Categories = new Dictionary<string, Models::NotificationPreferenceDetails>()
                    {
                        {
                            "foo",
                            new()
                            {
                                Status = Models::PreferenceStatus.OptedIn,
                                ChannelPreferences =
                                [
                                    new(Models::ChannelClassification.DirectMessage),
                                ],
                                Rules = [new() { Until = "until", Start = "start" }],
                            }
                        },
                    },
                    Notifications = new Dictionary<string, Models::NotificationPreferenceDetails>()
                    {
                        {
                            "foo",
                            new()
                            {
                                Status = Models::PreferenceStatus.OptedIn,
                                ChannelPreferences =
                                [
                                    new(Models::ChannelClassification.DirectMessage),
                                ],
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
                        Notifications = new Dictionary<string, Models::Preference>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = Models::PreferenceStatus.OptedIn,
                                    ChannelPreferences =
                                    [
                                        new(Models::ChannelClassification.DirectMessage),
                                    ],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                    Source = Models::Source.Subscription,
                                }
                            },
                        },
                        Categories = new Dictionary<string, Models::Preference>()
                        {
                            {
                                "foo",
                                new()
                                {
                                    Status = Models::PreferenceStatus.OptedIn,
                                    ChannelPreferences =
                                    [
                                        new(Models::ChannelClassification.DirectMessage),
                                    ],
                                    Rules = [new() { Until = "until", Start = "start" }],
                                    Source = Models::Source.Subscription,
                                }
                            },
                        },
                        TemplateID = "templateId",
                    },
                    TenantID = "tenant_id",
                    UserID = "user_id",
                },
                Status = Status.Pending,
                MessageID = "messageId",
            },
        ];
        Models::Paging expectedPaging = new() { More = true, Cursor = "cursor" };

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedPaging, model.Paging);
    }
}

public class ItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Item
        {
            Data = JsonSerializer.Deserialize<JsonElement>("{}"),
            Preferences = new()
            {
                Categories = new Dictionary<string, Models::NotificationPreferenceDetails>()
                {
                    {
                        "foo",
                        new()
                        {
                            Status = Models::PreferenceStatus.OptedIn,
                            ChannelPreferences = [new(Models::ChannelClassification.DirectMessage)],
                            Rules = [new() { Until = "until", Start = "start" }],
                        }
                    },
                },
                Notifications = new Dictionary<string, Models::NotificationPreferenceDetails>()
                {
                    {
                        "foo",
                        new()
                        {
                            Status = Models::PreferenceStatus.OptedIn,
                            ChannelPreferences = [new(Models::ChannelClassification.DirectMessage)],
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
                    Notifications = new Dictionary<string, Models::Preference>()
                    {
                        {
                            "foo",
                            new()
                            {
                                Status = Models::PreferenceStatus.OptedIn,
                                ChannelPreferences =
                                [
                                    new(Models::ChannelClassification.DirectMessage),
                                ],
                                Rules = [new() { Until = "until", Start = "start" }],
                                Source = Models::Source.Subscription,
                            }
                        },
                    },
                    Categories = new Dictionary<string, Models::Preference>()
                    {
                        {
                            "foo",
                            new()
                            {
                                Status = Models::PreferenceStatus.OptedIn,
                                ChannelPreferences =
                                [
                                    new(Models::ChannelClassification.DirectMessage),
                                ],
                                Rules = [new() { Until = "until", Start = "start" }],
                                Source = Models::Source.Subscription,
                            }
                        },
                    },
                    TemplateID = "templateId",
                },
                TenantID = "tenant_id",
                UserID = "user_id",
            },
            Status = Status.Pending,
            MessageID = "messageId",
        };

        JsonElement expectedData = JsonSerializer.Deserialize<JsonElement>("{}");
        Models::RecipientPreferences expectedPreferences = new()
        {
            Categories = new Dictionary<string, Models::NotificationPreferenceDetails>()
            {
                {
                    "foo",
                    new()
                    {
                        Status = Models::PreferenceStatus.OptedIn,
                        ChannelPreferences = [new(Models::ChannelClassification.DirectMessage)],
                        Rules = [new() { Until = "until", Start = "start" }],
                    }
                },
            },
            Notifications = new Dictionary<string, Models::NotificationPreferenceDetails>()
            {
                {
                    "foo",
                    new()
                    {
                        Status = Models::PreferenceStatus.OptedIn,
                        ChannelPreferences = [new(Models::ChannelClassification.DirectMessage)],
                        Rules = [new() { Until = "until", Start = "start" }],
                    }
                },
            },
        };
        JsonElement expectedProfile = JsonSerializer.Deserialize<JsonElement>("{}");
        string expectedRecipient = "recipient";
        Models::UserRecipient expectedTo = new()
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
                Notifications = new Dictionary<string, Models::Preference>()
                {
                    {
                        "foo",
                        new()
                        {
                            Status = Models::PreferenceStatus.OptedIn,
                            ChannelPreferences = [new(Models::ChannelClassification.DirectMessage)],
                            Rules = [new() { Until = "until", Start = "start" }],
                            Source = Models::Source.Subscription,
                        }
                    },
                },
                Categories = new Dictionary<string, Models::Preference>()
                {
                    {
                        "foo",
                        new()
                        {
                            Status = Models::PreferenceStatus.OptedIn,
                            ChannelPreferences = [new(Models::ChannelClassification.DirectMessage)],
                            Rules = [new() { Until = "until", Start = "start" }],
                            Source = Models::Source.Subscription,
                        }
                    },
                },
                TemplateID = "templateId",
            },
            TenantID = "tenant_id",
            UserID = "user_id",
        };
        ApiEnum<string, Status> expectedStatus = Status.Pending;
        string expectedMessageID = "messageId";

        Assert.True(model.Data.HasValue && JsonElement.DeepEquals(expectedData, model.Data.Value));
        Assert.Equal(expectedPreferences, model.Preferences);
        Assert.True(
            model.Profile.HasValue && JsonElement.DeepEquals(expectedProfile, model.Profile.Value)
        );
        Assert.Equal(expectedRecipient, model.Recipient);
        Assert.Equal(expectedTo, model.To);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedMessageID, model.MessageID);
    }
}

public class IntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntersectionMember1 { Status = Status.Pending, MessageID = "messageId" };

        ApiEnum<string, Status> expectedStatus = Status.Pending;
        string expectedMessageID = "messageId";

        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedMessageID, model.MessageID);
    }
}
