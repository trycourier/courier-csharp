using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Journeys;

namespace Courier.Tests.Models.Journeys;

public class JourneyApiInvokeTriggerNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyApiInvokeTriggerNode
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

        ApiEnum<string, TriggerType> expectedTriggerType = TriggerType.ApiInvoke;
        ApiEnum<string, JourneyApiInvokeTriggerNodeType> expectedType =
            JourneyApiInvokeTriggerNodeType.Trigger;
        string expectedID = "x";
        JourneyConditionsField expectedConditions = new(["string", "string"]);
        Dictionary<string, JsonElement> expectedSchema = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedTriggerType, model.TriggerType);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedConditions, model.Conditions);
        Assert.NotNull(model.Schema);
        Assert.Equal(expectedSchema.Count, model.Schema.Count);
        foreach (var item in expectedSchema)
        {
            Assert.True(model.Schema.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Schema[item.Key]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneyApiInvokeTriggerNode
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyApiInvokeTriggerNode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyApiInvokeTriggerNode
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyApiInvokeTriggerNode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, TriggerType> expectedTriggerType = TriggerType.ApiInvoke;
        ApiEnum<string, JourneyApiInvokeTriggerNodeType> expectedType =
            JourneyApiInvokeTriggerNodeType.Trigger;
        string expectedID = "x";
        JourneyConditionsField expectedConditions = new(["string", "string"]);
        Dictionary<string, JsonElement> expectedSchema = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedTriggerType, deserialized.TriggerType);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedConditions, deserialized.Conditions);
        Assert.NotNull(deserialized.Schema);
        Assert.Equal(expectedSchema.Count, deserialized.Schema.Count);
        foreach (var item in expectedSchema)
        {
            Assert.True(deserialized.Schema.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Schema[item.Key]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneyApiInvokeTriggerNode
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

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneyApiInvokeTriggerNode
        {
            TriggerType = TriggerType.ApiInvoke,
            Type = JourneyApiInvokeTriggerNodeType.Trigger,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Conditions);
        Assert.False(model.RawData.ContainsKey("conditions"));
        Assert.Null(model.Schema);
        Assert.False(model.RawData.ContainsKey("schema"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneyApiInvokeTriggerNode
        {
            TriggerType = TriggerType.ApiInvoke,
            Type = JourneyApiInvokeTriggerNodeType.Trigger,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneyApiInvokeTriggerNode
        {
            TriggerType = TriggerType.ApiInvoke,
            Type = JourneyApiInvokeTriggerNodeType.Trigger,

            // Null should be interpreted as omitted for these properties
            ID = null,
            Conditions = null,
            Schema = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Conditions);
        Assert.False(model.RawData.ContainsKey("conditions"));
        Assert.Null(model.Schema);
        Assert.False(model.RawData.ContainsKey("schema"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JourneyApiInvokeTriggerNode
        {
            TriggerType = TriggerType.ApiInvoke,
            Type = JourneyApiInvokeTriggerNodeType.Trigger,

            // Null should be interpreted as omitted for these properties
            ID = null,
            Conditions = null,
            Schema = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneyApiInvokeTriggerNode
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

        JourneyApiInvokeTriggerNode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TriggerTypeTest : TestBase
{
    [Theory]
    [InlineData(TriggerType.ApiInvoke)]
    public void Validation_Works(TriggerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TriggerType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TriggerType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TriggerType.ApiInvoke)]
    public void SerializationRoundtrip_Works(TriggerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TriggerType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TriggerType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TriggerType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TriggerType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class JourneyApiInvokeTriggerNodeTypeTest : TestBase
{
    [Theory]
    [InlineData(JourneyApiInvokeTriggerNodeType.Trigger)]
    public void Validation_Works(JourneyApiInvokeTriggerNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyApiInvokeTriggerNodeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyApiInvokeTriggerNodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JourneyApiInvokeTriggerNodeType.Trigger)]
    public void SerializationRoundtrip_Works(JourneyApiInvokeTriggerNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyApiInvokeTriggerNodeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyApiInvokeTriggerNodeType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyApiInvokeTriggerNodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyApiInvokeTriggerNodeType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
