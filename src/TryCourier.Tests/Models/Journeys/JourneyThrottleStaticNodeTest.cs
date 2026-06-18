using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneyThrottleStaticNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyThrottleStaticNode
        {
            MaxAllowed = 1,
            Period = "x",
            Scope = JourneyThrottleStaticNodeScope.User,
            Type = JourneyThrottleStaticNodeType.Throttle,
            ID = "x",
            Conditions = new(["string", "string"]),
        };

        long expectedMaxAllowed = 1;
        string expectedPeriod = "x";
        ApiEnum<string, JourneyThrottleStaticNodeScope> expectedScope =
            JourneyThrottleStaticNodeScope.User;
        ApiEnum<string, JourneyThrottleStaticNodeType> expectedType =
            JourneyThrottleStaticNodeType.Throttle;
        string expectedID = "x";
        JourneyConditionsField expectedConditions = new(["string", "string"]);

        Assert.Equal(expectedMaxAllowed, model.MaxAllowed);
        Assert.Equal(expectedPeriod, model.Period);
        Assert.Equal(expectedScope, model.Scope);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedConditions, model.Conditions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneyThrottleStaticNode
        {
            MaxAllowed = 1,
            Period = "x",
            Scope = JourneyThrottleStaticNodeScope.User,
            Type = JourneyThrottleStaticNodeType.Throttle,
            ID = "x",
            Conditions = new(["string", "string"]),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyThrottleStaticNode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyThrottleStaticNode
        {
            MaxAllowed = 1,
            Period = "x",
            Scope = JourneyThrottleStaticNodeScope.User,
            Type = JourneyThrottleStaticNodeType.Throttle,
            ID = "x",
            Conditions = new(["string", "string"]),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyThrottleStaticNode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedMaxAllowed = 1;
        string expectedPeriod = "x";
        ApiEnum<string, JourneyThrottleStaticNodeScope> expectedScope =
            JourneyThrottleStaticNodeScope.User;
        ApiEnum<string, JourneyThrottleStaticNodeType> expectedType =
            JourneyThrottleStaticNodeType.Throttle;
        string expectedID = "x";
        JourneyConditionsField expectedConditions = new(["string", "string"]);

        Assert.Equal(expectedMaxAllowed, deserialized.MaxAllowed);
        Assert.Equal(expectedPeriod, deserialized.Period);
        Assert.Equal(expectedScope, deserialized.Scope);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedConditions, deserialized.Conditions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneyThrottleStaticNode
        {
            MaxAllowed = 1,
            Period = "x",
            Scope = JourneyThrottleStaticNodeScope.User,
            Type = JourneyThrottleStaticNodeType.Throttle,
            ID = "x",
            Conditions = new(["string", "string"]),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneyThrottleStaticNode
        {
            MaxAllowed = 1,
            Period = "x",
            Scope = JourneyThrottleStaticNodeScope.User,
            Type = JourneyThrottleStaticNodeType.Throttle,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Conditions);
        Assert.False(model.RawData.ContainsKey("conditions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneyThrottleStaticNode
        {
            MaxAllowed = 1,
            Period = "x",
            Scope = JourneyThrottleStaticNodeScope.User,
            Type = JourneyThrottleStaticNodeType.Throttle,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneyThrottleStaticNode
        {
            MaxAllowed = 1,
            Period = "x",
            Scope = JourneyThrottleStaticNodeScope.User,
            Type = JourneyThrottleStaticNodeType.Throttle,

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
        var model = new JourneyThrottleStaticNode
        {
            MaxAllowed = 1,
            Period = "x",
            Scope = JourneyThrottleStaticNodeScope.User,
            Type = JourneyThrottleStaticNodeType.Throttle,

            // Null should be interpreted as omitted for these properties
            ID = null,
            Conditions = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneyThrottleStaticNode
        {
            MaxAllowed = 1,
            Period = "x",
            Scope = JourneyThrottleStaticNodeScope.User,
            Type = JourneyThrottleStaticNodeType.Throttle,
            ID = "x",
            Conditions = new(["string", "string"]),
        };

        JourneyThrottleStaticNode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JourneyThrottleStaticNodeScopeTest : TestBase
{
    [Theory]
    [InlineData(JourneyThrottleStaticNodeScope.User)]
    [InlineData(JourneyThrottleStaticNodeScope.Global)]
    public void Validation_Works(JourneyThrottleStaticNodeScope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyThrottleStaticNodeScope> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyThrottleStaticNodeScope>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JourneyThrottleStaticNodeScope.User)]
    [InlineData(JourneyThrottleStaticNodeScope.Global)]
    public void SerializationRoundtrip_Works(JourneyThrottleStaticNodeScope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyThrottleStaticNodeScope> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyThrottleStaticNodeScope>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyThrottleStaticNodeScope>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyThrottleStaticNodeScope>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class JourneyThrottleStaticNodeTypeTest : TestBase
{
    [Theory]
    [InlineData(JourneyThrottleStaticNodeType.Throttle)]
    public void Validation_Works(JourneyThrottleStaticNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyThrottleStaticNodeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyThrottleStaticNodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JourneyThrottleStaticNodeType.Throttle)]
    public void SerializationRoundtrip_Works(JourneyThrottleStaticNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyThrottleStaticNodeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyThrottleStaticNodeType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyThrottleStaticNodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyThrottleStaticNodeType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
