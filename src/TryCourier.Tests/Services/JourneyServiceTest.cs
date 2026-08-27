using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Services;

public class JourneyServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var journeyResponse = await this.client.Journeys.Create(
            new()
            {
                Name = "Welcome Journey",
                Nodes =
                [
                    new JourneyApiInvokeTriggerNode()
                    {
                        TriggerType = TriggerType.ApiInvoke,
                        Type = JourneyApiInvokeTriggerNodeType.Trigger,
                        ID = "trigger-1",
                        Conditions = new(["string", "string"]),
                        Schema = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    },
                    new JourneySendNode()
                    {
                        Message = new()
                        {
                            Context = new("x"),
                            Data = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Delay = new() { Until = "x", Timezone = "x" },
                            Template = "nt_01kx4h2jdafq8bk9aftxak4b40",
                            To = new()
                            {
                                EmailOverride = "x",
                                MsTeams = new()
                                {
                                    ChannelID = "x",
                                    ChannelName = "x",
                                    Email = "x",
                                    ServiceUrl = "x",
                                    TeamID = "x",
                                    TenantID = "x",
                                    UserID = "x",
                                },
                                PhoneNumberOverride = "x",
                                Slack = new JourneySendNodeToSlackChannel()
                                {
                                    Channel = "x",
                                    AccessToken = "x",
                                },
                                UserIDOverride = "x",
                            },
                        },
                        Type = JourneySendNodeType.Send,
                        ID = "send-1",
                        Conditions = new(["string", "string"]),
                        Experiment = new()
                        {
                            BucketingKey = "x",
                            Variants =
                            [
                                new()
                                {
                                    ID = "x",
                                    TemplateID = "x",
                                    Weight = 0,
                                    Name = "name",
                                },
                                new()
                                {
                                    ID = "x",
                                    TemplateID = "x",
                                    Weight = 0,
                                    Name = "name",
                                },
                            ],
                            ID = "x",
                            Name = "name",
                        },
                    },
                    new JourneyExitNode() { Type = JourneyExitNodeType.Exit, ID = "exit-1" },
                ],
            },
            TestContext.Current.CancellationToken
        );
        journeyResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var journeyResponse = await this.client.Journeys.Retrieve(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        journeyResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var journeysListResponse = await this.client.Journeys.List(
            new(),
            TestContext.Current.CancellationToken
        );
        journeysListResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Archive_Works()
    {
        await this.client.Journeys.Archive("x", new(), TestContext.Current.CancellationToken);
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Cancel_Works()
    {
        var cancelJourneyResponse = await this.client.Journeys.Cancel(
            new() { CancelJourneyRequest = new ByCancelationToken("order-1234") },
            TestContext.Current.CancellationToken
        );
        cancelJourneyResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Invoke_Works()
    {
        var journeysInvokeResponse = await this.client.Journeys.Invoke(
            "templateId",
            new(),
            TestContext.Current.CancellationToken
        );
        journeysInvokeResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListVersions_Works()
    {
        var journeyVersionsListResponse = await this.client.Journeys.ListVersions(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        journeyVersionsListResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Publish_Works()
    {
        var journeyResponse = await this.client.Journeys.Publish(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        journeyResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Replace_Works()
    {
        var journeyResponse = await this.client.Journeys.Replace(
            "x",
            new()
            {
                Name = "Welcome Journey v2",
                Nodes =
                [
                    new JourneyApiInvokeTriggerNode()
                    {
                        TriggerType = TriggerType.ApiInvoke,
                        Type = JourneyApiInvokeTriggerNodeType.Trigger,
                        ID = "x",
                        Conditions = new(["string", "string"]),
                        Schema = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        journeyResponse.Validate();
    }
}
