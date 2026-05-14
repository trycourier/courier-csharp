using System;
using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models.Journeys;

namespace Courier.Tests.Models.Journeys;

public class JourneyReplaceParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new JourneyReplaceParams
        {
            TemplateID = "x",
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
            Enabled = true,
            State = JourneyState.Draft,
        };

        string expectedTemplateID = "x";
        string expectedName = "Welcome Journey v2";
        List<JourneyNode> expectedNodes =
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
        ];
        bool expectedEnabled = true;
        ApiEnum<string, JourneyState> expectedState = JourneyState.Draft;

        Assert.Equal(expectedTemplateID, parameters.TemplateID);
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
        var parameters = new JourneyReplaceParams
        {
            TemplateID = "x",
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
        };

        Assert.Null(parameters.Enabled);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled"));
        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new JourneyReplaceParams
        {
            TemplateID = "x",
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
        JourneyReplaceParams parameters = new()
        {
            TemplateID = "x",
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
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.courier.com/journeys/x"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new JourneyReplaceParams
        {
            TemplateID = "x",
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
            Enabled = true,
            State = JourneyState.Draft,
        };

        JourneyReplaceParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
