using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneyDelayDurationNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyDelayDurationNode
        {
            Duration = "x",
            Mode = Mode.Duration,
            Type = JourneyDelayDurationNodeType.Delay,
            ID = "x",
            Conditions = new(["string", "string"]),
        };

        string expectedDuration = "x";
        ApiEnum<string, Mode> expectedMode = Mode.Duration;
        ApiEnum<string, JourneyDelayDurationNodeType> expectedType =
            JourneyDelayDurationNodeType.Delay;
        string expectedID = "x";
        JourneyConditionsField expectedConditions = new(["string", "string"]);

        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedMode, model.Mode);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedConditions, model.Conditions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneyDelayDurationNode
        {
            Duration = "x",
            Mode = Mode.Duration,
            Type = JourneyDelayDurationNodeType.Delay,
            ID = "x",
            Conditions = new(["string", "string"]),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyDelayDurationNode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyDelayDurationNode
        {
            Duration = "x",
            Mode = Mode.Duration,
            Type = JourneyDelayDurationNodeType.Delay,
            ID = "x",
            Conditions = new(["string", "string"]),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyDelayDurationNode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDuration = "x";
        ApiEnum<string, Mode> expectedMode = Mode.Duration;
        ApiEnum<string, JourneyDelayDurationNodeType> expectedType =
            JourneyDelayDurationNodeType.Delay;
        string expectedID = "x";
        JourneyConditionsField expectedConditions = new(["string", "string"]);

        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedMode, deserialized.Mode);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedConditions, deserialized.Conditions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneyDelayDurationNode
        {
            Duration = "x",
            Mode = Mode.Duration,
            Type = JourneyDelayDurationNodeType.Delay,
            ID = "x",
            Conditions = new(["string", "string"]),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneyDelayDurationNode
        {
            Duration = "x",
            Mode = Mode.Duration,
            Type = JourneyDelayDurationNodeType.Delay,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Conditions);
        Assert.False(model.RawData.ContainsKey("conditions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneyDelayDurationNode
        {
            Duration = "x",
            Mode = Mode.Duration,
            Type = JourneyDelayDurationNodeType.Delay,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneyDelayDurationNode
        {
            Duration = "x",
            Mode = Mode.Duration,
            Type = JourneyDelayDurationNodeType.Delay,

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
        var model = new JourneyDelayDurationNode
        {
            Duration = "x",
            Mode = Mode.Duration,
            Type = JourneyDelayDurationNodeType.Delay,

            // Null should be interpreted as omitted for these properties
            ID = null,
            Conditions = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneyDelayDurationNode
        {
            Duration = "x",
            Mode = Mode.Duration,
            Type = JourneyDelayDurationNodeType.Delay,
            ID = "x",
            Conditions = new(["string", "string"]),
        };

        JourneyDelayDurationNode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ModeTest : TestBase
{
    [Theory]
    [InlineData(Mode.Duration)]
    public void Validation_Works(Mode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Mode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Mode.Duration)]
    public void SerializationRoundtrip_Works(Mode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Mode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Mode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class JourneyDelayDurationNodeTypeTest : TestBase
{
    [Theory]
    [InlineData(JourneyDelayDurationNodeType.Delay)]
    public void Validation_Works(JourneyDelayDurationNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyDelayDurationNodeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyDelayDurationNodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JourneyDelayDurationNodeType.Delay)]
    public void SerializationRoundtrip_Works(JourneyDelayDurationNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyDelayDurationNodeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyDelayDurationNodeType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyDelayDurationNodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyDelayDurationNodeType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
