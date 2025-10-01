using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Courier.Models.Send;
using Courier.Models.Send.BaseMessageProperties.ChannelsProperties;
using Courier.Models.Send.BaseMessageProperties.ProvidersProperties;
using Courier.Models.Send.BaseMessageProperties.RoutingProperties.ChannelProperties;
using Courier.Models.Send.BaseMessageProperties.TimeoutProperties;
using Courier.Models.Send.BaseMessageSendToProperties.ToProperties;
using Courier.Models.Send.BaseMessageSendToProperties.ToProperties.AudienceRecipientProperties.FilterProperties;
using Courier.Models.Send.ContentProperties;
using Courier.Models.Send.ElementalNodeProperties.UnionMember0Properties;
using Courier.Models.Send.MessageProperties;
using ElementalNodeProperties = Courier.Models.Send.ElementalNodeProperties;
using ProvidersProperties = Courier.Models.Send.BaseMessageProperties.RoutingProperties.ChannelProperties.RoutingStrategyChannelProperties.ProvidersProperties;

namespace Courier.Tests.Services.Send;

public class SendServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task SendMessage_Works()
    {
        var response = await this.client.Send.SendMessage(
            new()
            {
                Message = new ContentMessage()
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
                    Routing = new()
                    {
                        Channels =
                        [
                            new RoutingStrategyChannel()
                            {
                                Channel = "channel",
                                Config = new Dictionary<string, JsonElement>()
                                {
                                    { "foo", JsonSerializer.SerializeToElement("bar") },
                                },
                                If = "if",
                                Method = RoutingMethod.All,
                                Providers = new Dictionary<
                                    string,
                                    ProvidersProperties::ProvidersItem
                                >()
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
                            },
                        ],
                        Method = RoutingMethod.All,
                    },
                    Timeout = new()
                    {
                        Channel = new Dictionary<string, long>() { { "foo", 0 } },
                        Criteria = Criteria.NoEscalation,
                        Escalation = 0,
                        Message = 0,
                        Provider = new Dictionary<string, long>() { { "foo", 0 } },
                    },
                    To = new AudienceRecipient()
                    {
                        AudienceID = "audience_id",
                        Data = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Filters =
                        [
                            new()
                            {
                                Operator = Operator.MemberOf,
                                Path = Path.AccountID,
                                Value = "value",
                            },
                        ],
                    },
                    Content = new ElementalContent()
                    {
                        Elements =
                        [
                            new ElementalNodeProperties::UnionMember0()
                            {
                                Channels = ["string"],
                                If = "if",
                                Loop = "loop",
                                Ref = "ref",
                                Type = Type.Text,
                            },
                        ],
                        Version = "version",
                        Brand = JsonSerializer.Deserialize<JsonElement>("{}"),
                    },
                },
            }
        );
        response.Validate();
    }
}
