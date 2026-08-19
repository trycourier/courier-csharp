using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneyWebhookTriggerNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyWebhookTriggerNode
        {
            EventSource = "event_source",
            TriggerType = JourneyWebhookTriggerNodeTriggerType.Webhook,
            Type = JourneyWebhookTriggerNodeType.Trigger,
            ID = "x",
            Conditions = new(["string", "string"]),
            EventID = "event_id",
        };

        string expectedEventSource = "event_source";
        ApiEnum<string, JourneyWebhookTriggerNodeTriggerType> expectedTriggerType =
            JourneyWebhookTriggerNodeTriggerType.Webhook;
        ApiEnum<string, JourneyWebhookTriggerNodeType> expectedType =
            JourneyWebhookTriggerNodeType.Trigger;
        string expectedID = "x";
        JourneyConditionsField expectedConditions = new(["string", "string"]);
        string expectedEventID = "event_id";

        Assert.Equal(expectedEventSource, model.EventSource);
        Assert.Equal(expectedTriggerType, model.TriggerType);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedConditions, model.Conditions);
        Assert.Equal(expectedEventID, model.EventID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneyWebhookTriggerNode
        {
            EventSource = "event_source",
            TriggerType = JourneyWebhookTriggerNodeTriggerType.Webhook,
            Type = JourneyWebhookTriggerNodeType.Trigger,
            ID = "x",
            Conditions = new(["string", "string"]),
            EventID = "event_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyWebhookTriggerNode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyWebhookTriggerNode
        {
            EventSource = "event_source",
            TriggerType = JourneyWebhookTriggerNodeTriggerType.Webhook,
            Type = JourneyWebhookTriggerNodeType.Trigger,
            ID = "x",
            Conditions = new(["string", "string"]),
            EventID = "event_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyWebhookTriggerNode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEventSource = "event_source";
        ApiEnum<string, JourneyWebhookTriggerNodeTriggerType> expectedTriggerType =
            JourneyWebhookTriggerNodeTriggerType.Webhook;
        ApiEnum<string, JourneyWebhookTriggerNodeType> expectedType =
            JourneyWebhookTriggerNodeType.Trigger;
        string expectedID = "x";
        JourneyConditionsField expectedConditions = new(["string", "string"]);
        string expectedEventID = "event_id";

        Assert.Equal(expectedEventSource, deserialized.EventSource);
        Assert.Equal(expectedTriggerType, deserialized.TriggerType);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedConditions, deserialized.Conditions);
        Assert.Equal(expectedEventID, deserialized.EventID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneyWebhookTriggerNode
        {
            EventSource = "event_source",
            TriggerType = JourneyWebhookTriggerNodeTriggerType.Webhook,
            Type = JourneyWebhookTriggerNodeType.Trigger,
            ID = "x",
            Conditions = new(["string", "string"]),
            EventID = "event_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneyWebhookTriggerNode
        {
            EventSource = "event_source",
            TriggerType = JourneyWebhookTriggerNodeTriggerType.Webhook,
            Type = JourneyWebhookTriggerNodeType.Trigger,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Conditions);
        Assert.False(model.RawData.ContainsKey("conditions"));
        Assert.Null(model.EventID);
        Assert.False(model.RawData.ContainsKey("event_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneyWebhookTriggerNode
        {
            EventSource = "event_source",
            TriggerType = JourneyWebhookTriggerNodeTriggerType.Webhook,
            Type = JourneyWebhookTriggerNodeType.Trigger,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneyWebhookTriggerNode
        {
            EventSource = "event_source",
            TriggerType = JourneyWebhookTriggerNodeTriggerType.Webhook,
            Type = JourneyWebhookTriggerNodeType.Trigger,

            // Null should be interpreted as omitted for these properties
            ID = null,
            Conditions = null,
            EventID = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Conditions);
        Assert.False(model.RawData.ContainsKey("conditions"));
        Assert.Null(model.EventID);
        Assert.False(model.RawData.ContainsKey("event_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JourneyWebhookTriggerNode
        {
            EventSource = "event_source",
            TriggerType = JourneyWebhookTriggerNodeTriggerType.Webhook,
            Type = JourneyWebhookTriggerNodeType.Trigger,

            // Null should be interpreted as omitted for these properties
            ID = null,
            Conditions = null,
            EventID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneyWebhookTriggerNode
        {
            EventSource = "event_source",
            TriggerType = JourneyWebhookTriggerNodeTriggerType.Webhook,
            Type = JourneyWebhookTriggerNodeType.Trigger,
            ID = "x",
            Conditions = new(["string", "string"]),
            EventID = "event_id",
        };

        JourneyWebhookTriggerNode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JourneyWebhookTriggerNodeTriggerTypeTest : TestBase
{
    [Theory]
    [InlineData(JourneyWebhookTriggerNodeTriggerType.Webhook)]
    public void Validation_Works(JourneyWebhookTriggerNodeTriggerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyWebhookTriggerNodeTriggerType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyWebhookTriggerNodeTriggerType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JourneyWebhookTriggerNodeTriggerType.Webhook)]
    public void SerializationRoundtrip_Works(JourneyWebhookTriggerNodeTriggerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyWebhookTriggerNodeTriggerType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyWebhookTriggerNodeTriggerType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyWebhookTriggerNodeTriggerType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyWebhookTriggerNodeTriggerType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class JourneyWebhookTriggerNodeTypeTest : TestBase
{
    [Theory]
    [InlineData(JourneyWebhookTriggerNodeType.Trigger)]
    public void Validation_Works(JourneyWebhookTriggerNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyWebhookTriggerNodeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyWebhookTriggerNodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JourneyWebhookTriggerNodeType.Trigger)]
    public void SerializationRoundtrip_Works(JourneyWebhookTriggerNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyWebhookTriggerNodeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyWebhookTriggerNodeType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyWebhookTriggerNodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyWebhookTriggerNodeType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
