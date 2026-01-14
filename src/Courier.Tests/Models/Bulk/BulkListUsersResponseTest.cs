using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
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
                    Profile = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
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
                Profile = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
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

    [Fact]
    public void SerializationRoundtrip_Works()
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
                    Profile = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BulkListUsersResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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
                    Profile = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BulkListUsersResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

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
                Profile = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
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

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedPaging, deserialized.Paging);
    }

    [Fact]
    public void Validation_Works()
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
                    Profile = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
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

        model.Validate();
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
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
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
        Dictionary<string, JsonElement> expectedProfile = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
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

        Assert.NotNull(model.Data);
        Assert.True(JsonElement.DeepEquals(expectedData, model.Data.Value));
        Assert.Equal(expectedPreferences, model.Preferences);
        Assert.NotNull(model.Profile);
        Assert.Equal(expectedProfile.Count, model.Profile.Count);
        foreach (var item in expectedProfile)
        {
            Assert.True(model.Profile.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Profile[item.Key]));
        }
        Assert.Equal(expectedRecipient, model.Recipient);
        Assert.Equal(expectedTo, model.To);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedMessageID, model.MessageID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
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
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
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
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Item>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

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
        Dictionary<string, JsonElement> expectedProfile = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
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

        Assert.NotNull(deserialized.Data);
        Assert.True(JsonElement.DeepEquals(expectedData, deserialized.Data.Value));
        Assert.Equal(expectedPreferences, deserialized.Preferences);
        Assert.NotNull(deserialized.Profile);
        Assert.Equal(expectedProfile.Count, deserialized.Profile.Count);
        foreach (var item in expectedProfile)
        {
            Assert.True(deserialized.Profile.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Profile[item.Key]));
        }
        Assert.Equal(expectedRecipient, deserialized.Recipient);
        Assert.Equal(expectedTo, deserialized.To);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedMessageID, deserialized.MessageID);
    }

    [Fact]
    public void Validation_Works()
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
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Item
        {
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Recipient = "recipient",
            Status = Status.Pending,
            MessageID = "messageId",
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Preferences);
        Assert.False(model.RawData.ContainsKey("preferences"));
        Assert.Null(model.To);
        Assert.False(model.RawData.ContainsKey("to"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Item
        {
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Recipient = "recipient",
            Status = Status.Pending,
            MessageID = "messageId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Item
        {
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Recipient = "recipient",
            Status = Status.Pending,
            MessageID = "messageId",

            // Null should be interpreted as omitted for these properties
            Data = null,
            Preferences = null,
            To = null,
        };

        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Preferences);
        Assert.False(model.RawData.ContainsKey("preferences"));
        Assert.Null(model.To);
        Assert.False(model.RawData.ContainsKey("to"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Item
        {
            Profile = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Recipient = "recipient",
            Status = Status.Pending,
            MessageID = "messageId",

            // Null should be interpreted as omitted for these properties
            Data = null,
            Preferences = null,
            To = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
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
        };

        Assert.Null(model.Profile);
        Assert.False(model.RawData.ContainsKey("profile"));
        Assert.Null(model.Recipient);
        Assert.False(model.RawData.ContainsKey("recipient"));
        Assert.Null(model.MessageID);
        Assert.False(model.RawData.ContainsKey("messageId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
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

            Profile = null,
            Recipient = null,
            MessageID = null,
        };

        Assert.Null(model.Profile);
        Assert.True(model.RawData.ContainsKey("profile"));
        Assert.Null(model.Recipient);
        Assert.True(model.RawData.ContainsKey("recipient"));
        Assert.Null(model.MessageID);
        Assert.True(model.RawData.ContainsKey("messageId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
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

            Profile = null,
            Recipient = null,
            MessageID = null,
        };

        model.Validate();
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntersectionMember1 { Status = Status.Pending, MessageID = "messageId" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntersectionMember1 { Status = Status.Pending, MessageID = "messageId" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Status> expectedStatus = Status.Pending;
        string expectedMessageID = "messageId";

        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedMessageID, deserialized.MessageID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IntersectionMember1 { Status = Status.Pending, MessageID = "messageId" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new IntersectionMember1 { Status = Status.Pending };

        Assert.Null(model.MessageID);
        Assert.False(model.RawData.ContainsKey("messageId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new IntersectionMember1 { Status = Status.Pending };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new IntersectionMember1
        {
            Status = Status.Pending,

            MessageID = null,
        };

        Assert.Null(model.MessageID);
        Assert.True(model.RawData.ContainsKey("messageId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new IntersectionMember1
        {
            Status = Status.Pending,

            MessageID = null,
        };

        model.Validate();
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Enqueued)]
    [InlineData(Status.Error)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Pending)]
    [InlineData(Status.Enqueued)]
    [InlineData(Status.Error)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
