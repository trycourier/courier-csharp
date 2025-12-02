using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models.Send;
using Models = Courier.Models;

namespace Courier.Tests.Models.Send;

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
            Delay = new() { Duration = 0, Until = "until" },
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
        Delay expectedDelay = new() { Duration = 0, Until = "until" };
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
        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        foreach (var item in expectedChannels)
        {
            Assert.True(model.Channels.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Channels[item.Key]);
        }
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedContext, model.Context);
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
        Assert.Equal(expectedOverride.Count, model.Override.Count);
        foreach (var item in expectedOverride)
        {
            Assert.True(model.Override.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Override[item.Key]));
        }
        Assert.Equal(expectedProviders.Count, model.Providers.Count);
        for (int i = 0; i < expectedProviders.Count; i++)
        {
            Assert.Equal(expectedProviders[i], model.Providers[i]);
        }
        Assert.Equal(expectedRoutingMethod, model.RoutingMethod);
        Assert.Equal(expectedTimeouts, model.Timeouts);
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
}

public class DelayTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Delay { Duration = 0, Until = "until" };

        long expectedDuration = 0;
        string expectedUntil = "until";

        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedUntil, model.Until);
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
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.Equal(expectedTraceID, model.TraceID);
        Assert.Equal(expectedUtm, model.Utm);
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
        Assert.Equal(expectedOverride.Count, model.Override.Count);
        foreach (var item in expectedOverride)
        {
            Assert.True(model.Override.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Override[item.Key]));
        }
        Assert.Equal(expectedTimeouts, model.Timeouts);
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

        Assert.Equal(expectedChannel.Count, model.Channel.Count);
        foreach (var item in expectedChannel)
        {
            Assert.True(model.Channel.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Channel[item.Key]);
        }
        Assert.Equal(expectedCriteria, model.Criteria);
        Assert.Equal(expectedEscalation, model.Escalation);
        Assert.Equal(expectedMessage, model.Message);
        Assert.Equal(expectedProvider.Count, model.Provider.Count);
        foreach (var item in expectedProvider)
        {
            Assert.True(model.Provider.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Provider[item.Key]);
        }
    }
}
