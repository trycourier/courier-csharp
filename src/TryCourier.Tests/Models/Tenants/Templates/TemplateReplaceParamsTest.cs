using System;
using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Models;
using TryCourier.Models.Tenants;
using TryCourier.Models.Tenants.Templates;

namespace TryCourier.Tests.Models.Tenants.Templates;

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
                            Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                        },
                    ],
                    Version = "2022-01-01",
                },
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
                Routing = new() { Channels = ["email"], Method = Method.Single },
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
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "2022-01-01",
            },
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
            Routing = new() { Channels = ["email"], Method = Method.Single },
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
                            Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                        },
                    ],
                    Version = "2022-01-01",
                },
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
                Routing = new() { Channels = ["email"], Method = Method.Single },
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
                            Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                        },
                    ],
                    Version = "2022-01-01",
                },
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
                Routing = new() { Channels = ["email"], Method = Method.Single },
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
                            Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                        },
                    ],
                    Version = "2022-01-01",
                },
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
                Routing = new() { Channels = ["email"], Method = Method.Single },
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/tenants/tenant_id/templates/template_id"),
                url
            )
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
                            Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                        },
                    ],
                    Version = "2022-01-01",
                },
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
                Routing = new() { Channels = ["email"], Method = Method.Single },
            },
            Published = true,
        };

        TemplateReplaceParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
