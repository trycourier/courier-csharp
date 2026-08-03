using System;
using System.Collections.Generic;
using System.Net.Http;
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
                            PhoneNumberOverride = "x",
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
            Enabled = true,
            State = JourneyState.Draft,
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",
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
                        PhoneNumberOverride = "x",
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
        ];
        bool expectedEnabled = true;
        ApiEnum<string, JourneyState> expectedState = JourneyState.Draft;
        string expectedIdempotencyKey = "order-ORD-456-user-123";
        string expectedXIdempotencyExpiration = "1785312000";

        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedNodes.Count, parameters.Nodes.Count);
        for (int i = 0; i < expectedNodes.Count; i++)
        {
            Assert.Equal(expectedNodes[i], parameters.Nodes[i]);
        }
        Assert.Equal(expectedEnabled, parameters.Enabled);
        Assert.Equal(expectedState, parameters.State);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXIdempotencyExpiration, parameters.XIdempotencyExpiration);
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
                            PhoneNumberOverride = "x",
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
        };

        Assert.Null(parameters.Enabled);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled"));
        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XIdempotencyExpiration);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-idempotency-expiration"));
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
                            PhoneNumberOverride = "x",
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

            // Null should be interpreted as omitted for these properties
            Enabled = null,
            State = null,
            IdempotencyKey = null,
            XIdempotencyExpiration = null,
        };

        Assert.Null(parameters.Enabled);
        Assert.False(parameters.RawBodyData.ContainsKey("enabled"));
        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XIdempotencyExpiration);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-idempotency-expiration"));
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
                            PhoneNumberOverride = "x",
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
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.courier.com/journeys"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
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
                            PhoneNumberOverride = "x",
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
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(
            ["order-ORD-456-user-123"],
            requestMessage.Headers.GetValues("Idempotency-Key")
        );
        Assert.Equal(["1785312000"], requestMessage.Headers.GetValues("x-idempotency-expiration"));
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
                            PhoneNumberOverride = "x",
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
            Enabled = true,
            State = JourneyState.Draft,
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",
        };

        JourneyCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
