using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Courier.Models.Bulk;
using Courier.Models.Bulk.UserRecipientProperties.PreferencesProperties.CategoriesProperties;
using Courier.Models.Bulk.UserRecipientProperties.PreferencesProperties.NotificationsProperties;
using Courier.Models.Bulk.UserRecipientProperties.PreferencesProperties.NotificationsProperties.NotificationsItemProperties;
using Courier.Models.Send.ContentProperties;
using Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.ChannelsProperties;
using Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.ChannelsProperties.ChannelsItemProperties;
using Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.ProvidersProperties;
using Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.RoutingProperties;
using Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.TimeoutProperties;
using Courier.Models.Tenants.DefaultPreferences.Items;
using Courier.Models.Users.Preferences;
using CategoriesItemProperties = Courier.Models.Bulk.UserRecipientProperties.PreferencesProperties.CategoriesProperties.CategoriesItemProperties;

namespace Courier.Tests.Services.Send;

public class SendServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task SendMessage_Works()
    {
        var response = await this.client.Send.SendMessage(
            new()
            {
                Message = new()
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
                    Content = new ElementalContentSugar() { Body = "body", Title = "title" },
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
                    Routing = new() { Channels = ["string"], Method = Method.All },
                    Timeout = new()
                    {
                        Channel = new Dictionary<string, long>() { { "foo", 0 } },
                        Criteria = Criteria.NoEscalation,
                        Escalation = 0,
                        Message = 0,
                        Provider = new Dictionary<string, long>() { { "foo", 0 } },
                    },
                    To = new UserRecipient()
                    {
                        AccountID = "account_id",
                        Context = new() { TenantID = "tenant_id" },
                        Data = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Email = "email",
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
                                        Status = PreferenceStatus.OptedIn,
                                        ChannelPreferences =
                                        [
                                            new(ChannelClassification.DirectMessage),
                                        ],
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
                                        Status = PreferenceStatus.OptedIn,
                                        ChannelPreferences =
                                        [
                                            new(ChannelClassification.DirectMessage),
                                        ],
                                        Rules = [new() { Until = "until", Start = "start" }],
                                        Source = CategoriesItemProperties::Source.Subscription,
                                    }
                                },
                            },
                            TemplateID = "templateId",
                        },
                        TenantID = "tenant_id",
                        UserID = "example_user",
                    },
                },
            }
        );
        response.Validate();
    }
}
