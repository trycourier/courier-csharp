using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneyThrottleDynamicNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyThrottleDynamicNode
        {
            MaxAllowed = 1,
            Period = "x",
            Scope = JourneyThrottleDynamicNodeScope.Dynamic,
            ThrottleKey = "x",
            Type = JourneyThrottleDynamicNodeType.Throttle,
            ID = "x",
            Conditions = new(["string", "string"]),
        };

        long expectedMaxAllowed = 1;
        string expectedPeriod = "x";
        ApiEnum<string, JourneyThrottleDynamicNodeScope> expectedScope =
            JourneyThrottleDynamicNodeScope.Dynamic;
        string expectedThrottleKey = "x";
        ApiEnum<string, JourneyThrottleDynamicNodeType> expectedType =
            JourneyThrottleDynamicNodeType.Throttle;
        string expectedID = "x";
        JourneyConditionsField expectedConditions = new(["string", "string"]);

        Assert.Equal(expectedMaxAllowed, model.MaxAllowed);
        Assert.Equal(expectedPeriod, model.Period);
        Assert.Equal(expectedScope, model.Scope);
        Assert.Equal(expectedThrottleKey, model.ThrottleKey);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedConditions, model.Conditions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneyThrottleDynamicNode
        {
            MaxAllowed = 1,
            Period = "x",
            Scope = JourneyThrottleDynamicNodeScope.Dynamic,
            ThrottleKey = "x",
            Type = JourneyThrottleDynamicNodeType.Throttle,
            ID = "x",
            Conditions = new(["string", "string"]),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyThrottleDynamicNode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyThrottleDynamicNode
        {
            MaxAllowed = 1,
            Period = "x",
            Scope = JourneyThrottleDynamicNodeScope.Dynamic,
            ThrottleKey = "x",
            Type = JourneyThrottleDynamicNodeType.Throttle,
            ID = "x",
            Conditions = new(["string", "string"]),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyThrottleDynamicNode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedMaxAllowed = 1;
        string expectedPeriod = "x";
        ApiEnum<string, JourneyThrottleDynamicNodeScope> expectedScope =
            JourneyThrottleDynamicNodeScope.Dynamic;
        string expectedThrottleKey = "x";
        ApiEnum<string, JourneyThrottleDynamicNodeType> expectedType =
            JourneyThrottleDynamicNodeType.Throttle;
        string expectedID = "x";
        JourneyConditionsField expectedConditions = new(["string", "string"]);

        Assert.Equal(expectedMaxAllowed, deserialized.MaxAllowed);
        Assert.Equal(expectedPeriod, deserialized.Period);
        Assert.Equal(expectedScope, deserialized.Scope);
        Assert.Equal(expectedThrottleKey, deserialized.ThrottleKey);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedConditions, deserialized.Conditions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneyThrottleDynamicNode
        {
            MaxAllowed = 1,
            Period = "x",
            Scope = JourneyThrottleDynamicNodeScope.Dynamic,
            ThrottleKey = "x",
            Type = JourneyThrottleDynamicNodeType.Throttle,
            ID = "x",
            Conditions = new(["string", "string"]),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneyThrottleDynamicNode
        {
            MaxAllowed = 1,
            Period = "x",
            Scope = JourneyThrottleDynamicNodeScope.Dynamic,
            ThrottleKey = "x",
            Type = JourneyThrottleDynamicNodeType.Throttle,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Conditions);
        Assert.False(model.RawData.ContainsKey("conditions"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneyThrottleDynamicNode
        {
            MaxAllowed = 1,
            Period = "x",
            Scope = JourneyThrottleDynamicNodeScope.Dynamic,
            ThrottleKey = "x",
            Type = JourneyThrottleDynamicNodeType.Throttle,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneyThrottleDynamicNode
        {
            MaxAllowed = 1,
            Period = "x",
            Scope = JourneyThrottleDynamicNodeScope.Dynamic,
            ThrottleKey = "x",
            Type = JourneyThrottleDynamicNodeType.Throttle,

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
        var model = new JourneyThrottleDynamicNode
        {
            MaxAllowed = 1,
            Period = "x",
            Scope = JourneyThrottleDynamicNodeScope.Dynamic,
            ThrottleKey = "x",
            Type = JourneyThrottleDynamicNodeType.Throttle,

            // Null should be interpreted as omitted for these properties
            ID = null,
            Conditions = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneyThrottleDynamicNode
        {
            MaxAllowed = 1,
            Period = "x",
            Scope = JourneyThrottleDynamicNodeScope.Dynamic,
            ThrottleKey = "x",
            Type = JourneyThrottleDynamicNodeType.Throttle,
            ID = "x",
            Conditions = new(["string", "string"]),
        };

        JourneyThrottleDynamicNode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JourneyThrottleDynamicNodeScopeTest : TestBase
{
    [Theory]
    [InlineData(JourneyThrottleDynamicNodeScope.Dynamic)]
    public void Validation_Works(JourneyThrottleDynamicNodeScope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyThrottleDynamicNodeScope> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyThrottleDynamicNodeScope>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JourneyThrottleDynamicNodeScope.Dynamic)]
    public void SerializationRoundtrip_Works(JourneyThrottleDynamicNodeScope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyThrottleDynamicNodeScope> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyThrottleDynamicNodeScope>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyThrottleDynamicNodeScope>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyThrottleDynamicNodeScope>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class JourneyThrottleDynamicNodeTypeTest : TestBase
{
    [Theory]
    [InlineData(JourneyThrottleDynamicNodeType.Throttle)]
    public void Validation_Works(JourneyThrottleDynamicNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyThrottleDynamicNodeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyThrottleDynamicNodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JourneyThrottleDynamicNodeType.Throttle)]
    public void SerializationRoundtrip_Works(JourneyThrottleDynamicNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyThrottleDynamicNodeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyThrottleDynamicNodeType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyThrottleDynamicNodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, JourneyThrottleDynamicNodeType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
