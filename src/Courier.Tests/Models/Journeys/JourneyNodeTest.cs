using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Journeys;

namespace Courier.Tests.Models.Journeys;

public class JourneyNodeTest : TestBase
{
    [Fact]
    public void ApiInvokeTriggerValidationWorks()
    {
        JourneyNode value = new JourneyApiInvokeTriggerNode()
        {
            TriggerType = TriggerType.ApiInvoke,
            Type = JourneyApiInvokeTriggerNodeType.Trigger,
            ID = "x",
            Conditions = new(["string", "string"]),
            Schema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };
        value.Validate();
    }

    [Fact]
    public void SegmentTriggerValidationWorks()
    {
        JourneyNode value = new JourneySegmentTriggerNode()
        {
            RequestType = RequestType.Identify,
            TriggerType = JourneySegmentTriggerNodeTriggerType.Segment,
            Type = JourneySegmentTriggerNodeType.Trigger,
            ID = "x",
            Conditions = new(["string", "string"]),
            EventID = "x",
        };
        value.Validate();
    }

    [Fact]
    public void SendValidationWorks()
    {
        JourneyNode value = new JourneySendNode()
        {
            Message = new()
            {
                Template = "x",
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Delay = new() { Until = "x", Timezone = "x" },
                To = new()
                {
                    EmailOverride = "x",
                    PhoneNumberOverride = "x",
                    UserIDOverride = "x",
                },
            },
            Type = JourneySendNodeType.Send,
            ID = "x",
            Conditions = new(["string", "string"]),
        };
        value.Validate();
    }

    [Fact]
    public void DelayDurationValidationWorks()
    {
        JourneyNode value = new JourneyDelayDurationNode()
        {
            Duration = "x",
            Mode = Mode.Duration,
            Type = JourneyDelayDurationNodeType.Delay,
            ID = "x",
            Conditions = new(["string", "string"]),
        };
        value.Validate();
    }

    [Fact]
    public void DelayUntilValidationWorks()
    {
        JourneyNode value = new JourneyDelayUntilNode()
        {
            Mode = JourneyDelayUntilNodeMode.Until,
            Type = JourneyDelayUntilNodeType.Delay,
            Until = "x",
            ID = "x",
            Conditions = new(["string", "string"]),
        };
        value.Validate();
    }

    [Fact]
    public void FetchGetDeleteValidationWorks()
    {
        JourneyNode value = new JourneyFetchGetDeleteNode()
        {
            MergeStrategy = JourneyMergeStrategy.Overwrite,
            Method = Method.Get,
            Type = JourneyFetchGetDeleteNodeType.Fetch,
            Url = "x",
            ID = "x",
            Conditions = new(["string", "string"]),
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            QueryParams = new Dictionary<string, string>() { { "foo", "string" } },
            ResponseSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };
        value.Validate();
    }

    [Fact]
    public void FetchPostPutValidationWorks()
    {
        JourneyNode value = new JourneyFetchPostPutNode()
        {
            MergeStrategy = JourneyMergeStrategy.Overwrite,
            Method = JourneyFetchPostPutNodeMethod.Post,
            Type = JourneyFetchPostPutNodeType.Fetch,
            Url = "x",
            ID = "x",
            Body = "body",
            Conditions = new(["string", "string"]),
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            QueryParams = new Dictionary<string, string>() { { "foo", "string" } },
            ResponseSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };
        value.Validate();
    }

    [Fact]
    public void AIValidationWorks()
    {
        JourneyNode value = new JourneyAINode()
        {
            OutputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = Type.AI,
            ID = "x",
            Conditions = new(["string", "string"]),
            Model = "x",
            UserPrompt = "user_prompt",
            WebSearch = true,
        };
        value.Validate();
    }

