using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Courier.Models;
using Courier.Models.Tenants;

namespace Courier.Tests.Services.Tenants;

public class TemplateServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var baseTemplateTenantAssociation = await this.client.Tenants.Templates.Retrieve(
            "template_id",
            new() { TenantID = "tenant_id" },
            TestContext.Current.CancellationToken
        );
        baseTemplateTenantAssociation.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var templates = await this.client.Tenants.Templates.List(
            "tenant_id",
            new(),
            TestContext.Current.CancellationToken
        );
        templates.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Publish_Works()
    {
        var postTenantTemplatePublishResponse = await this.client.Tenants.Templates.Publish(
            "template_id",
            new() { TenantID = "tenant_id" },
            TestContext.Current.CancellationToken
        );
        postTenantTemplatePublishResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Replace_Works()
    {
        var putTenantTemplateResponse = await this.client.Tenants.Templates.Replace(
            "template_id",
            new()
            {
                TenantID = "tenant_id",
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
            },
            TestContext.Current.CancellationToken
        );
        putTenantTemplateResponse.Validate();
    }
}
