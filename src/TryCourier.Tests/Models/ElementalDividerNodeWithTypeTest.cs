using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models;

namespace TryCourier.Tests.Models;

public class ElementalDividerNodeWithTypeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalDividerNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Color = "color",
            Type = ElementalDividerNodeWithTypeIntersectionMember1Type.Divider,
        };

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        string expectedColor = "color";
        ApiEnum<string, ElementalDividerNodeWithTypeIntersectionMember1Type> expectedType =
            ElementalDividerNodeWithTypeIntersectionMember1Type.Divider;

        Assert.NotNull(model.Channels);
        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], model.Channels[i]);
        }
        Assert.Equal(expectedIf, model.If);
        Assert.Equal(expectedLoop, model.Loop);
        Assert.Equal(expectedRef, model.Ref);
        Assert.Equal(expectedColor, model.Color);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ElementalDividerNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Color = "color",
            Type = ElementalDividerNodeWithTypeIntersectionMember1Type.Divider,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalDividerNodeWithType>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ElementalDividerNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Color = "color",
            Type = ElementalDividerNodeWithTypeIntersectionMember1Type.Divider,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalDividerNodeWithType>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        string expectedColor = "color";
        ApiEnum<string, ElementalDividerNodeWithTypeIntersectionMember1Type> expectedType =
            ElementalDividerNodeWithTypeIntersectionMember1Type.Divider;

        Assert.NotNull(deserialized.Channels);
        Assert.Equal(expectedChannels.Count, deserialized.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], deserialized.Channels[i]);
        }
        Assert.Equal(expectedIf, deserialized.If);
        Assert.Equal(expectedLoop, deserialized.Loop);
        Assert.Equal(expectedRef, deserialized.Ref);
        Assert.Equal(expectedColor, deserialized.Color);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ElementalDividerNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Color = "color",
            Type = ElementalDividerNodeWithTypeIntersectionMember1Type.Divider,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalDividerNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Color = "color",
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ElementalDividerNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Color = "color",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ElementalDividerNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Color = "color",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ElementalDividerNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Color = "color",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalDividerNodeWithType
        {
            Type = ElementalDividerNodeWithTypeIntersectionMember1Type.Divider,
        };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.If);
        Assert.False(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.False(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.False(model.RawData.ContainsKey("ref"));
        Assert.Null(model.Color);
        Assert.False(model.RawData.ContainsKey("color"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ElementalDividerNodeWithType
        {
            Type = ElementalDividerNodeWithTypeIntersectionMember1Type.Divider,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ElementalDividerNodeWithType
        {
            Type = ElementalDividerNodeWithTypeIntersectionMember1Type.Divider,

            Channels = null,
            If = null,
            Loop = null,
            Ref = null,
            Color = null,
        };

        Assert.Null(model.Channels);
        Assert.True(model.RawData.ContainsKey("channels"));
        Assert.Null(model.If);
        Assert.True(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.True(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.True(model.RawData.ContainsKey("ref"));
        Assert.Null(model.Color);
        Assert.True(model.RawData.ContainsKey("color"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ElementalDividerNodeWithType
        {
            Type = ElementalDividerNodeWithTypeIntersectionMember1Type.Divider,

            Channels = null,
            If = null,
            Loop = null,
            Ref = null,
            Color = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ElementalDividerNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Color = "color",
            Type = ElementalDividerNodeWithTypeIntersectionMember1Type.Divider,
        };

        ElementalDividerNodeWithType copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ElementalDividerNodeWithTypeIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalDividerNodeWithTypeIntersectionMember1
        {
            Type = ElementalDividerNodeWithTypeIntersectionMember1Type.Divider,
        };

        ApiEnum<string, ElementalDividerNodeWithTypeIntersectionMember1Type> expectedType =
            ElementalDividerNodeWithTypeIntersectionMember1Type.Divider;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ElementalDividerNodeWithTypeIntersectionMember1
        {
            Type = ElementalDividerNodeWithTypeIntersectionMember1Type.Divider,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ElementalDividerNodeWithTypeIntersectionMember1>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ElementalDividerNodeWithTypeIntersectionMember1
        {
            Type = ElementalDividerNodeWithTypeIntersectionMember1Type.Divider,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ElementalDividerNodeWithTypeIntersectionMember1>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<string, ElementalDividerNodeWithTypeIntersectionMember1Type> expectedType =
            ElementalDividerNodeWithTypeIntersectionMember1Type.Divider;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ElementalDividerNodeWithTypeIntersectionMember1
        {
            Type = ElementalDividerNodeWithTypeIntersectionMember1Type.Divider,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalDividerNodeWithTypeIntersectionMember1 { };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ElementalDividerNodeWithTypeIntersectionMember1 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ElementalDividerNodeWithTypeIntersectionMember1
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
        var model = new ElementalDividerNodeWithTypeIntersectionMember1
        {
            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ElementalDividerNodeWithTypeIntersectionMember1
        {
            Type = ElementalDividerNodeWithTypeIntersectionMember1Type.Divider,
        };

        ElementalDividerNodeWithTypeIntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ElementalDividerNodeWithTypeIntersectionMember1TypeTest : TestBase
{
    [Theory]
    [InlineData(ElementalDividerNodeWithTypeIntersectionMember1Type.Divider)]
    public void Validation_Works(ElementalDividerNodeWithTypeIntersectionMember1Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ElementalDividerNodeWithTypeIntersectionMember1Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ElementalDividerNodeWithTypeIntersectionMember1Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ElementalDividerNodeWithTypeIntersectionMember1Type.Divider)]
    public void SerializationRoundtrip_Works(
        ElementalDividerNodeWithTypeIntersectionMember1Type rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ElementalDividerNodeWithTypeIntersectionMember1Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ElementalDividerNodeWithTypeIntersectionMember1Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ElementalDividerNodeWithTypeIntersectionMember1Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ElementalDividerNodeWithTypeIntersectionMember1Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
