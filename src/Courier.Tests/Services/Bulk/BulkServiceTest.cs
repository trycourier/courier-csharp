using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Courier.Models.Bulk;
using Models = Courier.Models;

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
                            Categories = new Dictionary<
                                string,
                                Models::NotificationPreferenceDetails
                            >()
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
                                    }
                                },
                            },
                            Notifications = new Dictionary<
                                string,
                                Models::NotificationPreferenceDetails
                            >()
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
                Message = new InboundBulkTemplateMessage()
                {
                    Template = "template",
                    Brand = "brand",
                    Data = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Event = "event",
                    Locale = new Dictionary<string, Dictionary<string, JsonElement>>()
                    {
                        {
                            "foo",
                            new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            }
                        },
                    },
                    Override = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
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
