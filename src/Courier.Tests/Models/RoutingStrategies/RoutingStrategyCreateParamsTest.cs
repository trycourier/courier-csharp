using System;
using System.Collections.Generic;
using System.Text.Json;
using Courier.Models;
using Courier.Models.RoutingStrategies;

namespace Courier.Tests.Models.RoutingStrategies;

public class RoutingStrategyCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RoutingStrategyCreateParams
        {
            Name = "Email via SendGrid",
            Routing = new() { Channels = ["email"], Method = Method.Single },
            Channels = new Dictionary<string, Channel>()
            {
                {
                    "email",
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
                        Providers = ["sendgrid", "ses"],
                        RoutingMethod = RoutingMethod.All,
                        Timeouts = new() { Channel = 0, Provider = 0 },
                    }
                },
            },
            Description = "Routes email through sendgrid with SES failover",
            Providers = new Dictionary<string, MessageProvidersType>()
            {
                {
                    "sendgrid",
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
                        Override = new Dictionary<string, JsonElement>(),
                        Timeouts = 0,
                    }
                },
            },
            Tags = ["production", "email"],
        };

        string expectedName = "Email via SendGrid";
        MessageRouting expectedRouting = new() { Channels = ["email"], Method = Method.Single };
        Dictionary<string, Channel> expectedChannels = new()
        {
            {
                "email",
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
                    Providers = ["sendgrid", "ses"],
                    RoutingMethod = RoutingMethod.All,
                    Timeouts = new() { Channel = 0, Provider = 0 },
                }
            },
        };
        string expectedDescription = "Routes email through sendgrid with SES failover";
        Dictionary<string, MessageProvidersType> expectedProviders = new()
        {
            {
                "sendgrid",
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
                    Override = new Dictionary<string, JsonElement>(),
                    Timeouts = 0,
                }
            },
        };
        List<string> expectedTags = ["production", "email"];

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedRouting, parameters.Routing);
        Assert.NotNull(parameters.Channels);
        Assert.Equal(expectedChannels.Count, parameters.Channels.Count);
        foreach (var item in expectedChannels)
        {
            Assert.True(parameters.Channels.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Channels[item.Key]);
        }
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.Providers);
        Assert.Equal(expectedProviders.Count, parameters.Providers.Count);
        foreach (var item in expectedProviders)
        {
            Assert.True(parameters.Providers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Providers[item.Key]);
        }
        Assert.NotNull(parameters.Tags);
        Assert.Equal(expectedTags.Count, parameters.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], parameters.Tags[i]);
        }
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RoutingStrategyCreateParams
        {
            Name = "Email via SendGrid",
            Routing = new() { Channels = ["email"], Method = Method.Single },
        };

        Assert.Null(parameters.Channels);
        Assert.False(parameters.RawBodyData.ContainsKey("channels"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Providers);
        Assert.False(parameters.RawBodyData.ContainsKey("providers"));
        Assert.Null(parameters.Tags);
        Assert.False(parameters.RawBodyData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new RoutingStrategyCreateParams
        {
            Name = "Email via SendGrid",
            Routing = new() { Channels = ["email"], Method = Method.Single },

            Channels = null,
            Description = null,
            Providers = null,
            Tags = null,
        };

        Assert.Null(parameters.Channels);
        Assert.True(parameters.RawBodyData.ContainsKey("channels"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Providers);
        Assert.True(parameters.RawBodyData.ContainsKey("providers"));
        Assert.Null(parameters.Tags);
        Assert.True(parameters.RawBodyData.ContainsKey("tags"));
    }

    [Fact]
    public void Url_Works()
    {
        RoutingStrategyCreateParams parameters = new()
        {
            Name = "Email via SendGrid",
            Routing = new() { Channels = ["email"], Method = Method.Single },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.courier.com/routing-strategies"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new RoutingStrategyCreateParams
        {
            Name = "Email via SendGrid",
            Routing = new() { Channels = ["email"], Method = Method.Single },
            Channels = new Dictionary<string, Channel>()
            {
                {
                    "email",
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
                        Providers = ["sendgrid", "ses"],
                        RoutingMethod = RoutingMethod.All,
                        Timeouts = new() { Channel = 0, Provider = 0 },
                    }
                },
            },
            Description = "Routes email through sendgrid with SES failover",
            Providers = new Dictionary<string, MessageProvidersType>()
            {
                {
                    "sendgrid",
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
                        Override = new Dictionary<string, JsonElement>(),
                        Timeouts = 0,
                    }
                },
            },
            Tags = ["production", "email"],
        };

        RoutingStrategyCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
