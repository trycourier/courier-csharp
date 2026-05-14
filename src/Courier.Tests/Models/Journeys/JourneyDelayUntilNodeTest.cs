using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Journeys;

namespace Courier.Tests.Models.Journeys;

public class JourneyDelayUntilNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyDelayUntilNode
        {
            Mode = JourneyDelayUntilNodeMode.Until,
            Type = JourneyDelayUntilNodeType.Delay,
            Until = "x",
            ID = "x",
            Conditions = new(["string", "string"]),
        };

        ApiEnum<string, JourneyDelayUntilNodeMode> expectedMode = JourneyDelayUntilNodeMode.Until;
        ApiEnum<string, JourneyDelayUntilNodeType> expectedType = JourneyDelayUntilNodeType.Delay;
        string expectedUntil = "x";
        string expectedID = "x";
        JourneyConditionsField expectedConditions = new(["string", "string"]);

        Assert.Equal(expectedMode, model.Mode);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUntil, model.Until);
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedConditions, model.Conditions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneyDelayUntilNode
        {
            Mode = JourneyDelayUntilNodeMode.Until,
            Type = JourneyDelayUntilNodeType.Delay,
            Until = "x",
            ID = "x",
            Conditions = new(["string", "string"]),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyDelayUntilNode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyDelayUntilNode
        {
            Mode = JourneyDelayUntilNodeMode.Until,
            Type = JourneyDelayUntilNodeType.Delay,
            Until = "x",
            ID = "x",
            Conditions = new(["string", "string"]),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyDelayUntilNode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, JourneyDelayUntilNodeMode> expectedMode = JourneyDelayUntilNodeMode.Until;
        ApiEnum<string, JourneyDelayUntilNodeType> expectedType = JourneyDelayUntilNodeType.Delay;
        string expectedUntil = "x";
        string expectedID = "x";
        JourneyConditionsField expectedConditions = new(["string", "string"]);

        Assert.Equal(expectedMode, deserialized.Mode);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUntil, deserialized.Until);
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedConditions, deserialized.Conditions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneyDelayUntilNode
        {
            Mode = JourneyDelayUntilNodeMode.Until,
            Type = JourneyDelayUntilNodeType.Delay,
            Until = "x",
            ID = "x",
            Conditions = new(["string", "string"]),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneyDelayUntilNode
        {
            Mode = JourneyDelayUntilNodeMode.Until,
            Type = JourneyDelayUntilNodeType.Delay,
            Until = "x",
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Conditions);
        Assert.False(model.RawData.ContainsKey("conditions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneyDelayUntilNode
        {
            Mode = JourneyDelayUntilNodeMode.Until,
            Type = JourneyDelayUntilNodeType.Delay,
            Until = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneyDelayUntilNode
        {
            Mode = JourneyDelayUntilNodeMode.Until,
            Type = JourneyDelayUntilNodeType.Delay,
            Until = "x",

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
        var model = new JourneyDelayUntilNode
        {
            Mode = JourneyDelayUntilNodeMode.Until,
            Type = JourneyDelayUntilNodeType.Delay,
            Until = "x",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Conditions = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneyDelayUntilNode
        {
            Mode = JourneyDelayUntilNodeMode.Until,
            Type = JourneyDelayUntilNodeType.Delay,
            Until = "x",
            ID = "x",
            Conditions = new(["string", "string"]),
        };

        JourneyDelayUntilNode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JourneyDelayUntilNodeModeTest : TestBase
{
    [Theory]
    [InlineData(JourneyDelayUntilNodeMode.Until)]
    public void Validation_Works(JourneyDelayUntilNodeMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyDelayUntilNodeMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyDelayUntilNodeMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JourneyDelayUntilNodeMode.Until)]
    public void SerializationRoundtrip_Works(JourneyDelayUntilNodeMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyDelayUntilNodeMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JourneyDelayUntilNodeMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyDelayUntilNodeMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JourneyDelayUntilNodeMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class JourneyDelayUntilNodeTypeTest : TestBase
{
    [Theory]
    [InlineData(JourneyDelayUntilNodeType.Delay)]
    public void Validation_Works(JourneyDelayUntilNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyDelayUntilNodeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyDelayUntilNodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JourneyDelayUntilNodeType.Delay)]
    public void SerializationRoundtrip_Works(JourneyDelayUntilNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyDelayUntilNodeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JourneyDelayUntilNodeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyDelayUntilNodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JourneyDelayUntilNodeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
