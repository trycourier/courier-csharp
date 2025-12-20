using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Send;
using Models = Courier.Models;

namespace Courier.Tests.Models.Send;

public class SendMessageParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SendMessageParams
        {
            Message = new()
            {
                BrandID = "brand_id",
                Channels = new Dictionary<string, ChannelsItem>()
                {
                    {
                        "foo",
                        new()
                        {
                            BrandID = "brand_id",
                            If = "if",
                            Metadata = new()
                            {
                                Utm = new()
                                {
                                    Campaign = "campaign",
                                    Content = "content",
                                    Medium = "medium",
                                    Source = "source",
                                    Term = "term",
                                },
                            },
                            Override = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Providers = ["string"],
                            RoutingMethod = RoutingMethod.All,
                            Timeouts = new() { Channel = 0, Provider = 0 },
                        }
                    },
                },
                Content = new Models::ElementalContentSugar() { Body = "body", Title = "title" },
                Context = new() { TenantID = "tenant_id" },
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Delay = new()
                {
                    Duration = 0,
                    Timezone = "timezone",
                    Until = "until",
                },
                Expiry = new() { ExpiresIn = "string", ExpiresAt = "expires_at" },
                Metadata = new()
                {
                    Event = "event",
                    Tags = ["string"],
                    TraceID = "trace_id",
                    Utm = new()
                    {
                        Campaign = "campaign",
                        Content = "content",
                        Medium = "medium",
                        Source = "source",
                        Term = "term",
                    },
                },
                Preferences = new("subscription_topic_id"),
                Providers = new Dictionary<string, ProvidersItem>()
                {
                    {
                        "foo",
                        new()
                        {
                            If = "if",
                            Metadata = new()
                            {
                                Utm = new()
                                {
                                    Campaign = "campaign",
                                    Content = "content",
                                    Medium = "medium",
                                    Source = "source",
                                    Term = "term",
                                },
                            },
                            Override = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Timeouts = 0,
                        }
                    },
                },
                Routing = new() { Channels = ["string"], Method = Method.All },
                Template = "template_id",
                Timeout = new()
                {
                    Channel = new Dictionary<string, long>() { { "foo", 0 } },
                    Criteria = Criteria.NoEscalation,
                    Escalation = 0,
                    Message = 0,
                    Provider = new Dictionary<string, long>() { { "foo", 0 } },
                },
                To = new Models::UserRecipient()
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
                    UserID = "example_user",
                },
            },
        };

        Message expectedMessage = new()
        {
            BrandID = "brand_id",
            Channels = new Dictionary<string, ChannelsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        BrandID = "brand_id",
                        If = "if",
                        Metadata = new()
                        {
                            Utm = new()
                            {
                                Campaign = "campaign",
                                Content = "content",
                                Medium = "medium",
                                Source = "source",
                                Term = "term",
                            },
                        },
                        Override = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Providers = ["string"],
                        RoutingMethod = RoutingMethod.All,
                        Timeouts = new() { Channel = 0, Provider = 0 },
                    }
                },
            },
            Content = new Models::ElementalContentSugar() { Body = "body", Title = "title" },
            Context = new() { TenantID = "tenant_id" },
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Delay = new()
            {
                Duration = 0,
                Timezone = "timezone",
                Until = "until",
            },
            Expiry = new() { ExpiresIn = "string", ExpiresAt = "expires_at" },
            Metadata = new()
            {
                Event = "event",
                Tags = ["string"],
                TraceID = "trace_id",
                Utm = new()
                {
                    Campaign = "campaign",
                    Content = "content",
                    Medium = "medium",
                    Source = "source",
                    Term = "term",
                },
            },
            Preferences = new("subscription_topic_id"),
            Providers = new Dictionary<string, ProvidersItem>()
            {
                {
                    "foo",
                    new()
                    {
                        If = "if",
                        Metadata = new()
                        {
                            Utm = new()
                            {
                                Campaign = "campaign",
                                Content = "content",
                                Medium = "medium",
                                Source = "source",
                                Term = "term",
                            },
                        },
                        Override = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Timeouts = 0,
                    }
                },
            },
            Routing = new() { Channels = ["string"], Method = Method.All },
            Template = "template_id",
            Timeout = new()
            {
                Channel = new Dictionary<string, long>() { { "foo", 0 } },
                Criteria = Criteria.NoEscalation,
                Escalation = 0,
                Message = 0,
                Provider = new Dictionary<string, long>() { { "foo", 0 } },
            },
            To = new Models::UserRecipient()
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
                UserID = "example_user",
            },
        };

        Assert.Equal(expectedMessage, parameters.Message);
    }
}

