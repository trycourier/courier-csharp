using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models;
using Courier.Models.Tenants;

namespace Courier.Tests.Models.Tenants;

public class PutTenantTemplateRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PutTenantTemplateRequest
        {
            Template = new()
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
                    Brand = "brand",
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
            },
            Published = true,
        };

        TenantTemplateInput expectedTemplate = new()
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
                Brand = "brand",
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
        bool expectedPublished = true;

        Assert.Equal(expectedTemplate, model.Template);
        Assert.Equal(expectedPublished, model.Published);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PutTenantTemplateRequest
        {
            Template = new()
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
                    Brand = "brand",
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
            },
            Published = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PutTenantTemplateRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PutTenantTemplateRequest
        {
            Template = new()
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
                    Brand = "brand",
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
            },
            Published = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PutTenantTemplateRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        TenantTemplateInput expectedTemplate = new()
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
                Brand = "brand",
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
        bool expectedPublished = true;

        Assert.Equal(expectedTemplate, deserialized.Template);
        Assert.Equal(expectedPublished, deserialized.Published);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PutTenantTemplateRequest
        {
            Template = new()
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
                    Brand = "brand",
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
            },
            Published = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PutTenantTemplateRequest
        {
            Template = new()
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
                    Brand = "brand",
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
            },
        };

        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PutTenantTemplateRequest
        {
            Template = new()
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
                    Brand = "brand",
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
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PutTenantTemplateRequest
        {
            Template = new()
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
                    Brand = "brand",
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
            },

            // Null should be interpreted as omitted for these properties
            Published = null,
        };

        Assert.Null(model.Published);
        Assert.False(model.RawData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PutTenantTemplateRequest
        {
            Template = new()
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
                    Brand = "brand",
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
            },

            // Null should be interpreted as omitted for these properties
            Published = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PutTenantTemplateRequest
        {
            Template = new()
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
                    Brand = "brand",
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
            },
            Published = true,
        };

        PutTenantTemplateRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
