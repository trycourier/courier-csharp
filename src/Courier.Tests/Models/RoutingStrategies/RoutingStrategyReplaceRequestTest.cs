using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models;
using Courier.Models.RoutingStrategies;

namespace Courier.Tests.Models.RoutingStrategies;

public class RoutingStrategyReplaceRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RoutingStrategyReplaceRequest
        {
            Name = "name",
            Routing = new() { Channels = ["string"], Method = Method.All },
            Channels = new Dictionary<string, Channel>()
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
            Description = "description",
            Providers = new Dictionary<string, MessageProvidersType>()
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
            Tags = ["string"],
        };

        string expectedName = "name";
        MessageRouting expectedRouting = new() { Channels = ["string"], Method = Method.All };
        Dictionary<string, Channel> expectedChannels = new()
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
        string expectedDescription = "description";
        Dictionary<string, MessageProvidersType> expectedProviders = new()
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
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedRouting, model.Routing);
        Assert.NotNull(model.Channels);
        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        foreach (var item in expectedChannels)
        {
            Assert.True(model.Channels.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Channels[item.Key]);
        }
        Assert.Equal(expectedDescription, model.Description);
        Assert.NotNull(model.Providers);
        Assert.Equal(expectedProviders.Count, model.Providers.Count);
        foreach (var item in expectedProviders)
        {
            Assert.True(model.Providers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Providers[item.Key]);
        }
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RoutingStrategyReplaceRequest
        {
            Name = "name",
            Routing = new() { Channels = ["string"], Method = Method.All },
            Channels = new Dictionary<string, Channel>()
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
            Description = "description",
            Providers = new Dictionary<string, MessageProvidersType>()
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
            Tags = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RoutingStrategyReplaceRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RoutingStrategyReplaceRequest
        {
            Name = "name",
            Routing = new() { Channels = ["string"], Method = Method.All },
            Channels = new Dictionary<string, Channel>()
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
            Description = "description",
            Providers = new Dictionary<string, MessageProvidersType>()
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
            Tags = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RoutingStrategyReplaceRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedName = "name";
        MessageRouting expectedRouting = new() { Channels = ["string"], Method = Method.All };
        Dictionary<string, Channel> expectedChannels = new()
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
        string expectedDescription = "description";
        Dictionary<string, MessageProvidersType> expectedProviders = new()
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
        List<string> expectedTags = ["string"];

        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedRouting, deserialized.Routing);
        Assert.NotNull(deserialized.Channels);
        Assert.Equal(expectedChannels.Count, deserialized.Channels.Count);
        foreach (var item in expectedChannels)
        {
            Assert.True(deserialized.Channels.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Channels[item.Key]);
        }
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.NotNull(deserialized.Providers);
        Assert.Equal(expectedProviders.Count, deserialized.Providers.Count);
        foreach (var item in expectedProviders)
        {
            Assert.True(deserialized.Providers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Providers[item.Key]);
        }
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RoutingStrategyReplaceRequest
        {
            Name = "name",
            Routing = new() { Channels = ["string"], Method = Method.All },
            Channels = new Dictionary<string, Channel>()
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
            Description = "description",
            Providers = new Dictionary<string, MessageProvidersType>()
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
            Tags = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RoutingStrategyReplaceRequest
        {
            Name = "name",
            Routing = new() { Channels = ["string"], Method = Method.All },
        };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Providers);
        Assert.False(model.RawData.ContainsKey("providers"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RoutingStrategyReplaceRequest
        {
            Name = "name",
            Routing = new() { Channels = ["string"], Method = Method.All },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RoutingStrategyReplaceRequest
        {
            Name = "name",
            Routing = new() { Channels = ["string"], Method = Method.All },

            Channels = null,
            Description = null,
            Providers = null,
            Tags = null,
        };

        Assert.Null(model.Channels);
        Assert.True(model.RawData.ContainsKey("channels"));
        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Providers);
        Assert.True(model.RawData.ContainsKey("providers"));
        Assert.Null(model.Tags);
        Assert.True(model.RawData.ContainsKey("tags"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RoutingStrategyReplaceRequest
        {
            Name = "name",
            Routing = new() { Channels = ["string"], Method = Method.All },

            Channels = null,
            Description = null,
            Providers = null,
            Tags = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RoutingStrategyReplaceRequest
        {
            Name = "name",
            Routing = new() { Channels = ["string"], Method = Method.All },
            Channels = new Dictionary<string, Channel>()
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
            Description = "description",
            Providers = new Dictionary<string, MessageProvidersType>()
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
            Tags = ["string"],
        };

        RoutingStrategyReplaceRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