    [Fact]
    public void ThrottleStaticValidationWorks()
    {
        JourneyNode value = new JourneyThrottleStaticNode()
        {
            MaxAllowed = 1,
            Period = "x",
            Scope = JourneyThrottleStaticNodeScope.User,
            Type = JourneyThrottleStaticNodeType.Throttle,
            ID = "x",
            Conditions = new(["string", "string"]),
        };
        value.Validate();
    }

    [Fact]
    public void ThrottleDynamicValidationWorks()
    {
        JourneyNode value = new JourneyThrottleDynamicNode()
        {
            MaxAllowed = 1,
            Period = "x",
            Scope = JourneyThrottleDynamicNodeScope.Dynamic,
            ThrottleKey = "x",
            Type = JourneyThrottleDynamicNodeType.Throttle,
            ID = "x",
            Conditions = new(["string", "string"]),
        };
        value.Validate();
    }

    [Fact]
    public void BatchValidationWorks()
    {
        JourneyNode value = new JourneyBatchNode()
        {
            MaxWaitPeriod = "x",
            Retain = new()
            {
                Count = 0,
                Type = RetainType.First,
                SortKey = "x",
            },
            Scope = Scope.User,
            Type = JourneyBatchNodeType.Batch,
            WaitPeriod = "x",
            ID = "x",
            CategoryKey = "x",
            Conditions = new(["string", "string"]),
            MaxItems = 1,
        };
        value.Validate();
    }

    [Fact]
    public void ExitValidationWorks()
    {
        JourneyNode value = new JourneyExitNode() { Type = JourneyExitNodeType.Exit, ID = "x" };
        value.Validate();
    }

    [Fact]
    public void BranchValidationWorks()
    {
        JourneyNode value = new JourneyBranchNode()
        {
            Default = new()
            {
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
                Label = "x",
            },
            Paths =
            [
                new()
                {
                    Conditions = new(["string", "string"]),
                    Nodes = [],
                    Label = "x",
                },
            ],
            Type = JourneyBranchNodeType.Branch,
            ID = "x",
        };
        value.Validate();
    }

