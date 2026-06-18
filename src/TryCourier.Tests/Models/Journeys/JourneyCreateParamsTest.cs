using System;
using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneyCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new JourneyCreateParams
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
            Enabled = true,
            State = JourneyState.Draft,
        };

        string expectedName = "Welcome Journey";
        List<JourneyNode> expectedNodes =
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
        ];
        bool expectedEnabled = true;
        ApiEnum<string, JourneyState> expectedState = JourneyState.Draft;

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedNodes.Count, parameters.Nodes.Count);
        for (int i = 0; i < expectedNodes.Count; i++)
        {
            Assert.Equal(expectedNodes[i], parameters.Nodes[i]);
        }
        Assert.Equal(expectedEnabled, parameters.Enabled);
        Assert.Equal(expectedState, parameters.State);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new JourneyCreateParams
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
        };

        Assert.Null(parameters.Enabled);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled"));
        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new JourneyCreateParams
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

            // Null should be interpreted as omitted for these properties
            Enabled = null,
            State = null,
        };

        Assert.Null(parameters.Enabled);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled"));
        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
    }

    [Fact]
    public void Url_Works()
    {
        JourneyCreateParams parameters = new()
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
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.courier.com/journeys"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new JourneyCreateParams
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
            Enabled = true,
            State = JourneyState.Draft,
        };

        JourneyCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
