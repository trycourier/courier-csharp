using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models;

namespace TryCourier.Tests.Models;

public class ElementalImageNodeWithTypeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalImageNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Src = "src",
            Align = Alignment.Center,
            AltText = "alt_text",
            BorderColor = "border_color",
            BorderSize = "border_size",
            Href = "href",
            Padding = "padding",
            Width = "width",
            Type = ElementalImageNodeWithTypeIntersectionMember1Type.Image,
        };

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        string expectedSrc = "src";
        ApiEnum<string, Alignment> expectedAlign = Alignment.Center;
        string expectedAltText = "alt_text";
        string expectedBorderColor = "border_color";
        string expectedBorderSize = "border_size";
        string expectedHref = "href";
        string expectedPadding = "padding";
        string expectedWidth = "width";
        ApiEnum<string, ElementalImageNodeWithTypeIntersectionMember1Type> expectedType =
            ElementalImageNodeWithTypeIntersectionMember1Type.Image;

        Assert.NotNull(model.Channels);
        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], model.Channels[i]);
        }
        Assert.Equal(expectedIf, model.If);
        Assert.Equal(expectedLoop, model.Loop);
        Assert.Equal(expectedRef, model.Ref);
        Assert.Equal(expectedSrc, model.Src);
        Assert.Equal(expectedAlign, model.Align);
        Assert.Equal(expectedAltText, model.AltText);
        Assert.Equal(expectedBorderColor, model.BorderColor);
        Assert.Equal(expectedBorderSize, model.BorderSize);
        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedPadding, model.Padding);
        Assert.Equal(expectedWidth, model.Width);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ElementalImageNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Src = "src",
            Align = Alignment.Center,
            AltText = "alt_text",
            BorderColor = "border_color",
            BorderSize = "border_size",
            Href = "href",
            Padding = "padding",
            Width = "width",
            Type = ElementalImageNodeWithTypeIntersectionMember1Type.Image,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalImageNodeWithType>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ElementalImageNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Src = "src",
            Align = Alignment.Center,
            AltText = "alt_text",
            BorderColor = "border_color",
            BorderSize = "border_size",
            Href = "href",
            Padding = "padding",
            Width = "width",
            Type = ElementalImageNodeWithTypeIntersectionMember1Type.Image,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalImageNodeWithType>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        string expectedSrc = "src";
        ApiEnum<string, Alignment> expectedAlign = Alignment.Center;
        string expectedAltText = "alt_text";
        string expectedBorderColor = "border_color";
        string expectedBorderSize = "border_size";
        string expectedHref = "href";
        string expectedPadding = "padding";
        string expectedWidth = "width";
        ApiEnum<string, ElementalImageNodeWithTypeIntersectionMember1Type> expectedType =
            ElementalImageNodeWithTypeIntersectionMember1Type.Image;

        Assert.NotNull(deserialized.Channels);
        Assert.Equal(expectedChannels.Count, deserialized.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], deserialized.Channels[i]);
        }
        Assert.Equal(expectedIf, deserialized.If);
        Assert.Equal(expectedLoop, deserialized.Loop);
        Assert.Equal(expectedRef, deserialized.Ref);
        Assert.Equal(expectedSrc, deserialized.Src);
        Assert.Equal(expectedAlign, deserialized.Align);
        Assert.Equal(expectedAltText, deserialized.AltText);
        Assert.Equal(expectedBorderColor, deserialized.BorderColor);
        Assert.Equal(expectedBorderSize, deserialized.BorderSize);
        Assert.Equal(expectedHref, deserialized.Href);
        Assert.Equal(expectedPadding, deserialized.Padding);
        Assert.Equal(expectedWidth, deserialized.Width);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ElementalImageNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Src = "src",
            Align = Alignment.Center,
            AltText = "alt_text",
            BorderColor = "border_color",
            BorderSize = "border_size",
            Href = "href",
            Padding = "padding",
            Width = "width",
            Type = ElementalImageNodeWithTypeIntersectionMember1Type.Image,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalImageNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Src = "src",
            AltText = "alt_text",
            BorderColor = "border_color",
            BorderSize = "border_size",
            Href = "href",
            Padding = "padding",
            Width = "width",
        };

        Assert.Null(model.Align);
        Assert.False(model.RawData.ContainsKey("align"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ElementalImageNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Src = "src",
            AltText = "alt_text",
            BorderColor = "border_color",
            BorderSize = "border_size",
            Href = "href",
            Padding = "padding",
            Width = "width",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ElementalImageNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Src = "src",
            AltText = "alt_text",
            BorderColor = "border_color",
            BorderSize = "border_size",
            Href = "href",
            Padding = "padding",
            Width = "width",

            // Null should be interpreted as omitted for these properties
            Align = null,
            Type = null,
        };

        Assert.Null(model.Align);
        Assert.False(model.RawData.ContainsKey("align"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ElementalImageNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Src = "src",
            AltText = "alt_text",
            BorderColor = "border_color",
            BorderSize = "border_size",
            Href = "href",
            Padding = "padding",
            Width = "width",

            // Null should be interpreted as omitted for these properties
            Align = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalImageNodeWithType
        {
            Src = "src",
            Align = Alignment.Center,
            Type = ElementalImageNodeWithTypeIntersectionMember1Type.Image,
        };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.If);
        Assert.False(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.False(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.False(model.RawData.ContainsKey("ref"));
        Assert.Null(model.AltText);
        Assert.False(model.RawData.ContainsKey("alt_text"));
        Assert.Null(model.BorderColor);
        Assert.False(model.RawData.ContainsKey("border_color"));
        Assert.Null(model.BorderSize);
        Assert.False(model.RawData.ContainsKey("border_size"));
        Assert.Null(model.Href);
        Assert.False(model.RawData.ContainsKey("href"));
        Assert.Null(model.Padding);
        Assert.False(model.RawData.ContainsKey("padding"));
        Assert.Null(model.Width);
        Assert.False(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ElementalImageNodeWithType
        {
            Src = "src",
            Align = Alignment.Center,
            Type = ElementalImageNodeWithTypeIntersectionMember1Type.Image,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ElementalImageNodeWithType
        {
            Src = "src",
            Align = Alignment.Center,
            Type = ElementalImageNodeWithTypeIntersectionMember1Type.Image,

            Channels = null,
            If = null,
            Loop = null,
            Ref = null,
            AltText = null,
            BorderColor = null,
            BorderSize = null,
            Href = null,
            Padding = null,
            Width = null,
        };

        Assert.Null(model.Channels);
        Assert.True(model.RawData.ContainsKey("channels"));
        Assert.Null(model.If);
        Assert.True(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.True(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.True(model.RawData.ContainsKey("ref"));
        Assert.Null(model.AltText);
        Assert.True(model.RawData.ContainsKey("alt_text"));
        Assert.Null(model.BorderColor);
        Assert.True(model.RawData.ContainsKey("border_color"));
        Assert.Null(model.BorderSize);
        Assert.True(model.RawData.ContainsKey("border_size"));
        Assert.Null(model.Href);
        Assert.True(model.RawData.ContainsKey("href"));
        Assert.Null(model.Padding);
        Assert.True(model.RawData.ContainsKey("padding"));
        Assert.Null(model.Width);
        Assert.True(model.RawData.ContainsKey("width"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ElementalImageNodeWithType
        {
            Src = "src",
            Align = Alignment.Center,
            Type = ElementalImageNodeWithTypeIntersectionMember1Type.Image,

            Channels = null,
            If = null,
            Loop = null,
            Ref = null,
            AltText = null,
            BorderColor = null,
            BorderSize = null,
            Href = null,
            Padding = null,
            Width = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ElementalImageNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Src = "src",
            Align = Alignment.Center,
            AltText = "alt_text",
            BorderColor = "border_color",
            BorderSize = "border_size",
            Href = "href",
            Padding = "padding",
            Width = "width",
            Type = ElementalImageNodeWithTypeIntersectionMember1Type.Image,
        };

        ElementalImageNodeWithType copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ElementalImageNodeWithTypeIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalImageNodeWithTypeIntersectionMember1
        {
            Type = ElementalImageNodeWithTypeIntersectionMember1Type.Image,
        };

        ApiEnum<string, ElementalImageNodeWithTypeIntersectionMember1Type> expectedType =
            ElementalImageNodeWithTypeIntersectionMember1Type.Image;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ElementalImageNodeWithTypeIntersectionMember1
        {
            Type = ElementalImageNodeWithTypeIntersectionMember1Type.Image,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ElementalImageNodeWithTypeIntersectionMember1>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ElementalImageNodeWithTypeIntersectionMember1
        {
            Type = ElementalImageNodeWithTypeIntersectionMember1Type.Image,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ElementalImageNodeWithTypeIntersectionMember1>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<string, ElementalImageNodeWithTypeIntersectionMember1Type> expectedType =
            ElementalImageNodeWithTypeIntersectionMember1Type.Image;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ElementalImageNodeWithTypeIntersectionMember1
        {
            Type = ElementalImageNodeWithTypeIntersectionMember1Type.Image,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalImageNodeWithTypeIntersectionMember1 { };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ElementalImageNodeWithTypeIntersectionMember1 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ElementalImageNodeWithTypeIntersectionMember1
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
        var model = new ElementalImageNodeWithTypeIntersectionMember1
        {
            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ElementalImageNodeWithTypeIntersectionMember1
        {
            Type = ElementalImageNodeWithTypeIntersectionMember1Type.Image,
        };

        ElementalImageNodeWithTypeIntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ElementalImageNodeWithTypeIntersectionMember1TypeTest : TestBase
{
    [Theory]
    [InlineData(ElementalImageNodeWithTypeIntersectionMember1Type.Image)]
    public void Validation_Works(ElementalImageNodeWithTypeIntersectionMember1Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ElementalImageNodeWithTypeIntersectionMember1Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ElementalImageNodeWithTypeIntersectionMember1Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ElementalImageNodeWithTypeIntersectionMember1Type.Image)]
    public void SerializationRoundtrip_Works(
        ElementalImageNodeWithTypeIntersectionMember1Type rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ElementalImageNodeWithTypeIntersectionMember1Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ElementalImageNodeWithTypeIntersectionMember1Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ElementalImageNodeWithTypeIntersectionMember1Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ElementalImageNodeWithTypeIntersectionMember1Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
