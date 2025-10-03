using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ChannelsProperties;
using Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ChannelsProperties.ChannelsItemProperties;
using Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ProvidersProperties;
using Courier.Models.Send.SendMessageParamsProperties.MessageProperties.RoutingProperties;
using Courier.Models.Send.SendMessageParamsProperties.MessageProperties.TimeoutProperties;
using Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ToProperties;
using Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ToProperties.UnionMember0Properties.PreferencesProperties.CategoriesProperties;
using Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ToProperties.UnionMember0Properties.PreferencesProperties.NotificationsProperties;
using Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ToProperties.UnionMember0Properties.PreferencesProperties.NotificationsProperties.NotificationsItemProperties;
using Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ToProperties.UnionMember0Properties.PreferencesProperties.NotificationsProperties.NotificationsItemProperties.ChannelPreferenceProperties;
using CategoriesItemProperties = Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ToProperties.UnionMember0Properties.PreferencesProperties.CategoriesProperties.CategoriesItemProperties;
using ChannelPreferenceProperties = Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ToProperties.UnionMember0Properties.PreferencesProperties.CategoriesProperties.CategoriesItemProperties.ChannelPreferenceProperties;

namespace Courier.Tests.Services.Send;

public class SendServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Message_Works()
    {
        var response = await this.client.Send.Message(
            new()
            {
                Message = new()
                {
                    Content = new()
                    {
                        Body = "Thanks for signing up, {{name}}",
                        Title = "Welcome!",
                    },
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
                        { "name", JsonSerializer.SerializeToElement("bar") },
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
                    Routing = new() { Channels = ["email"], Method = Method.Single },
                    Timeout = new()
                    {
                        Channel = new Dictionary<string, long>() { { "foo", 0 } },
                        Criteria = Criteria.NoEscalation,
                        Escalation = 0,
                        Message = 0,
                        Provider = new Dictionary<string, long>() { { "foo", 0 } },
                    },
                    To = new UnionMember0()
                    {
                        AccountID = "account_id",
                        Context = new() { TenantID = "tenant_id" },
                        Data = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Email = "email@example.com",
                        Locale = "locale",
                        PhoneNumber = "phone_number",
                        Preferences = new()
                        {
                            Notifications = new Dictionary<string, NotificationsItem>()
                            {
                                {
                                    "foo",
                                    new()
                                    {
                                        Status = Status.OptedIn,
                                        ChannelPreferences = [new(Channel.DirectMessage)],
                                        Rules = [new() { Until = "until", Start = "start" }],
                                        Source = Source.Subscription,
                                    }
                                },
                            },
                            Categories = new Dictionary<string, CategoriesItem>()
                            {
                                {
                                    "foo",
                                    new()
                                    {
                                        Status = CategoriesItemProperties::Status.OptedIn,
                                        ChannelPreferences =
                                        [
                                            new(ChannelPreferenceProperties::Channel.DirectMessage),
                                        ],
                                        Rules = [new() { Until = "until", Start = "start" }],
                                        Source = CategoriesItemProperties::Source.Subscription,
                                    }
                                },
                            },
                            TemplateID = "templateId",
                        },
                        TenantID = "tenant_id",
                        UserID = "user_id",
                    },
                },
            }
        );
        response.Validate();
    }
}
