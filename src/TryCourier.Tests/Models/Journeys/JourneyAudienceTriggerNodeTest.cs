using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneyAudienceTriggerNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyAudienceTriggerNode
        {
            AudienceID = "x",
            TriggerType = JourneyAudienceTriggerNodeTriggerType.Audience,
            Type = JourneyAudienceTriggerNodeType.Trigger,
            ID = "x",
            Conditions = new(["string", "string"]),
        };

        string expectedAudienceID = "x";
        ApiEnum<string, JourneyAudienceTriggerNodeTriggerType> expectedTriggerType =
            JourneyAudienceTriggerNodeTriggerType.Audience;
        ApiEnum<string, JourneyAudienceTriggerNodeType> expectedType =
            JourneyAudienceTriggerNodeType.Trigger;
        string expectedID = "x";
        JourneyConditionsField expectedConditions = new(["string", "string"]);

        Assert.Equal(expectedAudienceID, model.AudienceID);
        Assert.Equal(expectedTriggerType, model.TriggerType);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedConditions, model.Conditions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneyAudienceTriggerNode
        {
            AudienceID = "x",
            TriggerType = JourneyAudienceTriggerNodeTriggerType.Audience,
            Type = JourneyAudienceTriggerNodeType.Trigger,
            ID = "x",
            Conditions = new(["string", "string"]),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyAudienceTriggerNode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyAudienceTriggerNode
        {
            AudienceID = "x",
            TriggerType = JourneyAudienceTriggerNodeTriggerType.Audience,
            Type = JourneyAudienceTriggerNodeType.Trigger,
            ID = "x",
            Conditions = new(["string", "string"]),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyAudienceTriggerNode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAudienceID = "x";
        ApiEnum<string, JourneyAudienceTriggerNodeTriggerType> expectedTriggerType =
            JourneyAudienceTriggerNodeTriggerType.Audience;
        ApiEnum<string, JourneyAudienceTriggerNodeType> expectedType =
            JourneyAudienceTriggerNodeType.Trigger;
        string expectedID = "x";
        JourneyConditionsField expectedConditions = new(["string", "string"]);

        Assert.Equal(expectedAudienceID, deserialized.AudienceID);
        Assert.Equal(expectedTriggerType, deserialized.TriggerType);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedConditions, deserialized.Conditions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneyAudienceTriggerNode
        {
            AudienceID = "x",
            TriggerType = JourneyAudienceTriggerNodeTriggerType.Audience,
            Type = JourneyAudienceTriggerNodeType.Trigger,
            ID = "x",
            Conditions = new(["string", "string"]),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneyAudienceTriggerNode
        {
            AudienceID = "x",
            TriggerType = JourneyAudienceTriggerNodeTriggerType.Audience,
            Type = JourneyAudienceTriggerNodeType.Trigger,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Conditions);
        Assert.False(model.RawData.ContainsKey("conditions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneyAudienceTriggerNode
        {
            AudienceID = "x",
            TriggerType = JourneyAudienceTriggerNodeTriggerType.Audience,
            Type = JourneyAudienceTriggerNodeType.Trigger,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneyAudienceTriggerNode
        {
            AudienceID = "x",
            TriggerType = JourneyAudienceTriggerNodeTriggerType.Audience,
            Type = JourneyAudienceTriggerNodeType.Trigger,

            // Null should be interpreted as omitted for these properties
            ID = null,
            Conditions = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Conditions);
        Assert.False(model.RawData.ContainsKey("conditions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JourneyAudienceTriggerNode
        {
            AudienceID = "x",
            TriggerType = JourneyAudienceTriggerNodeTriggerType.Audience,
            Type = JourneyAudienceTriggerNodeType.Trigger,

            // Null should be interpreted as omitted for these properties
            ID = null,
            Conditions = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneyAudienceTriggerNode
        {
            AudienceID = "x",
            TriggerType = JourneyAudienceTriggerNodeTriggerType.Audience,
            Type = JourneyAudienceTriggerNodeType.Trigger,
            ID = "x",
            Conditions = new(["string", "string"]),
        };

        JourneyAudienceTriggerNode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JourneyAudienceTriggerNodeTriggerTypeTest : TestBase
{
    [Theory]
    [InlineData(JourneyAudienceTriggerNodeTriggerType.Audience)]
    public void Validation_Works(JourneyAudienceTriggerNodeTriggerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyAudienceTriggerNodeTriggerType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyAudienceTriggerNodeTriggerType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JourneyAudienceTriggerNodeTriggerType.Audience)]
    public void SerializationRoundtrip_Works(JourneyAudienceTriggerNodeTriggerType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyAudienceTriggerNodeTriggerType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyAudienceTriggerNodeTriggerType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyAudienceTriggerNodeTriggerType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyAudienceTriggerNodeTriggerType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class JourneyAudienceTriggerNodeTypeTest : TestBase
{
    [Theory]
    [InlineData(JourneyAudienceTriggerNodeType.Trigger)]
    public void Validation_Works(JourneyAudienceTriggerNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyAudienceTriggerNodeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyAudienceTriggerNodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JourneyAudienceTriggerNodeType.Trigger)]
    public void SerializationRoundtrip_Works(JourneyAudienceTriggerNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyAudienceTriggerNodeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyAudienceTriggerNodeType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyAudienceTriggerNodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyAudienceTriggerNodeType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
