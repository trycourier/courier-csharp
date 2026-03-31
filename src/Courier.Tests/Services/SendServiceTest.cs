using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Courier.Models;
using Send = Courier.Models.Send;

namespace Courier.Tests.Services;

public class SendServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Message_Works()
    {
        var response = await this.client.Send.Message(
            new()
            {
                Message = new()
                {
                    BrandID = "brand_id",
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
                    Content = new ElementalContentSugar() { Body = "body", Title = "title" },
                    Context = new() { TenantID = "tenant_id" },
                    Data = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Delay = new()
                    {
                        Duration = 0,
                        Timezone = "timezone",
                        Until = "until",
                    },
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
                    Routing = new() { Channels = ["string"], Method = Send::Method.All },
                    Template = "template_id",
                    Timeout = new()
                    {
                        Channel = new Dictionary<string, long>() { { "foo", 0 } },
                        Criteria = Send::Criteria.NoEscalation,
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
                        ListID = "list_id",
                        Locale = "locale",
                        PhoneNumber = "phone_number",
                        Preferences = new()
                        {
                            Notifications = new Dictionary<string, Preference>()
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
                            Categories = new Dictionary<string, Preference>()
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
                            TemplateID = "templateId",
                        },
                        TenantID = "tenant_id",
                        UserID = "user_id",
                    },
                },
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
