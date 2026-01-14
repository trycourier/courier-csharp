using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models;

namespace Courier.Tests.Models;

public class ElementalTextNodeWithTypeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalTextNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
        };

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        ApiEnum<string, ElementalTextNodeWithTypeIntersectionMember1Type> expectedType =
            ElementalTextNodeWithTypeIntersectionMember1Type.Text;

        Assert.NotNull(model.Channels);
        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], model.Channels[i]);
        }
        Assert.Equal(expectedIf, model.If);
        Assert.Equal(expectedLoop, model.Loop);
        Assert.Equal(expectedRef, model.Ref);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ElementalTextNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalTextNodeWithType>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ElementalTextNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalTextNodeWithType>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        ApiEnum<string, ElementalTextNodeWithTypeIntersectionMember1Type> expectedType =
            ElementalTextNodeWithTypeIntersectionMember1Type.Text;

        Assert.NotNull(deserialized.Channels);
        Assert.Equal(expectedChannels.Count, deserialized.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], deserialized.Channels[i]);
        }
        Assert.Equal(expectedIf, deserialized.If);
        Assert.Equal(expectedLoop, deserialized.Loop);
        Assert.Equal(expectedRef, deserialized.Ref);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ElementalTextNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalTextNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ElementalTextNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ElementalTextNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ElementalTextNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalTextNodeWithType
        {
            Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
        };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.If);
        Assert.False(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.False(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.False(model.RawData.ContainsKey("ref"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ElementalTextNodeWithType
        {
            Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ElementalTextNodeWithType
        {
            Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,

            Channels = null,
            If = null,
            Loop = null,
            Ref = null,
        };

        Assert.Null(model.Channels);
        Assert.True(model.RawData.ContainsKey("channels"));
        Assert.Null(model.If);
        Assert.True(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.True(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.True(model.RawData.ContainsKey("ref"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ElementalTextNodeWithType
        {
            Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,

            Channels = null,
            If = null,
            Loop = null,
            Ref = null,
        };

        model.Validate();
    }
}

public class ElementalTextNodeWithTypeIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalTextNodeWithTypeIntersectionMember1
        {
            Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
        };

        ApiEnum<string, ElementalTextNodeWithTypeIntersectionMember1Type> expectedType =
            ElementalTextNodeWithTypeIntersectionMember1Type.Text;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ElementalTextNodeWithTypeIntersectionMember1
        {
            Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalTextNodeWithTypeIntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ElementalTextNodeWithTypeIntersectionMember1
        {
            Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalTextNodeWithTypeIntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, ElementalTextNodeWithTypeIntersectionMember1Type> expectedType =
            ElementalTextNodeWithTypeIntersectionMember1Type.Text;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ElementalTextNodeWithTypeIntersectionMember1
        {
            Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalTextNodeWithTypeIntersectionMember1 { };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ElementalTextNodeWithTypeIntersectionMember1 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ElementalTextNodeWithTypeIntersectionMember1
        {
            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ElementalTextNodeWithTypeIntersectionMember1
        {
            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }
}

public class ElementalTextNodeWithTypeIntersectionMember1TypeTest : TestBase
{
    [Theory]
    [InlineData(ElementalTextNodeWithTypeIntersectionMember1Type.Text)]
    public void Validation_Works(ElementalTextNodeWithTypeIntersectionMember1Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ElementalTextNodeWithTypeIntersectionMember1Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ElementalTextNodeWithTypeIntersectionMember1Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ElementalTextNodeWithTypeIntersectionMember1Type.Text)]
    public void SerializationRoundtrip_Works(
        ElementalTextNodeWithTypeIntersectionMember1Type rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ElementalTextNodeWithTypeIntersectionMember1Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ElementalTextNodeWithTypeIntersectionMember1Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ElementalTextNodeWithTypeIntersectionMember1Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ElementalTextNodeWithTypeIntersectionMember1Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
