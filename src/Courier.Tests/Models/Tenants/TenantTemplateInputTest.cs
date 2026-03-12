using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models;
using Courier.Models.Tenants;

namespace Courier.Tests.Models.Tenants;

public class TenantTemplateInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TenantTemplateInput
        {
            Content = new()
            {
                Elements =
                [
                    new ElementalTextNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "version",
            },
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
        };

        ElementalContent expectedContent = new()
        {
            Elements =
            [
                new ElementalTextNodeWithType()
                {
                    Channels = ["string"],
                    If = "if",
                    Loop = "loop",
                    Ref = "ref",
                    Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                },
            ],
            Version = "version",
        };
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
        MessageRouting expectedRouting = new() { Channels = ["string"], Method = Method.All };

        Assert.Equal(expectedContent, model.Content);
        Assert.NotNull(model.Channels);
        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        foreach (var item in expectedChannels)
        {
            Assert.True(model.Channels.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Channels[item.Key]);
        }
        Assert.NotNull(model.Providers);
        Assert.Equal(expectedProviders.Count, model.Providers.Count);
        foreach (var item in expectedProviders)
        {
            Assert.True(model.Providers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Providers[item.Key]);
        }
        Assert.Equal(expectedRouting, model.Routing);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TenantTemplateInput
        {
            Content = new()
            {
                Elements =
                [
                    new ElementalTextNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "version",
            },
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TenantTemplateInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TenantTemplateInput
        {
            Content = new()
            {
                Elements =
                [
                    new ElementalTextNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "version",
            },
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TenantTemplateInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ElementalContent expectedContent = new()
        {
            Elements =
            [
                new ElementalTextNodeWithType()
                {
                    Channels = ["string"],
                    If = "if",
                    Loop = "loop",
                    Ref = "ref",
                    Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                },
            ],
            Version = "version",
        };
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
        MessageRouting expectedRouting = new() { Channels = ["string"], Method = Method.All };

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.NotNull(deserialized.Channels);
        Assert.Equal(expectedChannels.Count, deserialized.Channels.Count);
        foreach (var item in expectedChannels)
        {
            Assert.True(deserialized.Channels.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Channels[item.Key]);
        }
        Assert.NotNull(deserialized.Providers);
        Assert.Equal(expectedProviders.Count, deserialized.Providers.Count);
        foreach (var item in expectedProviders)
        {
            Assert.True(deserialized.Providers.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Providers[item.Key]);
        }
        Assert.Equal(expectedRouting, deserialized.Routing);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TenantTemplateInput
        {
            Content = new()
            {
                Elements =
                [
                    new ElementalTextNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "version",
            },
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TenantTemplateInput
        {
            Content = new()
            {
                Elements =
                [
                    new ElementalTextNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "version",
            },
        };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.Providers);
        Assert.False(model.RawData.ContainsKey("providers"));
        Assert.Null(model.Routing);
        Assert.False(model.RawData.ContainsKey("routing"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TenantTemplateInput
        {
            Content = new()
            {
                Elements =
                [
                    new ElementalTextNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "version",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TenantTemplateInput
        {
            Content = new()
            {
                Elements =
                [
                    new ElementalTextNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "version",
            },

            // Null should be interpreted as omitted for these properties
            Channels = null,
            Providers = null,
            Routing = null,
        };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.Providers);
        Assert.False(model.RawData.ContainsKey("providers"));
        Assert.Null(model.Routing);
        Assert.False(model.RawData.ContainsKey("routing"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TenantTemplateInput
        {
            Content = new()
            {
                Elements =
                [
                    new ElementalTextNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "version",
            },

            // Null should be interpreted as omitted for these properties
            Channels = null,
            Providers = null,
            Routing = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TenantTemplateInput
        {
            Content = new()
            {
                Elements =
                [
                    new ElementalTextNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "version",
            },
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
        };

        TenantTemplateInput copied = new(model);

        Assert.Equal(model, copied);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChannelsItem>(
            json,
            ModelBase.SerializerOptions
        );

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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChannelsItem>(
            element,
            ModelBase.SerializerOptions
        );
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

    [Fact]
    public void CopyConstructor_Works()
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

        ChannelsItem copied = new(model);

        Assert.Equal(model, copied);
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

        Utm expectedUtm = new()
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metadata>(json, ModelBase.SerializerOptions);

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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Metadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Utm expectedUtm = new()
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

    [Fact]
    public void CopyConstructor_Works()
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

        Metadata copied = new(model);

        Assert.Equal(model, copied);
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
            JsonSerializer.SerializeToElement("invalid value"),
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
            JsonSerializer.SerializeToElement("invalid value"),
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Timeouts>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Timeouts { Channel = 0, Provider = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Timeouts>(
            element,
            ModelBase.SerializerOptions
        );
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

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Timeouts { Channel = 0, Provider = 0 };

        Timeouts copied = new(model);

        Assert.Equal(model, copied);
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProvidersItem>(
            json,
            ModelBase.SerializerOptions
        );

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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProvidersItem>(
            element,
            ModelBase.SerializerOptions
        );
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

    [Fact]
    public void CopyConstructor_Works()
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

        ProvidersItem copied = new(model);

        Assert.Equal(model, copied);
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

        Utm expectedUtm = new()
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProvidersItemMetadata>(
            json,
            ModelBase.SerializerOptions
        );

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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProvidersItemMetadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Utm expectedUtm = new()
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

    [Fact]
    public void CopyConstructor_Works()
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

        ProvidersItemMetadata copied = new(model);

        Assert.Equal(model, copied);
    }
}