    [Fact]
    public void ApiInvokeTriggerSerializationRoundtripWorks()
    {
        JourneyNode value = new JourneyApiInvokeTriggerNode()
        {
            TriggerType = TriggerType.ApiInvoke,
            Type = JourneyApiInvokeTriggerNodeType.Trigger,
            ID = "x",
            Conditions = new(["string", "string"]),
            Schema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SegmentTriggerSerializationRoundtripWorks()
    {
        JourneyNode value = new JourneySegmentTriggerNode()
        {
            RequestType = RequestType.Identify,
            TriggerType = JourneySegmentTriggerNodeTriggerType.Segment,
            Type = JourneySegmentTriggerNodeType.Trigger,
            ID = "x",
            Conditions = new(["string", "string"]),
            EventID = "x",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SendSerializationRoundtripWorks()
    {
        JourneyNode value = new JourneySendNode()
        {
            Message = new()
            {
                Template = "x",
                Data = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Delay = new() { Until = "x", Timezone = "x" },
                To = new()
                {
                    EmailOverride = "x",
                    PhoneNumberOverride = "x",
                    UserIDOverride = "x",
                },
            },
            Type = JourneySendNodeType.Send,
            ID = "x",
            Conditions = new(["string", "string"]),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DelayDurationSerializationRoundtripWorks()
    {
        JourneyNode value = new JourneyDelayDurationNode()
        {
            Duration = "x",
            Mode = Mode.Duration,
            Type = JourneyDelayDurationNodeType.Delay,
            ID = "x",
            Conditions = new(["string", "string"]),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DelayUntilSerializationRoundtripWorks()
    {
        JourneyNode value = new JourneyDelayUntilNode()
        {
            Mode = JourneyDelayUntilNodeMode.Until,
            Type = JourneyDelayUntilNodeType.Delay,
            Until = "x",
            ID = "x",
            Conditions = new(["string", "string"]),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FetchGetDeleteSerializationRoundtripWorks()
    {
        JourneyNode value = new JourneyFetchGetDeleteNode()
        {
            MergeStrategy = JourneyMergeStrategy.Overwrite,
            Method = Method.Get,
            Type = JourneyFetchGetDeleteNodeType.Fetch,
            Url = "x",
            ID = "x",
            Conditions = new(["string", "string"]),
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            QueryParams = new Dictionary<string, string>() { { "foo", "string" } },
            ResponseSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void FetchPostPutSerializationRoundtripWorks()
    {
        JourneyNode value = new JourneyFetchPostPutNode()
        {
            MergeStrategy = JourneyMergeStrategy.Overwrite,
            Method = JourneyFetchPostPutNodeMethod.Post,
            Type = JourneyFetchPostPutNodeType.Fetch,
            Url = "x",
            ID = "x",
            Body = "body",
            Conditions = new(["string", "string"]),
            Headers = new Dictionary<string, string>() { { "foo", "string" } },
            QueryParams = new Dictionary<string, string>() { { "foo", "string" } },
            ResponseSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AISerializationRoundtripWorks()
    {
        JourneyNode value = new JourneyAINode()
        {
            OutputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = Type.AI,
            ID = "x",
            Conditions = new(["string", "string"]),
            Model = "x",
            UserPrompt = "user_prompt",
            WebSearch = true,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThrottleStaticSerializationRoundtripWorks()
    {
        JourneyNode value = new JourneyThrottleStaticNode()
        {
            MaxAllowed = 1,
            Period = "x",
            Scope = JourneyThrottleStaticNodeScope.User,
            Type = JourneyThrottleStaticNodeType.Throttle,
            ID = "x",
            Conditions = new(["string", "string"]),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ThrottleDynamicSerializationRoundtripWorks()
    {
        JourneyNode value = new JourneyThrottleDynamicNode()
        {
            MaxAllowed = 1,
            Period = "x",
            Scope = JourneyThrottleDynamicNodeScope.Dynamic,
            ThrottleKey = "x",
            Type = JourneyThrottleDynamicNodeType.Throttle,
            ID = "x",
            Conditions = new(["string", "string"]),
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BatchSerializationRoundtripWorks()
    {
        JourneyNode value = new JourneyBatchNode()
        {
            MaxWaitPeriod = "x",
            Retain = new()
            {
                Count = 0,
                Type = RetainType.First,
                SortKey = "x",
            },
            Scope = Scope.User,
            Type = JourneyBatchNodeType.Batch,
            WaitPeriod = "x",
            ID = "x",
            CategoryKey = "x",
            Conditions = new(["string", "string"]),
            MaxItems = 1,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ExitSerializationRoundtripWorks()
    {
        JourneyNode value = new JourneyExitNode() { Type = JourneyExitNodeType.Exit, ID = "x" };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BranchSerializationRoundtripWorks()
    {
        JourneyNode value = new JourneyBranchNode()
        {
            Default = new()
            {
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
                Label = "x",
            },
            Paths =
            [
                new()
                {
                    Conditions = new(["string", "string"]),
                    Nodes = [],
                    Label = "x",
                },
            ],
            Type = JourneyBranchNodeType.Branch,
            ID = "x",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class JourneyBatchNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyBatchNode
        {
            MaxWaitPeriod = "x",
            Retain = new()
            {
                Count = 0,
                Type = RetainType.First,
                SortKey = "x",
            },
            Scope = Scope.User,
            Type = JourneyBatchNodeType.Batch,
            WaitPeriod = "x",
            ID = "x",
            CategoryKey = "x",
            Conditions = new(["string", "string"]),
            MaxItems = 1,
        };

        string expectedMaxWaitPeriod = "x";
        Retain expectedRetain = new()
        {
            Count = 0,
            Type = RetainType.First,
            SortKey = "x",
        };
        ApiEnum<string, Scope> expectedScope = Scope.User;
        ApiEnum<string, JourneyBatchNodeType> expectedType = JourneyBatchNodeType.Batch;
        string expectedWaitPeriod = "x";
        string expectedID = "x";
        string expectedCategoryKey = "x";
        JourneyConditionsField expectedConditions = new(["string", "string"]);
        long expectedMaxItems = 1;

        Assert.Equal(expectedMaxWaitPeriod, model.MaxWaitPeriod);
        Assert.Equal(expectedRetain, model.Retain);
        Assert.Equal(expectedScope, model.Scope);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedWaitPeriod, model.WaitPeriod);
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCategoryKey, model.CategoryKey);
        Assert.Equal(expectedConditions, model.Conditions);
        Assert.Equal(expectedMaxItems, model.MaxItems);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneyBatchNode
        {
            MaxWaitPeriod = "x",
            Retain = new()
            {
                Count = 0,
                Type = RetainType.First,
                SortKey = "x",
            },
            Scope = Scope.User,
            Type = JourneyBatchNodeType.Batch,
            WaitPeriod = "x",
            ID = "x",
            CategoryKey = "x",
            Conditions = new(["string", "string"]),
            MaxItems = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyBatchNode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyBatchNode
        {
            MaxWaitPeriod = "x",
            Retain = new()
            {
                Count = 0,
                Type = RetainType.First,
                SortKey = "x",
            },
            Scope = Scope.User,
            Type = JourneyBatchNodeType.Batch,
            WaitPeriod = "x",
            ID = "x",
            CategoryKey = "x",
            Conditions = new(["string", "string"]),
            MaxItems = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyBatchNode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMaxWaitPeriod = "x";
        Retain expectedRetain = new()
        {
            Count = 0,
            Type = RetainType.First,
            SortKey = "x",
        };
        ApiEnum<string, Scope> expectedScope = Scope.User;
        ApiEnum<string, JourneyBatchNodeType> expectedType = JourneyBatchNodeType.Batch;
        string expectedWaitPeriod = "x";
        string expectedID = "x";
        string expectedCategoryKey = "x";
        JourneyConditionsField expectedConditions = new(["string", "string"]);
        long expectedMaxItems = 1;

        Assert.Equal(expectedMaxWaitPeriod, deserialized.MaxWaitPeriod);
        Assert.Equal(expectedRetain, deserialized.Retain);
        Assert.Equal(expectedScope, deserialized.Scope);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedWaitPeriod, deserialized.WaitPeriod);
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCategoryKey, deserialized.CategoryKey);
        Assert.Equal(expectedConditions, deserialized.Conditions);
        Assert.Equal(expectedMaxItems, deserialized.MaxItems);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneyBatchNode
        {
            MaxWaitPeriod = "x",
            Retain = new()
            {
                Count = 0,
                Type = RetainType.First,
                SortKey = "x",
            },
            Scope = Scope.User,
            Type = JourneyBatchNodeType.Batch,
            WaitPeriod = "x",
            ID = "x",
            CategoryKey = "x",
            Conditions = new(["string", "string"]),
            MaxItems = 1,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneyBatchNode
        {
            MaxWaitPeriod = "x",
            Retain = new()
            {
                Count = 0,
                Type = RetainType.First,
                SortKey = "x",
            },
            Scope = Scope.User,
            Type = JourneyBatchNodeType.Batch,
            WaitPeriod = "x",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CategoryKey);
        Assert.False(model.RawData.ContainsKey("category_key"));
        Assert.Null(model.Conditions);
        Assert.False(model.RawData.ContainsKey("conditions"));
        Assert.Null(model.MaxItems);
        Assert.False(model.RawData.ContainsKey("max_items"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneyBatchNode
        {
            MaxWaitPeriod = "x",
            Retain = new()
            {
                Count = 0,
                Type = RetainType.First,
                SortKey = "x",
            },
            Scope = Scope.User,
            Type = JourneyBatchNodeType.Batch,
            WaitPeriod = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneyBatchNode
        {
            MaxWaitPeriod = "x",
            Retain = new()
            {
                Count = 0,
                Type = RetainType.First,
                SortKey = "x",
            },
            Scope = Scope.User,
            Type = JourneyBatchNodeType.Batch,
            WaitPeriod = "x",

            // Null should be interpreted as omitted for these properties
            ID = null,
            CategoryKey = null,
            Conditions = null,
            MaxItems = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.CategoryKey);
        Assert.False(model.RawData.ContainsKey("category_key"));
        Assert.Null(model.Conditions);
        Assert.False(model.RawData.ContainsKey("conditions"));
        Assert.Null(model.MaxItems);
        Assert.False(model.RawData.ContainsKey("max_items"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JourneyBatchNode
        {
            MaxWaitPeriod = "x",
            Retain = new()
            {
                Count = 0,
                Type = RetainType.First,
                SortKey = "x",
            },
            Scope = Scope.User,
            Type = JourneyBatchNodeType.Batch,
            WaitPeriod = "x",

            // Null should be interpreted as omitted for these properties
            ID = null,
            CategoryKey = null,
            Conditions = null,
            MaxItems = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneyBatchNode
        {
            MaxWaitPeriod = "x",
            Retain = new()
            {
                Count = 0,
                Type = RetainType.First,
                SortKey = "x",
            },
            Scope = Scope.User,
            Type = JourneyBatchNodeType.Batch,
            WaitPeriod = "x",
            ID = "x",
            CategoryKey = "x",
            Conditions = new(["string", "string"]),
            MaxItems = 1,
        };

        JourneyBatchNode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RetainTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Retain
        {
            Count = 0,
            Type = RetainType.First,
            SortKey = "x",
        };

        long expectedCount = 0;
        ApiEnum<string, RetainType> expectedType = RetainType.First;
        string expectedSortKey = "x";

        Assert.Equal(expectedCount, model.Count);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedSortKey, model.SortKey);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Retain
        {
            Count = 0,
            Type = RetainType.First,
            SortKey = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Retain>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Retain
        {
            Count = 0,
            Type = RetainType.First,
            SortKey = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Retain>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        long expectedCount = 0;
        ApiEnum<string, RetainType> expectedType = RetainType.First;
        string expectedSortKey = "x";

        Assert.Equal(expectedCount, deserialized.Count);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedSortKey, deserialized.SortKey);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Retain
        {
            Count = 0,
            Type = RetainType.First,
            SortKey = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Retain { Count = 0, Type = RetainType.First };

        Assert.Null(model.SortKey);
        Assert.False(model.RawData.ContainsKey("sort_key"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Retain { Count = 0, Type = RetainType.First };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Retain
        {
            Count = 0,
            Type = RetainType.First,

            // Null should be interpreted as omitted for these properties
            SortKey = null,
        };

        Assert.Null(model.SortKey);
        Assert.False(model.RawData.ContainsKey("sort_key"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Retain
        {
            Count = 0,
            Type = RetainType.First,

            // Null should be interpreted as omitted for these properties
            SortKey = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Retain
        {
            Count = 0,
            Type = RetainType.First,
            SortKey = "x",
        };

        Retain copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RetainTypeTest : TestBase
{
    [Theory]
    [InlineData(RetainType.First)]
    [InlineData(RetainType.Last)]
    [InlineData(RetainType.Highest)]
    [InlineData(RetainType.Lowest)]
    public void Validation_Works(RetainType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RetainType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RetainType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(RetainType.First)]
    [InlineData(RetainType.Last)]
    [InlineData(RetainType.Highest)]
    [InlineData(RetainType.Lowest)]
    public void SerializationRoundtrip_Works(RetainType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, RetainType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RetainType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, RetainType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, RetainType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ScopeTest : TestBase
{
    [Theory]
    [InlineData(Scope.User)]
    public void Validation_Works(Scope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Scope> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Scope>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Scope.User)]
    public void SerializationRoundtrip_Works(Scope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Scope> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Scope>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Scope>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Scope>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class JourneyBatchNodeTypeTest : TestBase
{
    [Theory]
    [InlineData(JourneyBatchNodeType.Batch)]
    public void Validation_Works(JourneyBatchNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyBatchNodeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyBatchNodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JourneyBatchNodeType.Batch)]
    public void SerializationRoundtrip_Works(JourneyBatchNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyBatchNodeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JourneyBatchNodeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyBatchNodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JourneyBatchNodeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class JourneyBranchNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyBranchNode
        {
            Default = new()
            {
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
                Label = "x",
            },
            Paths =
            [
                new()
                {
                    Conditions = new(["string", "string"]),
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
                    Label = "x",
                },
            ],
            Type = JourneyBranchNodeType.Branch,
            ID = "x",
        };

        Default expectedDefault = new()
        {
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
            Label = "x",
        };
        List<Path> expectedPaths =
        [
            new()
            {
                Conditions = new(["string", "string"]),
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
                Label = "x",
            },
        ];
        ApiEnum<string, JourneyBranchNodeType> expectedType = JourneyBranchNodeType.Branch;
        string expectedID = "x";

        Assert.Equal(expectedDefault, model.Default);
        Assert.Equal(expectedPaths.Count, model.Paths.Count);
        for (int i = 0; i < expectedPaths.Count; i++)
        {
            Assert.Equal(expectedPaths[i], model.Paths[i]);
        }
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneyBranchNode
        {
            Default = new()
            {
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
                Label = "x",
            },
            Paths =
            [
                new()
                {
                    Conditions = new(["string", "string"]),
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
                    Label = "x",
                },
            ],
            Type = JourneyBranchNodeType.Branch,
            ID = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyBranchNode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyBranchNode
        {
            Default = new()
            {
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
                Label = "x",
            },
            Paths =
            [
                new()
                {
                    Conditions = new(["string", "string"]),
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
                    Label = "x",
                },
            ],
            Type = JourneyBranchNodeType.Branch,
            ID = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyBranchNode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Default expectedDefault = new()
        {
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
            Label = "x",
        };
        List<Path> expectedPaths =
        [
            new()
            {
                Conditions = new(["string", "string"]),
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
                Label = "x",
            },
        ];
        ApiEnum<string, JourneyBranchNodeType> expectedType = JourneyBranchNodeType.Branch;
        string expectedID = "x";

        Assert.Equal(expectedDefault, deserialized.Default);
        Assert.Equal(expectedPaths.Count, deserialized.Paths.Count);
        for (int i = 0; i < expectedPaths.Count; i++)
        {
            Assert.Equal(expectedPaths[i], deserialized.Paths[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneyBranchNode
        {
            Default = new()
            {
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
                Label = "x",
            },
            Paths =
            [
                new()
                {
                    Conditions = new(["string", "string"]),
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
                    Label = "x",
                },
            ],
            Type = JourneyBranchNodeType.Branch,
            ID = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneyBranchNode
        {
            Default = new()
            {
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
                Label = "x",
            },
            Paths =
            [
                new()
                {
                    Conditions = new(["string", "string"]),
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
                    Label = "x",
                },
            ],
            Type = JourneyBranchNodeType.Branch,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneyBranchNode
        {
            Default = new()
            {
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
                Label = "x",
            },
            Paths =
            [
                new()
                {
                    Conditions = new(["string", "string"]),
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
                    Label = "x",
                },
            ],
            Type = JourneyBranchNodeType.Branch,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneyBranchNode
        {
            Default = new()
            {
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
                Label = "x",
            },
            Paths =
            [
                new()
                {
                    Conditions = new(["string", "string"]),
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
                    Label = "x",
                },
            ],
            Type = JourneyBranchNodeType.Branch,

            // Null should be interpreted as omitted for these properties
            ID = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JourneyBranchNode
        {
            Default = new()
            {
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
                Label = "x",
            },
            Paths =
            [
                new()
                {
                    Conditions = new(["string", "string"]),
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
                    Label = "x",
                },
            ],
            Type = JourneyBranchNodeType.Branch,

            // Null should be interpreted as omitted for these properties
            ID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneyBranchNode
        {
            Default = new()
            {
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
                Label = "x",
            },
            Paths =
            [
                new()
                {
                    Conditions = new(["string", "string"]),
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
                    Label = "x",
                },
            ],
            Type = JourneyBranchNodeType.Branch,
            ID = "x",
        };

        JourneyBranchNode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DefaultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Default
        {
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
            Label = "x",
        };

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
        string expectedLabel = "x";

        Assert.Equal(expectedNodes.Count, model.Nodes.Count);
        for (int i = 0; i < expectedNodes.Count; i++)
        {
            Assert.Equal(expectedNodes[i], model.Nodes[i]);
        }
        Assert.Equal(expectedLabel, model.Label);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Default
        {
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
            Label = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Default>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Default
        {
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
            Label = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Default>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

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
        string expectedLabel = "x";

        Assert.Equal(expectedNodes.Count, deserialized.Nodes.Count);
        for (int i = 0; i < expectedNodes.Count; i++)
        {
            Assert.Equal(expectedNodes[i], deserialized.Nodes[i]);
        }
        Assert.Equal(expectedLabel, deserialized.Label);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Default
        {
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
            Label = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Default
        {
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

        Assert.Null(model.Label);
        Assert.False(model.RawData.ContainsKey("label"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Default
        {
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Default
        {
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
            Label = null,
        };

        Assert.Null(model.Label);
        Assert.False(model.RawData.ContainsKey("label"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Default
        {
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
            Label = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Default
        {
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
            Label = "x",
        };

        Default copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PathTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Path
        {
            Conditions = new(["string", "string"]),
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
            Label = "x",
        };

        JourneyConditionsField expectedConditions = new(["string", "string"]);
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
        string expectedLabel = "x";

        Assert.Equal(expectedConditions, model.Conditions);
        Assert.Equal(expectedNodes.Count, model.Nodes.Count);
        for (int i = 0; i < expectedNodes.Count; i++)
        {
            Assert.Equal(expectedNodes[i], model.Nodes[i]);
        }
        Assert.Equal(expectedLabel, model.Label);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Path
        {
            Conditions = new(["string", "string"]),
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
            Label = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Path>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Path
        {
            Conditions = new(["string", "string"]),
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
            Label = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Path>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        JourneyConditionsField expectedConditions = new(["string", "string"]);
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
        string expectedLabel = "x";

        Assert.Equal(expectedConditions, deserialized.Conditions);
        Assert.Equal(expectedNodes.Count, deserialized.Nodes.Count);
        for (int i = 0; i < expectedNodes.Count; i++)
        {
            Assert.Equal(expectedNodes[i], deserialized.Nodes[i]);
        }
        Assert.Equal(expectedLabel, deserialized.Label);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Path
        {
            Conditions = new(["string", "string"]),
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
            Label = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Path
        {
            Conditions = new(["string", "string"]),
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

        Assert.Null(model.Label);
        Assert.False(model.RawData.ContainsKey("label"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Path
        {
            Conditions = new(["string", "string"]),
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Path
        {
            Conditions = new(["string", "string"]),
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
            Label = null,
        };

        Assert.Null(model.Label);
        Assert.False(model.RawData.ContainsKey("label"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Path
        {
            Conditions = new(["string", "string"]),
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
            Label = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Path
        {
            Conditions = new(["string", "string"]),
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
            Label = "x",
        };

        Path copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JourneyBranchNodeTypeTest : TestBase
{
    [Theory]
    [InlineData(JourneyBranchNodeType.Branch)]
    public void Validation_Works(JourneyBranchNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyBranchNodeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyBranchNodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JourneyBranchNodeType.Branch)]
    public void SerializationRoundtrip_Works(JourneyBranchNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyBranchNodeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JourneyBranchNodeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyBranchNodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JourneyBranchNodeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
