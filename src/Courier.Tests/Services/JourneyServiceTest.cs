using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Courier.Models.Journeys;

namespace Courier.Tests.Services;

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
                    new JourneyApiInvokeTriggerNode()
                    {
                        TriggerType = TriggerType.ApiInvoke,
                        Type = JourneyApiInvokeTriggerNodeType.Trigger,
                        ID = "send-1",
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
