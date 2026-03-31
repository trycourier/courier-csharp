using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models;
using Courier.Models.RoutingStrategies;

namespace Courier.Tests.Models.RoutingStrategies;

public class RoutingStrategyGetResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RoutingStrategyGetResponse
        {
            ID = "id",
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
            Created = 0,
            Creator = "creator",
            Name = "name",
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
            Routing = new() { Channels = ["string"], Method = Method.All },
            Description = "description",
            Tags = ["string"],
            Updated = 0,
            Updater = "updater",
        };

        string expectedID = "id";
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
        long expectedCreated = 0;
        string expectedCreator = "creator";
        string expectedName = "name";
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
        MessageRouting expectedRouting = new() { Channels = ["string"], Method = Method.All };
        string expectedDescription = "description";
        List<string> expectedTags = ["string"];
        long expectedUpdated = 0;
        string expectedUpdater = "updater";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        foreach (var item in expectedChannels)
        {
            Assert.True(model.Channels.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Channels[item.Key]);
        }
        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedCreator, model.Creator);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedProviders.Count, model.Providers.Count);
        foreach (var item in expectedProviders)
        {
            Assert.True(model.Providers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Providers[item.Key]);
        }
        Assert.Equal(expectedRouting, model.Routing);
        Assert.Equal(expectedDescription, model.Description);
        Assert.NotNull(model.Tags);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.Equal(expectedUpdated, model.Updated);
        Assert.Equal(expectedUpdater, model.Updater);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RoutingStrategyGetResponse
        {
            ID = "id",
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
            Created = 0,
            Creator = "creator",
            Name = "name",
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
            Routing = new() { Channels = ["string"], Method = Method.All },
            Description = "description",
            Tags = ["string"],
            Updated = 0,
            Updater = "updater",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RoutingStrategyGetResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RoutingStrategyGetResponse
        {
            ID = "id",
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
            Created = 0,
            Creator = "creator",
            Name = "name",
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
            Routing = new() { Channels = ["string"], Method = Method.All },
            Description = "description",
            Tags = ["string"],
            Updated = 0,
            Updater = "updater",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RoutingStrategyGetResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
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
        long expectedCreated = 0;
        string expectedCreator = "creator";
        string expectedName = "name";
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
        MessageRouting expectedRouting = new() { Channels = ["string"], Method = Method.All };
        string expectedDescription = "description";
        List<string> expectedTags = ["string"];
        long expectedUpdated = 0;
        string expectedUpdater = "updater";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedChannels.Count, deserialized.Channels.Count);
        foreach (var item in expectedChannels)
        {
            Assert.True(deserialized.Channels.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Channels[item.Key]);
        }
        Assert.Equal(expectedCreated, deserialized.Created);
        Assert.Equal(expectedCreator, deserialized.Creator);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedProviders.Count, deserialized.Providers.Count);
        foreach (var item in expectedProviders)
        {
            Assert.True(deserialized.Providers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Providers[item.Key]);
        }
        Assert.Equal(expectedRouting, deserialized.Routing);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.NotNull(deserialized.Tags);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.Equal(expectedUpdated, deserialized.Updated);
        Assert.Equal(expectedUpdater, deserialized.Updater);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RoutingStrategyGetResponse
        {
            ID = "id",
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
            Created = 0,
            Creator = "creator",
            Name = "name",
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
            Routing = new() { Channels = ["string"], Method = Method.All },
            Description = "description",
            Tags = ["string"],
            Updated = 0,
            Updater = "updater",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RoutingStrategyGetResponse
        {
            ID = "id",
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
            Created = 0,
            Creator = "creator",
            Name = "name",
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
            Routing = new() { Channels = ["string"], Method = Method.All },
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
        Assert.Null(model.Tags);
        Assert.False(model.RawData.ContainsKey("tags"));
        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
        Assert.Null(model.Updater);
        Assert.False(model.RawData.ContainsKey("updater"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RoutingStrategyGetResponse
        {
            ID = "id",
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
            Created = 0,
            Creator = "creator",
            Name = "name",
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
            Routing = new() { Channels = ["string"], Method = Method.All },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RoutingStrategyGetResponse
        {
            ID = "id",
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
            Created = 0,
            Creator = "creator",
            Name = "name",
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
            Routing = new() { Channels = ["string"], Method = Method.All },

            Description = null,
            Tags = null,
            Updated = null,
            Updater = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
        Assert.Null(model.Tags);
        Assert.True(model.RawData.ContainsKey("tags"));
        Assert.Null(model.Updated);
        Assert.True(model.RawData.ContainsKey("updated"));
        Assert.Null(model.Updater);
        Assert.True(model.RawData.ContainsKey("updater"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RoutingStrategyGetResponse
        {
            ID = "id",
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
            Created = 0,
            Creator = "creator",
            Name = "name",
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
            Routing = new() { Channels = ["string"], Method = Method.All },

            Description = null,
            Tags = null,
            Updated = null,
            Updater = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RoutingStrategyGetResponse
        {
            ID = "id",
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
            Created = 0,
            Creator = "creator",
            Name = "name",
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
            Routing = new() { Channels = ["string"], Method = Method.All },
            Description = "description",
            Tags = ["string"],
            Updated = 0,
            Updater = "updater",
        };

        RoutingStrategyGetResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
