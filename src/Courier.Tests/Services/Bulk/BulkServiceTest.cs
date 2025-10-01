using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Courier.Models.Bulk.InboundBulkMessageProperties.MessageProperties;
using Courier.Models.Bulk.UserRecipientProperties.PreferencesProperties.NotificationsProperties.NotificationsItemProperties;
using Courier.Models.Lists.Subscriptions.RecipientPreferencesProperties.CategoriesProperties;
using Courier.Models.Lists.Subscriptions.RecipientPreferencesProperties.NotificationsProperties;
using Courier.Models.Send;
using Courier.Models.Send.BaseMessageProperties.ChannelsProperties;
using Courier.Models.Send.BaseMessageProperties.ProvidersProperties;
using Courier.Models.Send.BaseMessageProperties.RoutingProperties.ChannelProperties;
using Courier.Models.Send.BaseMessageProperties.TimeoutProperties;
using Courier.Models.Tenants.DefaultPreferences.Items;
using Courier.Models.Users.Preferences;
using CategoriesItemProperties = Courier.Models.Bulk.UserRecipientProperties.PreferencesProperties.CategoriesProperties.CategoriesItemProperties;
using CategoriesProperties = Courier.Models.Bulk.UserRecipientProperties.PreferencesProperties.CategoriesProperties;
using NotificationsProperties = Courier.Models.Bulk.UserRecipientProperties.PreferencesProperties.NotificationsProperties;
using ProvidersProperties = Courier.Models.Send.BaseMessageProperties.RoutingProperties.ChannelProperties.RoutingStrategyChannelProperties.ProvidersProperties;

namespace Courier.Tests.Services.Bulk;

public class BulkServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task AddUsers_Works()
    {
        await this.client.Bulk.AddUsers(
            new()
            {
                JobID = "job_id",
                Users =
                [
                    new()
                    {
                        Data = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Preferences = new()
                        {
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
                                    }
                                },
                            },
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
                                    }
                                },
                            },
                        },
                        Profile = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Recipient = "recipient",
                        To = new()
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
                                Notifications = new Dictionary<
                                    string,
                                    NotificationsProperties::NotificationsItem
                                >()
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
                                Categories = new Dictionary<
                                    string,
                                    CategoriesProperties::CategoriesItem
                                >()
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
                            UserID = "user_id",
                        },
                    },
                ],
            }
        );
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task CreateJob_Works()
    {
        var response = await this.client.Bulk.CreateJob(
            new()
            {
                Message = new()
                {
                    Brand = "brand",
                    Data = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Event = "event",
                    Locale = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Message = new InboundBulkTemplateMessage()
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
                                                    {
                                                        "foo",
                                                        JsonSerializer.SerializeToElement("bar")
                                                    },
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
                        Template = "template",
                    },
                    Override = JsonSerializer.Deserialize<JsonElement>("{}"),
                },
            }
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListUsers_Works()
    {
        var response = await this.client.Bulk.ListUsers(new() { JobID = "job_id" });
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task RetrieveJob_Works()
    {
        var response = await this.client.Bulk.RetrieveJob(new() { JobID = "job_id" });
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task RunJob_Works()
    {
        await this.client.Bulk.RunJob(new() { JobID = "job_id" });
    }
}
