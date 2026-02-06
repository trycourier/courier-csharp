using System;
using System.Collections.Generic;
using System.Text.Json;
using Courier.Models;
using Courier.Models.Tenants;
using Courier.Models.Tenants.Templates;

namespace Courier.Tests.Models.Tenants.Templates;

public class TemplateReplaceParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TemplateReplaceParams
        {
            TenantID = "tenant_id",
            TemplateID = "template_id",
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

        string expectedTenantID = "tenant_id";
        string expectedTemplateID = "template_id";
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

        Assert.Equal(expectedTenantID, parameters.TenantID);
        Assert.Equal(expectedTemplateID, parameters.TemplateID);
        Assert.Equal(expectedTemplate, parameters.Template);
        Assert.Equal(expectedPublished, parameters.Published);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TemplateReplaceParams
        {
            TenantID = "tenant_id",
            TemplateID = "template_id",
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

        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TemplateReplaceParams
        {
            TenantID = "tenant_id",
            TemplateID = "template_id",
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

        Assert.Null(parameters.Published);
        Assert.False(parameters.RawBodyData.ContainsKey("published"));
    }

    [Fact]
    public void Url_Works()
    {
        TemplateReplaceParams parameters = new()
        {
            TenantID = "tenant_id",
            TemplateID = "template_id",
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

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.courier.com/tenants/tenant_id/templates/template_id"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TemplateReplaceParams
        {
            TenantID = "tenant_id",
            TemplateID = "template_id",
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

        TemplateReplaceParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
