using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneyExitNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneyExitNode { Type = JourneyExitNodeType.Exit, ID = "x" };

        ApiEnum<string, JourneyExitNodeType> expectedType = JourneyExitNodeType.Exit;
        string expectedID = "x";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneyExitNode { Type = JourneyExitNodeType.Exit, ID = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyExitNode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneyExitNode { Type = JourneyExitNodeType.Exit, ID = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneyExitNode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, JourneyExitNodeType> expectedType = JourneyExitNodeType.Exit;
        string expectedID = "x";

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneyExitNode { Type = JourneyExitNodeType.Exit, ID = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneyExitNode { Type = JourneyExitNodeType.Exit };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneyExitNode { Type = JourneyExitNodeType.Exit };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneyExitNode
        {
            Type = JourneyExitNodeType.Exit,

            // Null should be interpreted as omitted for these properties
            ID = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JourneyExitNode
        {
            Type = JourneyExitNodeType.Exit,

            // Null should be interpreted as omitted for these properties
            ID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneyExitNode { Type = JourneyExitNodeType.Exit, ID = "x" };

        JourneyExitNode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class JourneyExitNodeTypeTest : TestBase
{
    [Theory]
    [InlineData(JourneyExitNodeType.Exit)]
    public void Validation_Works(JourneyExitNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyExitNodeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyExitNodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(JourneyExitNodeType.Exit)]
    public void SerializationRoundtrip_Works(JourneyExitNodeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, JourneyExitNodeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JourneyExitNodeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, JourneyExitNodeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, JourneyExitNodeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
