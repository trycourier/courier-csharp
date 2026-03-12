using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Courier.Models;

namespace Courier.Tests.Services;

public class BulkServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task AddUsers_Works()
    {
        await this.client.Bulk.AddUsers(
            "job_id",
            new()
            {
                Users =
                [
                    new()
                    {
                        Data = JsonSerializer.Deserialize<JsonElement>("{}"),
                        Preferences = new()
                        {
                            Categories = new Dictionary<string, NotificationPreferenceDetails>()
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
                            Notifications = new Dictionary<string, NotificationPreferenceDetails>()
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
                        Profile = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
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
                ],
            },
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task CreateJob_Works()
    {
        var response = await this.client.Bulk.CreateJob(
            new()
            {
                Message = new()
                {
                    Event = "event",
                    Brand = "brand",
                    Content = new ElementalContentSugar() { Body = "body", Title = "title" },
                    Data = new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    },
                    Locale = new Dictionary<string, IReadOnlyDictionary<string, JsonElement>>()
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
                    Template = "template",
                },
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListUsers_Works()
    {
        var response = await this.client.Bulk.ListUsers(
            "job_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveJob_Works()
    {
        var response = await this.client.Bulk.RetrieveJob(
            "job_id",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RunJob_Works()
    {
        await this.client.Bulk.RunJob("job_id", new(), TestContext.Current.CancellationToken);
    }
}