public class MessageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Message
        {
            BrandID = "brand_id",
            Channels = new Dictionary<string, ChannelsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        BrandID = "brand_id",
                        If = "if",
                        Metadata = new()
                        {
                            Utm = new()
                            {
                                Campaign = "campaign",
                                Content = "content",
                                Medium = "medium",
                                Source = "source",
                                Term = "term",
                            },
                        },
                        Override = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Providers = ["string"],
                        RoutingMethod = RoutingMethod.All,
                        Timeouts = new() { Channel = 0, Provider = 0 },
                    }
                },
            },
            Content = new Models::ElementalContentSugar() { Body = "body", Title = "title" },
            Context = new() { TenantID = "tenant_id" },
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Delay = new()
            {
                Duration = 0,
                Timezone = "timezone",
                Until = "until",
            },
            Expiry = new() { ExpiresIn = "string", ExpiresAt = "expires_at" },
            Metadata = new()
            {
                Event = "event",
                Tags = ["string"],
                TraceID = "trace_id",
                Utm = new()
                {
                    Campaign = "campaign",
                    Content = "content",
                    Medium = "medium",
                    Source = "source",
                    Term = "term",
                },
            },
            Preferences = new("subscription_topic_id"),
            Providers = new Dictionary<string, ProvidersItem>()
            {
                {
                    "foo",
                    new()
                    {
                        If = "if",
                        Metadata = new()
                        {
                            Utm = new()
                            {
                                Campaign = "campaign",
                                Content = "content",
                                Medium = "medium",
                                Source = "source",
                                Term = "term",
                            },
                        },
                        Override = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Timeouts = 0,
                    }
                },
            },
            Routing = new() { Channels = ["string"], Method = Method.All },
            Template = "template",
            Timeout = new()
            {
                Channel = new Dictionary<string, long>() { { "foo", 0 } },
                Criteria = Criteria.NoEscalation,
                Escalation = 0,
                Message = 0,
                Provider = new Dictionary<string, long>() { { "foo", 0 } },
            },
            To = new Models::UserRecipient()
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
        };

        string expectedBrandID = "brand_id";
        Dictionary<string, ChannelsItem> expectedChannels = new()
        {
            {
                "foo",
                new()
                {
                    BrandID = "brand_id",
                    If = "if",
                    Metadata = new()
                    {
                        Utm = new()
                        {
                            Campaign = "campaign",
                            Content = "content",
                            Medium = "medium",
                            Source = "source",
                            Term = "term",
                        },
                    },
                    Override = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Providers = ["string"],
                    RoutingMethod = RoutingMethod.All,
                    Timeouts = new() { Channel = 0, Provider = 0 },
                }
            },
        };
        Content expectedContent = new Models::ElementalContentSugar()
        {
            Body = "body",
            Title = "title",
        };
        Models::MessageContext expectedContext = new() { TenantID = "tenant_id" };
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Delay expectedDelay = new()
        {
            Duration = 0,
            Timezone = "timezone",
            Until = "until",
        };
        Expiry expectedExpiry = new() { ExpiresIn = "string", ExpiresAt = "expires_at" };
        MessageMetadata expectedMetadata = new()
        {
            Event = "event",
            Tags = ["string"],
            TraceID = "trace_id",
            Utm = new()
            {
                Campaign = "campaign",
                Content = "content",
                Medium = "medium",
                Source = "source",
                Term = "term",
            },
        };
        Preferences expectedPreferences = new("subscription_topic_id");
        Dictionary<string, ProvidersItem> expectedProviders = new()
        {
            {
                "foo",
                new()
                {
                    If = "if",
                    Metadata = new()
                    {
                        Utm = new()
                        {
                            Campaign = "campaign",
                            Content = "content",
                            Medium = "medium",
                            Source = "source",
                            Term = "term",
                        },
                    },
                    Override = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Timeouts = 0,
                }
            },
        };
        Routing expectedRouting = new() { Channels = ["string"], Method = Method.All };
        string expectedTemplate = "template";
        Timeout expectedTimeout = new()
        {
            Channel = new Dictionary<string, long>() { { "foo", 0 } },
            Criteria = Criteria.NoEscalation,
            Escalation = 0,
            Message = 0,
            Provider = new Dictionary<string, long>() { { "foo", 0 } },
        };
        To expectedTo = new Models::UserRecipient()
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

        Assert.Equal(expectedBrandID, model.BrandID);
        Assert.NotNull(model.Channels);
        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        foreach (var item in expectedChannels)
        {
            Assert.True(model.Channels.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Channels[item.Key]);
        }
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedContext, model.Context);
        Assert.NotNull(model.Data);
        Assert.Equal(expectedData.Count, model.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(model.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Data[item.Key]));
        }
        Assert.Equal(expectedDelay, model.Delay);
        Assert.Equal(expectedExpiry, model.Expiry);
        Assert.Equal(expectedMetadata, model.Metadata);
        Assert.Equal(expectedPreferences, model.Preferences);
        Assert.NotNull(model.Providers);
        Assert.Equal(expectedProviders.Count, model.Providers.Count);
        foreach (var item in expectedProviders)
        {
            Assert.True(model.Providers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Providers[item.Key]);
        }
        Assert.Equal(expectedRouting, model.Routing);
        Assert.Equal(expectedTemplate, model.Template);
        Assert.Equal(expectedTimeout, model.Timeout);
        Assert.Equal(expectedTo, model.To);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Message
        {
            BrandID = "brand_id",
            Channels = new Dictionary<string, ChannelsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        BrandID = "brand_id",
                        If = "if",
                        Metadata = new()
                        {
                            Utm = new()
                            {
                                Campaign = "campaign",
                                Content = "content",
                                Medium = "medium",
                                Source = "source",
                                Term = "term",
                            },
                        },
                        Override = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Providers = ["string"],
                        RoutingMethod = RoutingMethod.All,
                        Timeouts = new() { Channel = 0, Provider = 0 },
                    }
                },
            },
            Content = new Models::ElementalContentSugar() { Body = "body", Title = "title" },
            Context = new() { TenantID = "tenant_id" },
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Delay = new()
            {
                Duration = 0,
                Timezone = "timezone",
                Until = "until",
            },
            Expiry = new() { ExpiresIn = "string", ExpiresAt = "expires_at" },
            Metadata = new()
            {
                Event = "event",
                Tags = ["string"],
                TraceID = "trace_id",
                Utm = new()
                {
                    Campaign = "campaign",
                    Content = "content",
                    Medium = "medium",
                    Source = "source",
                    Term = "term",
                },
            },
            Preferences = new("subscription_topic_id"),
            Providers = new Dictionary<string, ProvidersItem>()
            {
                {
                    "foo",
                    new()
                    {
                        If = "if",
                        Metadata = new()
                        {
                            Utm = new()
                            {
                                Campaign = "campaign",
                                Content = "content",
                                Medium = "medium",
                                Source = "source",
                                Term = "term",
                            },
                        },
                        Override = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Timeouts = 0,
                    }
                },
            },
            Routing = new() { Channels = ["string"], Method = Method.All },
            Template = "template",
            Timeout = new()
            {
                Channel = new Dictionary<string, long>() { { "foo", 0 } },
                Criteria = Criteria.NoEscalation,
                Escalation = 0,
                Message = 0,
                Provider = new Dictionary<string, long>() { { "foo", 0 } },
            },
            To = new Models::UserRecipient()
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Message>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Message
        {
            BrandID = "brand_id",
            Channels = new Dictionary<string, ChannelsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        BrandID = "brand_id",
                        If = "if",
                        Metadata = new()
                        {
                            Utm = new()
                            {
                                Campaign = "campaign",
                                Content = "content",
                                Medium = "medium",
                                Source = "source",
                                Term = "term",
                            },
                        },
                        Override = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Providers = ["string"],
                        RoutingMethod = RoutingMethod.All,
                        Timeouts = new() { Channel = 0, Provider = 0 },
                    }
                },
            },
            Content = new Models::ElementalContentSugar() { Body = "body", Title = "title" },
            Context = new() { TenantID = "tenant_id" },
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Delay = new()
            {
                Duration = 0,
                Timezone = "timezone",
                Until = "until",
            },
            Expiry = new() { ExpiresIn = "string", ExpiresAt = "expires_at" },
            Metadata = new()
            {
                Event = "event",
                Tags = ["string"],
                TraceID = "trace_id",
                Utm = new()
                {
                    Campaign = "campaign",
                    Content = "content",
                    Medium = "medium",
                    Source = "source",
                    Term = "term",
                },
            },
            Preferences = new("subscription_topic_id"),
            Providers = new Dictionary<string, ProvidersItem>()
            {
                {
                    "foo",
                    new()
                    {
                        If = "if",
                        Metadata = new()
                        {
                            Utm = new()
                            {
                                Campaign = "campaign",
                                Content = "content",
                                Medium = "medium",
                                Source = "source",
                                Term = "term",
                            },
                        },
                        Override = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Timeouts = 0,
                    }
                },
            },
            Routing = new() { Channels = ["string"], Method = Method.All },
            Template = "template",
            Timeout = new()
            {
                Channel = new Dictionary<string, long>() { { "foo", 0 } },
                Criteria = Criteria.NoEscalation,
                Escalation = 0,
                Message = 0,
                Provider = new Dictionary<string, long>() { { "foo", 0 } },
            },
            To = new Models::UserRecipient()
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
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Message>(element);
        Assert.NotNull(deserialized);

        string expectedBrandID = "brand_id";
        Dictionary<string, ChannelsItem> expectedChannels = new()
        {
            {
                "foo",
                new()
                {
                    BrandID = "brand_id",
                    If = "if",
                    Metadata = new()
                    {
                        Utm = new()
                        {
                            Campaign = "campaign",
                            Content = "content",
                            Medium = "medium",
                            Source = "source",
                            Term = "term",
                        },
                    },
                    Override = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Providers = ["string"],
                    RoutingMethod = RoutingMethod.All,
                    Timeouts = new() { Channel = 0, Provider = 0 },
                }
            },
        };
        Content expectedContent = new Models::ElementalContentSugar()
        {
            Body = "body",
            Title = "title",
        };
        Models::MessageContext expectedContext = new() { TenantID = "tenant_id" };
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Delay expectedDelay = new()
        {
            Duration = 0,
            Timezone = "timezone",
            Until = "until",
        };
        Expiry expectedExpiry = new() { ExpiresIn = "string", ExpiresAt = "expires_at" };
        MessageMetadata expectedMetadata = new()
        {
            Event = "event",
            Tags = ["string"],
            TraceID = "trace_id",
            Utm = new()
            {
                Campaign = "campaign",
                Content = "content",
                Medium = "medium",
                Source = "source",
                Term = "term",
            },
        };
        Preferences expectedPreferences = new("subscription_topic_id");
        Dictionary<string, ProvidersItem> expectedProviders = new()
        {
            {
                "foo",
                new()
                {
                    If = "if",
                    Metadata = new()
                    {
                        Utm = new()
                        {
                            Campaign = "campaign",
                            Content = "content",
                            Medium = "medium",
                            Source = "source",
                            Term = "term",
                        },
                    },
                    Override = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Timeouts = 0,
                }
            },
        };
        Routing expectedRouting = new() { Channels = ["string"], Method = Method.All };
        string expectedTemplate = "template";
        Timeout expectedTimeout = new()
        {
            Channel = new Dictionary<string, long>() { { "foo", 0 } },
            Criteria = Criteria.NoEscalation,
            Escalation = 0,
            Message = 0,
            Provider = new Dictionary<string, long>() { { "foo", 0 } },
        };
        To expectedTo = new Models::UserRecipient()
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

        Assert.Equal(expectedBrandID, deserialized.BrandID);
        Assert.NotNull(deserialized.Channels);
        Assert.Equal(expectedChannels.Count, deserialized.Channels.Count);
        foreach (var item in expectedChannels)
        {
            Assert.True(deserialized.Channels.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Channels[item.Key]);
        }
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedContext, deserialized.Context);
        Assert.NotNull(deserialized.Data);
        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(deserialized.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Data[item.Key]));
        }
        Assert.Equal(expectedDelay, deserialized.Delay);
        Assert.Equal(expectedExpiry, deserialized.Expiry);
        Assert.Equal(expectedMetadata, deserialized.Metadata);
        Assert.Equal(expectedPreferences, deserialized.Preferences);
        Assert.NotNull(deserialized.Providers);
        Assert.Equal(expectedProviders.Count, deserialized.Providers.Count);
        foreach (var item in expectedProviders)
        {
            Assert.True(deserialized.Providers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Providers[item.Key]);
        }
        Assert.Equal(expectedRouting, deserialized.Routing);
        Assert.Equal(expectedTemplate, deserialized.Template);
        Assert.Equal(expectedTimeout, deserialized.Timeout);
        Assert.Equal(expectedTo, deserialized.To);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Message
        {
            BrandID = "brand_id",
            Channels = new Dictionary<string, ChannelsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        BrandID = "brand_id",
                        If = "if",
                        Metadata = new()
                        {
                            Utm = new()
                            {
                                Campaign = "campaign",
                                Content = "content",
                                Medium = "medium",
                                Source = "source",
                                Term = "term",
                            },
                        },
                        Override = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Providers = ["string"],
                        RoutingMethod = RoutingMethod.All,
                        Timeouts = new() { Channel = 0, Provider = 0 },
                    }
                },
            },
            Content = new Models::ElementalContentSugar() { Body = "body", Title = "title" },
            Context = new() { TenantID = "tenant_id" },
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Delay = new()
            {
                Duration = 0,
                Timezone = "timezone",
                Until = "until",
            },
            Expiry = new() { ExpiresIn = "string", ExpiresAt = "expires_at" },
            Metadata = new()
            {
                Event = "event",
                Tags = ["string"],
                TraceID = "trace_id",
                Utm = new()
                {
                    Campaign = "campaign",
                    Content = "content",
                    Medium = "medium",
                    Source = "source",
                    Term = "term",
                },
            },
            Preferences = new("subscription_topic_id"),
            Providers = new Dictionary<string, ProvidersItem>()
            {
                {
                    "foo",
                    new()
                    {
                        If = "if",
                        Metadata = new()
                        {
                            Utm = new()
                            {
                                Campaign = "campaign",
                                Content = "content",
                                Medium = "medium",
                                Source = "source",
                                Term = "term",
                            },
                        },
                        Override = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Timeouts = 0,
                    }
                },
            },
            Routing = new() { Channels = ["string"], Method = Method.All },
            Template = "template",
            Timeout = new()
            {
                Channel = new Dictionary<string, long>() { { "foo", 0 } },
                Criteria = Criteria.NoEscalation,
                Escalation = 0,
                Message = 0,
                Provider = new Dictionary<string, long>() { { "foo", 0 } },
            },
            To = new Models::UserRecipient()
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Message
        {
            BrandID = "brand_id",
            Channels = new Dictionary<string, ChannelsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        BrandID = "brand_id",
                        If = "if",
                        Metadata = new()
                        {
                            Utm = new()
                            {
                                Campaign = "campaign",
                                Content = "content",
                                Medium = "medium",
                                Source = "source",
                                Term = "term",
                            },
                        },
                        Override = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Providers = ["string"],
                        RoutingMethod = RoutingMethod.All,
                        Timeouts = new() { Channel = 0, Provider = 0 },
                    }
                },
            },
            Context = new() { TenantID = "tenant_id" },
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Delay = new()
            {
                Duration = 0,
                Timezone = "timezone",
                Until = "until",
            },
            Expiry = new() { ExpiresIn = "string", ExpiresAt = "expires_at" },
            Metadata = new()
            {
                Event = "event",
                Tags = ["string"],
                TraceID = "trace_id",
                Utm = new()
                {
                    Campaign = "campaign",
                    Content = "content",
                    Medium = "medium",
                    Source = "source",
                    Term = "term",
                },
            },
            Preferences = new("subscription_topic_id"),
            Providers = new Dictionary<string, ProvidersItem>()
            {
                {
                    "foo",
                    new()
                    {
                        If = "if",
                        Metadata = new()
                        {
                            Utm = new()
                            {
                                Campaign = "campaign",
                                Content = "content",
                                Medium = "medium",
                                Source = "source",
                                Term = "term",
                            },
                        },
                        Override = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Timeouts = 0,
                    }
                },
            },
            Routing = new() { Channels = ["string"], Method = Method.All },
            Template = "template",
            Timeout = new()
            {
                Channel = new Dictionary<string, long>() { { "foo", 0 } },
                Criteria = Criteria.NoEscalation,
                Escalation = 0,
                Message = 0,
                Provider = new Dictionary<string, long>() { { "foo", 0 } },
            },
            To = new Models::UserRecipient()
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
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Message
        {
            BrandID = "brand_id",
            Channels = new Dictionary<string, ChannelsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        BrandID = "brand_id",
                        If = "if",
                        Metadata = new()
                        {
                            Utm = new()
                            {
                                Campaign = "campaign",
                                Content = "content",
                                Medium = "medium",
                                Source = "source",
                                Term = "term",
                            },
                        },
                        Override = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Providers = ["string"],
                        RoutingMethod = RoutingMethod.All,
                        Timeouts = new() { Channel = 0, Provider = 0 },
                    }
                },
            },
            Context = new() { TenantID = "tenant_id" },
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Delay = new()
            {
                Duration = 0,
                Timezone = "timezone",
                Until = "until",
            },
            Expiry = new() { ExpiresIn = "string", ExpiresAt = "expires_at" },
            Metadata = new()
            {
                Event = "event",
                Tags = ["string"],
                TraceID = "trace_id",
                Utm = new()
                {
                    Campaign = "campaign",
                    Content = "content",
                    Medium = "medium",
                    Source = "source",
                    Term = "term",
                },
            },
            Preferences = new("subscription_topic_id"),
            Providers = new Dictionary<string, ProvidersItem>()
            {
                {
                    "foo",
                    new()
                    {
                        If = "if",
                        Metadata = new()
                        {
                            Utm = new()
                            {
                                Campaign = "campaign",
                                Content = "content",
                                Medium = "medium",
                                Source = "source",
                                Term = "term",
                            },
                        },
                        Override = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Timeouts = 0,
                    }
                },
            },
            Routing = new() { Channels = ["string"], Method = Method.All },
            Template = "template",
            Timeout = new()
            {
                Channel = new Dictionary<string, long>() { { "foo", 0 } },
                Criteria = Criteria.NoEscalation,
                Escalation = 0,
                Message = 0,
                Provider = new Dictionary<string, long>() { { "foo", 0 } },
            },
            To = new Models::UserRecipient()
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Message
        {
            BrandID = "brand_id",
            Channels = new Dictionary<string, ChannelsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        BrandID = "brand_id",
                        If = "if",
                        Metadata = new()
                        {
                            Utm = new()
                            {
                                Campaign = "campaign",
                                Content = "content",
                                Medium = "medium",
                                Source = "source",
                                Term = "term",
                            },
                        },
                        Override = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Providers = ["string"],
                        RoutingMethod = RoutingMethod.All,
                        Timeouts = new() { Channel = 0, Provider = 0 },
                    }
                },
            },
            Context = new() { TenantID = "tenant_id" },
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Delay = new()
            {
                Duration = 0,
                Timezone = "timezone",
                Until = "until",
            },
            Expiry = new() { ExpiresIn = "string", ExpiresAt = "expires_at" },
            Metadata = new()
            {
                Event = "event",
                Tags = ["string"],
                TraceID = "trace_id",
                Utm = new()
                {
                    Campaign = "campaign",
                    Content = "content",
                    Medium = "medium",
                    Source = "source",
                    Term = "term",
                },
            },
            Preferences = new("subscription_topic_id"),
            Providers = new Dictionary<string, ProvidersItem>()
            {
                {
                    "foo",
                    new()
                    {
                        If = "if",
                        Metadata = new()
                        {
                            Utm = new()
                            {
                                Campaign = "campaign",
                                Content = "content",
                                Medium = "medium",
                                Source = "source",
                                Term = "term",
                            },
                        },
                        Override = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Timeouts = 0,
                    }
                },
            },
            Routing = new() { Channels = ["string"], Method = Method.All },
            Template = "template",
            Timeout = new()
            {
                Channel = new Dictionary<string, long>() { { "foo", 0 } },
                Criteria = Criteria.NoEscalation,
                Escalation = 0,
                Message = 0,
                Provider = new Dictionary<string, long>() { { "foo", 0 } },
            },
            To = new Models::UserRecipient()
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

            // Null should be interpreted as omitted for these properties
            Content = null,
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Message
        {
            BrandID = "brand_id",
            Channels = new Dictionary<string, ChannelsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        BrandID = "brand_id",
                        If = "if",
                        Metadata = new()
                        {
                            Utm = new()
                            {
                                Campaign = "campaign",
                                Content = "content",
                                Medium = "medium",
                                Source = "source",
                                Term = "term",
                            },
                        },
                        Override = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Providers = ["string"],
                        RoutingMethod = RoutingMethod.All,
                        Timeouts = new() { Channel = 0, Provider = 0 },
                    }
                },
            },
            Context = new() { TenantID = "tenant_id" },
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Delay = new()
            {
                Duration = 0,
                Timezone = "timezone",
                Until = "until",
            },
            Expiry = new() { ExpiresIn = "string", ExpiresAt = "expires_at" },
            Metadata = new()
            {
                Event = "event",
                Tags = ["string"],
                TraceID = "trace_id",
                Utm = new()
                {
                    Campaign = "campaign",
                    Content = "content",
                    Medium = "medium",
                    Source = "source",
                    Term = "term",
                },
            },
            Preferences = new("subscription_topic_id"),
            Providers = new Dictionary<string, ProvidersItem>()
            {
                {
                    "foo",
                    new()
                    {
                        If = "if",
                        Metadata = new()
                        {
                            Utm = new()
                            {
                                Campaign = "campaign",
                                Content = "content",
                                Medium = "medium",
                                Source = "source",
                                Term = "term",
                            },
                        },
                        Override = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Timeouts = 0,
                    }
                },
            },
            Routing = new() { Channels = ["string"], Method = Method.All },
            Template = "template",
            Timeout = new()
            {
                Channel = new Dictionary<string, long>() { { "foo", 0 } },
                Criteria = Criteria.NoEscalation,
                Escalation = 0,
                Message = 0,
                Provider = new Dictionary<string, long>() { { "foo", 0 } },
            },
            To = new Models::UserRecipient()
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

            // Null should be interpreted as omitted for these properties
            Content = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Message
        {
            Content = new Models::ElementalContentSugar() { Body = "body", Title = "title" },
        };

        Assert.Null(model.BrandID);
        Assert.False(model.RawData.ContainsKey("brand_id"));
        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.Context);
        Assert.False(model.RawData.ContainsKey("context"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Delay);
        Assert.False(model.RawData.ContainsKey("delay"));
        Assert.Null(model.Expiry);
        Assert.False(model.RawData.ContainsKey("expiry"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Preferences);
        Assert.False(model.RawData.ContainsKey("preferences"));
        Assert.Null(model.Providers);
        Assert.False(model.RawData.ContainsKey("providers"));
        Assert.Null(model.Routing);
        Assert.False(model.RawData.ContainsKey("routing"));
        Assert.Null(model.Template);
        Assert.False(model.RawData.ContainsKey("template"));
        Assert.Null(model.Timeout);
        Assert.False(model.RawData.ContainsKey("timeout"));
        Assert.Null(model.To);
        Assert.False(model.RawData.ContainsKey("to"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Message
        {
            Content = new Models::ElementalContentSugar() { Body = "body", Title = "title" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Message
        {
            Content = new Models::ElementalContentSugar() { Body = "body", Title = "title" },

            BrandID = null,
            Channels = null,
            Context = null,
            Data = null,
            Delay = null,
            Expiry = null,
            Metadata = null,
            Preferences = null,
            Providers = null,
            Routing = null,
            Template = null,
            Timeout = null,
            To = null,
        };

        Assert.Null(model.BrandID);
        Assert.True(model.RawData.ContainsKey("brand_id"));
        Assert.Null(model.Channels);
        Assert.True(model.RawData.ContainsKey("channels"));
        Assert.Null(model.Context);
        Assert.True(model.RawData.ContainsKey("context"));
        Assert.Null(model.Data);
        Assert.True(model.RawData.ContainsKey("data"));
        Assert.Null(model.Delay);
        Assert.True(model.RawData.ContainsKey("delay"));
        Assert.Null(model.Expiry);
        Assert.True(model.RawData.ContainsKey("expiry"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Preferences);
        Assert.True(model.RawData.ContainsKey("preferences"));
        Assert.Null(model.Providers);
        Assert.True(model.RawData.ContainsKey("providers"));
        Assert.Null(model.Routing);
        Assert.True(model.RawData.ContainsKey("routing"));
        Assert.Null(model.Template);
        Assert.True(model.RawData.ContainsKey("template"));
        Assert.Null(model.Timeout);
        Assert.True(model.RawData.ContainsKey("timeout"));
        Assert.Null(model.To);
        Assert.True(model.RawData.ContainsKey("to"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Message
        {
            Content = new Models::ElementalContentSugar() { Body = "body", Title = "title" },

            BrandID = null,
            Channels = null,
            Context = null,
            Data = null,
            Delay = null,
            Expiry = null,
            Metadata = null,
            Preferences = null,
            Providers = null,
            Routing = null,
            Template = null,
            Timeout = null,
            To = null,
        };

        model.Validate();
    }
}

public class ChannelsItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChannelsItem
        {
            BrandID = "brand_id",
            If = "if",
            Metadata = new()
            {
                Utm = new()
                {
                    Campaign = "campaign",
                    Content = "content",
                    Medium = "medium",
                    Source = "source",
                    Term = "term",
                },
            },
            Override = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Providers = ["string"],
            RoutingMethod = RoutingMethod.All,
            Timeouts = new() { Channel = 0, Provider = 0 },
        };

        string expectedBrandID = "brand_id";
        string expectedIf = "if";
        Metadata expectedMetadata = new()
        {
            Utm = new()
            {
                Campaign = "campaign",
                Content = "content",
                Medium = "medium",
                Source = "source",
                Term = "term",
            },
        };
        Dictionary<string, JsonElement> expectedOverride = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        List<string> expectedProviders = ["string"];
        ApiEnum<string, RoutingMethod> expectedRoutingMethod = RoutingMethod.All;
        Timeouts expectedTimeouts = new() { Channel = 0, Provider = 0 };

        Assert.Equal(expectedBrandID, model.BrandID);
        Assert.Equal(expectedIf, model.If);
        Assert.Equal(expectedMetadata, model.Metadata);
        Assert.NotNull(model.Override);
        Assert.Equal(expectedOverride.Count, model.Override.Count);
        foreach (var item in expectedOverride)
        {
            Assert.True(model.Override.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Override[item.Key]));
        }
        Assert.NotNull(model.Providers);
        Assert.Equal(expectedProviders.Count, model.Providers.Count);
        for (int i = 0; i < expectedProviders.Count; i++)
        {
            Assert.Equal(expectedProviders[i], model.Providers[i]);
        }
        Assert.Equal(expectedRoutingMethod, model.RoutingMethod);
        Assert.Equal(expectedTimeouts, model.Timeouts);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChannelsItem
        {
            BrandID = "brand_id",
            If = "if",
            Metadata = new()
            {
                Utm = new()
                {
                    Campaign = "campaign",
                    Content = "content",
                    Medium = "medium",
                    Source = "source",
                    Term = "term",
                },
            },
            Override = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Providers = ["string"],
            RoutingMethod = RoutingMethod.All,
            Timeouts = new() { Channel = 0, Provider = 0 },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ChannelsItem>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChannelsItem
        {
            BrandID = "brand_id",
            If = "if",
            Metadata = new()
            {
                Utm = new()
                {
                    Campaign = "campaign",
                    Content = "content",
                    Medium = "medium",
                    Source = "source",
                    Term = "term",
                },
            },
            Override = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Providers = ["string"],
            RoutingMethod = RoutingMethod.All,
            Timeouts = new() { Channel = 0, Provider = 0 },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ChannelsItem>(element);
        Assert.NotNull(deserialized);

        string expectedBrandID = "brand_id";
        string expectedIf = "if";
        Metadata expectedMetadata = new()
        {
            Utm = new()
            {
                Campaign = "campaign",
                Content = "content",
                Medium = "medium",
                Source = "source",
                Term = "term",
            },
        };
        Dictionary<string, JsonElement> expectedOverride = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        List<string> expectedProviders = ["string"];
        ApiEnum<string, RoutingMethod> expectedRoutingMethod = RoutingMethod.All;
        Timeouts expectedTimeouts = new() { Channel = 0, Provider = 0 };

        Assert.Equal(expectedBrandID, deserialized.BrandID);
        Assert.Equal(expectedIf, deserialized.If);
        Assert.Equal(expectedMetadata, deserialized.Metadata);
        Assert.NotNull(deserialized.Override);
        Assert.Equal(expectedOverride.Count, deserialized.Override.Count);
        foreach (var item in expectedOverride)
        {
            Assert.True(deserialized.Override.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Override[item.Key]));
        }
        Assert.NotNull(deserialized.Providers);
        Assert.Equal(expectedProviders.Count, deserialized.Providers.Count);
        for (int i = 0; i < expectedProviders.Count; i++)
        {
            Assert.Equal(expectedProviders[i], deserialized.Providers[i]);
        }
        Assert.Equal(expectedRoutingMethod, deserialized.RoutingMethod);
        Assert.Equal(expectedTimeouts, deserialized.Timeouts);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChannelsItem
        {
            BrandID = "brand_id",
            If = "if",
            Metadata = new()
            {
                Utm = new()
                {
                    Campaign = "campaign",
                    Content = "content",
                    Medium = "medium",
                    Source = "source",
                    Term = "term",
                },
            },
            Override = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Providers = ["string"],
            RoutingMethod = RoutingMethod.All,
            Timeouts = new() { Channel = 0, Provider = 0 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChannelsItem { };

        Assert.Null(model.BrandID);
        Assert.False(model.RawData.ContainsKey("brand_id"));
        Assert.Null(model.If);
        Assert.False(model.RawData.ContainsKey("if"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Override);
        Assert.False(model.RawData.ContainsKey("override"));
        Assert.Null(model.Providers);
        Assert.False(model.RawData.ContainsKey("providers"));
        Assert.Null(model.RoutingMethod);
        Assert.False(model.RawData.ContainsKey("routing_method"));
        Assert.Null(model.Timeouts);
        Assert.False(model.RawData.ContainsKey("timeouts"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChannelsItem { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ChannelsItem
        {
            BrandID = null,
            If = null,
            Metadata = null,
            Override = null,
            Providers = null,
            RoutingMethod = null,
            Timeouts = null,
        };

        Assert.Null(model.BrandID);
        Assert.True(model.RawData.ContainsKey("brand_id"));
        Assert.Null(model.If);
        Assert.True(model.RawData.ContainsKey("if"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Override);
        Assert.True(model.RawData.ContainsKey("override"));
        Assert.Null(model.Providers);
        Assert.True(model.RawData.ContainsKey("providers"));
        Assert.Null(model.RoutingMethod);
        Assert.True(model.RawData.ContainsKey("routing_method"));
        Assert.Null(model.Timeouts);
        Assert.True(model.RawData.ContainsKey("timeouts"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChannelsItem
        {
            BrandID = null,
            If = null,
            Metadata = null,
            Override = null,
            Providers = null,
            RoutingMethod = null,
            Timeouts = null,
        };

        model.Validate();
    }
}

public class MetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Metadata
        {
            Utm = new()
            {
                Campaign = "campaign",
                Content = "content",
                Medium = "medium",
                Source = "source",
                Term = "term",
            },
        };

        Models::Utm expectedUtm = new()
        {
            Campaign = "campaign",
            Content = "content",
            Medium = "medium",
            Source = "source",
            Term = "term",
        };

        Assert.Equal(expectedUtm, model.Utm);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Metadata
        {
            Utm = new()
            {
                Campaign = "campaign",
                Content = "content",
                Medium = "medium",
                Source = "source",
                Term = "term",
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Metadata>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Metadata
        {
            Utm = new()
            {
                Campaign = "campaign",
                Content = "content",
                Medium = "medium",
                Source = "source",
                Term = "term",
            },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Metadata>(element);
        Assert.NotNull(deserialized);

        Models::Utm expectedUtm = new()
        {
            Campaign = "campaign",
            Content = "content",
            Medium = "medium",
            Source = "source",
            Term = "term",
        };

        Assert.Equal(expectedUtm, deserialized.Utm);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Metadata
        {
            Utm = new()
            {
                Campaign = "campaign",
                Content = "content",
                Medium = "medium",
                Source = "source",
                Term = "term",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Metadata { };

        Assert.Null(model.Utm);
        Assert.False(model.RawData.ContainsKey("utm"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Metadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Metadata { Utm = null };

        Assert.Null(model.Utm);
        Assert.True(model.RawData.ContainsKey("utm"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Metadata { Utm = null };

        model.Validate();
    }
}

public class RoutingMethodTest : TestBase
{
    [Theory]
    [InlineData(RoutingMethod.All)]
    [InlineData(RoutingMethod.Single)]
    public void Validation_Works(RoutingMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RoutingMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RoutingMethod>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RoutingMethod.All)]
    [InlineData(RoutingMethod.Single)]
    public void SerializationRoundtrip_Works(RoutingMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RoutingMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RoutingMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RoutingMethod>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RoutingMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TimeoutsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Timeouts { Channel = 0, Provider = 0 };

        long expectedChannel = 0;
        long expectedProvider = 0;

        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedProvider, model.Provider);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Timeouts { Channel = 0, Provider = 0 };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Timeouts>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Timeouts { Channel = 0, Provider = 0 };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Timeouts>(element);
        Assert.NotNull(deserialized);

        long expectedChannel = 0;
        long expectedProvider = 0;

        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedProvider, deserialized.Provider);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Timeouts { Channel = 0, Provider = 0 };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Timeouts { };

        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Timeouts { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Timeouts { Channel = null, Provider = null };

        Assert.Null(model.Channel);
        Assert.True(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Provider);
        Assert.True(model.RawData.ContainsKey("provider"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Timeouts { Channel = null, Provider = null };

        model.Validate();
    }
}

public class ContentTest : TestBase
{
    [Fact]
    public void ElementalContentSugarValidationWorks()
    {
        Content value = new(new Models::ElementalContentSugar() { Body = "body", Title = "title" });
        value.Validate();
    }

    [Fact]
    public void ElementalValidationWorks()
    {
        Content value = new(
            new Models::ElementalContent()
            {
                Elements =
                [
                    new Models::ElementalTextNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Type = Models::ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "version",
                Brand = "brand",
            }
        );
        value.Validate();
    }

    [Fact]
    public void ElementalContentSugarSerializationRoundtripWorks()
    {
        Content value = new(new Models::ElementalContentSugar() { Body = "body", Title = "title" });
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Content>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ElementalSerializationRoundtripWorks()
    {
        Content value = new(
            new Models::ElementalContent()
            {
                Elements =
                [
                    new Models::ElementalTextNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Type = Models::ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "version",
                Brand = "brand",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Content>(element);

        Assert.Equal(value, deserialized);
    }
}

public class DelayTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Delay
        {
            Duration = 0,
            Timezone = "timezone",
            Until = "until",
        };

        long expectedDuration = 0;
        string expectedTimezone = "timezone";
        string expectedUntil = "until";

        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedTimezone, model.Timezone);
        Assert.Equal(expectedUntil, model.Until);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Delay
        {
            Duration = 0,
            Timezone = "timezone",
            Until = "until",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Delay>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Delay
        {
            Duration = 0,
            Timezone = "timezone",
            Until = "until",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Delay>(element);
        Assert.NotNull(deserialized);

        long expectedDuration = 0;
        string expectedTimezone = "timezone";
        string expectedUntil = "until";

        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedTimezone, deserialized.Timezone);
        Assert.Equal(expectedUntil, deserialized.Until);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Delay
        {
            Duration = 0,
            Timezone = "timezone",
            Until = "until",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Delay { };

        Assert.Null(model.Duration);
        Assert.False(model.RawData.ContainsKey("duration"));
        Assert.Null(model.Timezone);
        Assert.False(model.RawData.ContainsKey("timezone"));
        Assert.Null(model.Until);
        Assert.False(model.RawData.ContainsKey("until"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Delay { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Delay
        {
            Duration = null,
            Timezone = null,
            Until = null,
        };

        Assert.Null(model.Duration);
        Assert.True(model.RawData.ContainsKey("duration"));
        Assert.Null(model.Timezone);
        Assert.True(model.RawData.ContainsKey("timezone"));
        Assert.Null(model.Until);
        Assert.True(model.RawData.ContainsKey("until"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Delay
        {
            Duration = null,
            Timezone = null,
            Until = null,
        };

        model.Validate();
    }
}

public class ExpiryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Expiry { ExpiresIn = "string", ExpiresAt = "expires_at" };

        ExpiresIn expectedExpiresIn = "string";
        string expectedExpiresAt = "expires_at";

        Assert.Equal(expectedExpiresIn, model.ExpiresIn);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Expiry { ExpiresIn = "string", ExpiresAt = "expires_at" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Expiry>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Expiry { ExpiresIn = "string", ExpiresAt = "expires_at" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Expiry>(element);
        Assert.NotNull(deserialized);

        ExpiresIn expectedExpiresIn = "string";
        string expectedExpiresAt = "expires_at";

        Assert.Equal(expectedExpiresIn, deserialized.ExpiresIn);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Expiry { ExpiresIn = "string", ExpiresAt = "expires_at" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Expiry { ExpiresIn = "string" };

        Assert.Null(model.ExpiresAt);
        Assert.False(model.RawData.ContainsKey("expires_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Expiry { ExpiresIn = "string" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Expiry
        {
            ExpiresIn = "string",

            ExpiresAt = null,
        };

        Assert.Null(model.ExpiresAt);
        Assert.True(model.RawData.ContainsKey("expires_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Expiry
        {
            ExpiresIn = "string",

            ExpiresAt = null,
        };

        model.Validate();
    }
}

public class ExpiresInTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ExpiresIn value = new("string");
        value.Validate();
    }

    [Fact]
    public void LongValidationWorks()
    {
        ExpiresIn value = new(0);
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ExpiresIn value = new("string");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ExpiresIn>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void LongSerializationRoundtripWorks()
    {
        ExpiresIn value = new(0);
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ExpiresIn>(element);

        Assert.Equal(value, deserialized);
    }
}

public class MessageMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageMetadata
        {
            Event = "event",
            Tags = ["string"],
            TraceID = "trace_id",
            Utm = new()
            {
                Campaign = "campaign",
                Content = "content",
                Medium = "medium",
                Source = "source",
                Term = "term",
            },
        };

        string expectedEvent = "event";
        List<string> expectedTags = ["string"];
        string expectedTraceID = "trace_id";
        Models::Utm expectedUtm = new()
        {
            Campaign = "campaign",
            Content = "content",
            Medium = "medium",
            Source = "source",
            Term = "term",
        };

        Assert.Equal(expectedEvent, model.Event);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.Equal(expectedTraceID, model.TraceID);
        Assert.Equal(expectedUtm, model.Utm);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MessageMetadata
        {
            Event = "event",
            Tags = ["string"],
            TraceID = "trace_id",
            Utm = new()
            {
                Campaign = "campaign",
                Content = "content",
                Medium = "medium",
                Source = "source",
                Term = "term",
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MessageMetadata>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageMetadata
        {
            Event = "event",
            Tags = ["string"],
            TraceID = "trace_id",
            Utm = new()
            {
                Campaign = "campaign",
                Content = "content",
                Medium = "medium",
                Source = "source",
                Term = "term",
            },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MessageMetadata>(element);
        Assert.NotNull(deserialized);

        string expectedEvent = "event";
        List<string> expectedTags = ["string"];
        string expectedTraceID = "trace_id";
        Models::Utm expectedUtm = new()
        {
            Campaign = "campaign",
            Content = "content",
            Medium = "medium",
            Source = "source",
            Term = "term",
        };

        Assert.Equal(expectedEvent, deserialized.Event);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.Equal(expectedTraceID, deserialized.TraceID);
        Assert.Equal(expectedUtm, deserialized.Utm);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MessageMetadata
        {
            Event = "event",
            Tags = ["string"],
            TraceID = "trace_id",
            Utm = new()
            {
                Campaign = "campaign",
                Content = "content",
                Medium = "medium",
                Source = "source",
                Term = "term",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new MessageMetadata { };

        Assert.Null(model.Event);
        Assert.False(model.RawData.ContainsKey("event"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.TraceID);
        Assert.False(model.RawData.ContainsKey("trace_id"));
        Assert.Null(model.Utm);
        Assert.False(model.RawData.ContainsKey("utm"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new MessageMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new MessageMetadata
        {
            Event = null,
            Tags = null,
            TraceID = null,
            Utm = null,
        };

        Assert.Null(model.Event);
        Assert.True(model.RawData.ContainsKey("event"));
        Assert.Null(model.Tags);
        Assert.True(model.RawData.ContainsKey("tags"));
        Assert.Null(model.TraceID);
        Assert.True(model.RawData.ContainsKey("trace_id"));
        Assert.Null(model.Utm);
        Assert.True(model.RawData.ContainsKey("utm"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new MessageMetadata
        {
            Event = null,
            Tags = null,
            TraceID = null,
            Utm = null,
        };

        model.Validate();
    }
}

public class PreferencesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Preferences { SubscriptionTopicID = "subscription_topic_id" };

        string expectedSubscriptionTopicID = "subscription_topic_id";

        Assert.Equal(expectedSubscriptionTopicID, model.SubscriptionTopicID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Preferences { SubscriptionTopicID = "subscription_topic_id" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Preferences>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Preferences { SubscriptionTopicID = "subscription_topic_id" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Preferences>(element);
        Assert.NotNull(deserialized);

        string expectedSubscriptionTopicID = "subscription_topic_id";

        Assert.Equal(expectedSubscriptionTopicID, deserialized.SubscriptionTopicID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Preferences { SubscriptionTopicID = "subscription_topic_id" };

        model.Validate();
    }
}

public class ProvidersItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProvidersItem
        {
            If = "if",
            Metadata = new()
            {
                Utm = new()
                {
                    Campaign = "campaign",
                    Content = "content",
                    Medium = "medium",
                    Source = "source",
                    Term = "term",
                },
            },
            Override = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timeouts = 0,
        };

        string expectedIf = "if";
        ProvidersItemMetadata expectedMetadata = new()
        {
            Utm = new()
            {
                Campaign = "campaign",
                Content = "content",
                Medium = "medium",
                Source = "source",
                Term = "term",
            },
        };
        Dictionary<string, JsonElement> expectedOverride = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        long expectedTimeouts = 0;

        Assert.Equal(expectedIf, model.If);
        Assert.Equal(expectedMetadata, model.Metadata);
        Assert.NotNull(model.Override);
        Assert.Equal(expectedOverride.Count, model.Override.Count);
        foreach (var item in expectedOverride)
        {
            Assert.True(model.Override.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Override[item.Key]));
        }
        Assert.Equal(expectedTimeouts, model.Timeouts);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProvidersItem
        {
            If = "if",
            Metadata = new()
            {
                Utm = new()
                {
                    Campaign = "campaign",
                    Content = "content",
                    Medium = "medium",
                    Source = "source",
                    Term = "term",
                },
            },
            Override = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timeouts = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ProvidersItem>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProvidersItem
        {
            If = "if",
            Metadata = new()
            {
                Utm = new()
                {
                    Campaign = "campaign",
                    Content = "content",
                    Medium = "medium",
                    Source = "source",
                    Term = "term",
                },
            },
            Override = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timeouts = 0,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ProvidersItem>(element);
        Assert.NotNull(deserialized);

        string expectedIf = "if";
        ProvidersItemMetadata expectedMetadata = new()
        {
            Utm = new()
            {
                Campaign = "campaign",
                Content = "content",
                Medium = "medium",
                Source = "source",
                Term = "term",
            },
        };
        Dictionary<string, JsonElement> expectedOverride = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        long expectedTimeouts = 0;

        Assert.Equal(expectedIf, deserialized.If);
        Assert.Equal(expectedMetadata, deserialized.Metadata);
        Assert.NotNull(deserialized.Override);
        Assert.Equal(expectedOverride.Count, deserialized.Override.Count);
        foreach (var item in expectedOverride)
        {
            Assert.True(deserialized.Override.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Override[item.Key]));
        }
        Assert.Equal(expectedTimeouts, deserialized.Timeouts);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProvidersItem
        {
            If = "if",
            Metadata = new()
            {
                Utm = new()
                {
                    Campaign = "campaign",
                    Content = "content",
                    Medium = "medium",
                    Source = "source",
                    Term = "term",
                },
            },
            Override = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Timeouts = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProvidersItem { };

        Assert.Null(model.If);
        Assert.False(model.RawData.ContainsKey("if"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Override);
        Assert.False(model.RawData.ContainsKey("override"));
        Assert.Null(model.Timeouts);
        Assert.False(model.RawData.ContainsKey("timeouts"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProvidersItem { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ProvidersItem
        {
            If = null,
            Metadata = null,
            Override = null,
            Timeouts = null,
        };

        Assert.Null(model.If);
        Assert.True(model.RawData.ContainsKey("if"));
        Assert.Null(model.Metadata);
        Assert.True(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Override);
        Assert.True(model.RawData.ContainsKey("override"));
        Assert.Null(model.Timeouts);
        Assert.True(model.RawData.ContainsKey("timeouts"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ProvidersItem
        {
            If = null,
            Metadata = null,
            Override = null,
            Timeouts = null,
        };

        model.Validate();
    }
}

public class ProvidersItemMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProvidersItemMetadata
        {
            Utm = new()
            {
                Campaign = "campaign",
                Content = "content",
                Medium = "medium",
                Source = "source",
                Term = "term",
            },
        };

        Models::Utm expectedUtm = new()
        {
            Campaign = "campaign",
            Content = "content",
            Medium = "medium",
            Source = "source",
            Term = "term",
        };

        Assert.Equal(expectedUtm, model.Utm);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProvidersItemMetadata
        {
            Utm = new()
            {
                Campaign = "campaign",
                Content = "content",
                Medium = "medium",
                Source = "source",
                Term = "term",
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ProvidersItemMetadata>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProvidersItemMetadata
        {
            Utm = new()
            {
                Campaign = "campaign",
                Content = "content",
                Medium = "medium",
                Source = "source",
                Term = "term",
            },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ProvidersItemMetadata>(element);
        Assert.NotNull(deserialized);

        Models::Utm expectedUtm = new()
        {
            Campaign = "campaign",
            Content = "content",
            Medium = "medium",
            Source = "source",
            Term = "term",
        };

        Assert.Equal(expectedUtm, deserialized.Utm);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProvidersItemMetadata
        {
            Utm = new()
            {
                Campaign = "campaign",
                Content = "content",
                Medium = "medium",
                Source = "source",
                Term = "term",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProvidersItemMetadata { };

        Assert.Null(model.Utm);
        Assert.False(model.RawData.ContainsKey("utm"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProvidersItemMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ProvidersItemMetadata { Utm = null };

        Assert.Null(model.Utm);
        Assert.True(model.RawData.ContainsKey("utm"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ProvidersItemMetadata { Utm = null };

        model.Validate();
    }
}

public class RoutingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Routing { Channels = ["string"], Method = Method.All };

        List<Models::MessageRoutingChannel> expectedChannels = ["string"];
        ApiEnum<string, Method> expectedMethod = Method.All;

        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], model.Channels[i]);
        }
        Assert.Equal(expectedMethod, model.Method);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Routing { Channels = ["string"], Method = Method.All };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Routing>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Routing { Channels = ["string"], Method = Method.All };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Routing>(element);
        Assert.NotNull(deserialized);

        List<Models::MessageRoutingChannel> expectedChannels = ["string"];
        ApiEnum<string, Method> expectedMethod = Method.All;

        Assert.Equal(expectedChannels.Count, deserialized.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], deserialized.Channels[i]);
        }
        Assert.Equal(expectedMethod, deserialized.Method);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Routing { Channels = ["string"], Method = Method.All };

        model.Validate();
    }
}

public class MethodTest : TestBase
{
    [Theory]
    [InlineData(Method.All)]
    [InlineData(Method.Single)]
    public void Validation_Works(Method rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Method> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Method.All)]
    [InlineData(Method.Single)]
    public void SerializationRoundtrip_Works(Method rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Method> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Method>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TimeoutTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Timeout
        {
            Channel = new Dictionary<string, long>() { { "foo", 0 } },
            Criteria = Criteria.NoEscalation,
            Escalation = 0,
            Message = 0,
            Provider = new Dictionary<string, long>() { { "foo", 0 } },
        };

        Dictionary<string, long> expectedChannel = new() { { "foo", 0 } };
        ApiEnum<string, Criteria> expectedCriteria = Criteria.NoEscalation;
        long expectedEscalation = 0;
        long expectedMessage = 0;
        Dictionary<string, long> expectedProvider = new() { { "foo", 0 } };

        Assert.NotNull(model.Channel);
        Assert.Equal(expectedChannel.Count, model.Channel.Count);
        foreach (var item in expectedChannel)
        {
            Assert.True(model.Channel.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Channel[item.Key]);
        }
        Assert.Equal(expectedCriteria, model.Criteria);
        Assert.Equal(expectedEscalation, model.Escalation);
        Assert.Equal(expectedMessage, model.Message);
        Assert.NotNull(model.Provider);
        Assert.Equal(expectedProvider.Count, model.Provider.Count);
        foreach (var item in expectedProvider)
        {
            Assert.True(model.Provider.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Provider[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Timeout
        {
            Channel = new Dictionary<string, long>() { { "foo", 0 } },
            Criteria = Criteria.NoEscalation,
            Escalation = 0,
            Message = 0,
            Provider = new Dictionary<string, long>() { { "foo", 0 } },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Timeout>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Timeout
        {
            Channel = new Dictionary<string, long>() { { "foo", 0 } },
            Criteria = Criteria.NoEscalation,
            Escalation = 0,
            Message = 0,
            Provider = new Dictionary<string, long>() { { "foo", 0 } },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Timeout>(element);
        Assert.NotNull(deserialized);

        Dictionary<string, long> expectedChannel = new() { { "foo", 0 } };
        ApiEnum<string, Criteria> expectedCriteria = Criteria.NoEscalation;
        long expectedEscalation = 0;
        long expectedMessage = 0;
        Dictionary<string, long> expectedProvider = new() { { "foo", 0 } };

        Assert.NotNull(deserialized.Channel);
        Assert.Equal(expectedChannel.Count, deserialized.Channel.Count);
        foreach (var item in expectedChannel)
        {
            Assert.True(deserialized.Channel.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Channel[item.Key]);
        }
        Assert.Equal(expectedCriteria, deserialized.Criteria);
        Assert.Equal(expectedEscalation, deserialized.Escalation);
        Assert.Equal(expectedMessage, deserialized.Message);
        Assert.NotNull(deserialized.Provider);
        Assert.Equal(expectedProvider.Count, deserialized.Provider.Count);
        foreach (var item in expectedProvider)
        {
            Assert.True(deserialized.Provider.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Provider[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Timeout
        {
            Channel = new Dictionary<string, long>() { { "foo", 0 } },
            Criteria = Criteria.NoEscalation,
            Escalation = 0,
            Message = 0,
            Provider = new Dictionary<string, long>() { { "foo", 0 } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Timeout { };

        Assert.Null(model.Channel);
        Assert.False(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Criteria);
        Assert.False(model.RawData.ContainsKey("criteria"));
        Assert.Null(model.Escalation);
        Assert.False(model.RawData.ContainsKey("escalation"));
        Assert.Null(model.Message);
        Assert.False(model.RawData.ContainsKey("message"));
        Assert.Null(model.Provider);
        Assert.False(model.RawData.ContainsKey("provider"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Timeout { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Timeout
        {
            Channel = null,
            Criteria = null,
            Escalation = null,
            Message = null,
            Provider = null,
        };

        Assert.Null(model.Channel);
        Assert.True(model.RawData.ContainsKey("channel"));
        Assert.Null(model.Criteria);
        Assert.True(model.RawData.ContainsKey("criteria"));
        Assert.Null(model.Escalation);
        Assert.True(model.RawData.ContainsKey("escalation"));
        Assert.Null(model.Message);
        Assert.True(model.RawData.ContainsKey("message"));
        Assert.Null(model.Provider);
        Assert.True(model.RawData.ContainsKey("provider"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Timeout
        {
            Channel = null,
            Criteria = null,
            Escalation = null,
            Message = null,
            Provider = null,
        };

        model.Validate();
    }
}

public class CriteriaTest : TestBase
{
    [Theory]
    [InlineData(Criteria.NoEscalation)]
    [InlineData(Criteria.Delivered)]
    [InlineData(Criteria.Viewed)]
    [InlineData(Criteria.Engaged)]
    public void Validation_Works(Criteria rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Criteria> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Criteria>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Criteria.NoEscalation)]
    [InlineData(Criteria.Delivered)]
    [InlineData(Criteria.Viewed)]
    [InlineData(Criteria.Engaged)]
    public void SerializationRoundtrip_Works(Criteria rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Criteria> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Criteria>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Criteria>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Criteria>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ToTest : TestBase
{
    [Fact]
    public void UserRecipientValidationWorks()
    {
        To value = new(
            new Models::UserRecipient()
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
            }
        );
        value.Validate();
    }

    [Fact]
    public void RecipientsValidationWorks()
    {
        To value = new(
            [
                new Models::Recipient()
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
            ]
        );
        value.Validate();
    }

    [Fact]
    public void UserRecipientSerializationRoundtripWorks()
    {
        To value = new(
            new Models::UserRecipient()
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
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<To>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RecipientsSerializationRoundtripWorks()
    {
        To value = new(
            [
                new Models::Recipient()
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
            ]
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<To>(element);

        Assert.Equal(value, deserialized);
    }
}
