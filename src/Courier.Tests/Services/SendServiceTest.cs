using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Courier.Models.Send;
using Models = Courier.Models;

namespace Courier.Tests.Services;

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
                    Content = new Models::ElementalContentSugar()
                    {
                        Body = "body",
                        Title = "title",
                    },
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
                    Template = "template_id",
                    Timeout = new()
                    {
                        Channel = new Dictionary<string, long>() { { "foo", 0 } },
                        Criteria = Criteria.NoEscalation,
                        Escalation = 0,
                        Message = 0,
                        Provider = new Dictionary<string, long>() { { "foo", 0 } },
                    },
                    To = new Models::UserRecipient()
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
                            Notifications = new Dictionary<string, Models::Preference>()
                            {
                                {
                                    "foo",
                                    new()
                                    {
                                        Status = Models::PreferenceStatus.OptedIn,
                                        ChannelPreferences =
                                        [
                                            new(Models::ChannelClassification.DirectMessage),
                                        ],
                                        Rules = [new() { Until = "until", Start = "start" }],
                                        Source = Models::Source.Subscription,
                                    }
                                },
                            },
                            Categories = new Dictionary<string, Models::Preference>()
                            {
                                {
                                    "foo",
                                    new()
                                    {
                                        Status = Models::PreferenceStatus.OptedIn,
                                        ChannelPreferences =
                                        [
                                            new(Models::ChannelClassification.DirectMessage),
                                        ],
                                        Rules = [new() { Until = "until", Start = "start" }],
                                        Source = Models::Source.Subscription,
                                    }
                                },
                            },
                            TemplateID = "templateId",
                        },
                        TenantID = "tenant_id",
                        UserID = "example_user",
                    },
                },
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
