using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models;

namespace TryCourier.Tests.Models;

public class ElementalNodeNonChannelTest : TestBase
{
    [Fact]
    public void UnionMember0ValidationWorks()
    {
        ElementalNodeNonChannel value = new UnionMember0()
        {
            Type = UnionMember0IntersectionMember1Type.Text,
        };
        value.Validate();
    }

    [Fact]
    public void UnionMember1ValidationWorks()
    {
        ElementalNodeNonChannel value = new UnionMember1()
        {
            Type = UnionMember1IntersectionMember1Type.Meta,
        };
        value.Validate();
    }

    [Fact]
    public void UnionMember2ValidationWorks()
    {
        ElementalNodeNonChannel value = new UnionMember2()
        {
            Type = UnionMember2IntersectionMember1Type.Image,
        };
        value.Validate();
    }

    [Fact]
    public void UnionMember3ValidationWorks()
    {
        ElementalNodeNonChannel value = new UnionMember3()
        {
            Type = UnionMember3IntersectionMember1Type.Action,
        };
        value.Validate();
    }

    [Fact]
    public void UnionMember4ValidationWorks()
    {
        ElementalNodeNonChannel value = new UnionMember4()
        {
            Type = UnionMember4IntersectionMember1Type.Divider,
        };
        value.Validate();
    }

    [Fact]
    public void UnionMember5ValidationWorks()
    {
        ElementalNodeNonChannel value = new UnionMember5()
        {
            Type = UnionMember5IntersectionMember1Type.Quote,
        };
        value.Validate();
    }

    [Fact]
    public void UnionMember6ValidationWorks()
    {
        ElementalNodeNonChannel value = new UnionMember6()
        {
            Type = UnionMember6IntersectionMember1Type.Html,
        };
        value.Validate();
    }

    [Fact]
    public void UnionMember0SerializationRoundtripWorks()
    {
        ElementalNodeNonChannel value = new UnionMember0()
        {
            Type = UnionMember0IntersectionMember1Type.Text,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalNodeNonChannel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnionMember1SerializationRoundtripWorks()
    {
        ElementalNodeNonChannel value = new UnionMember1()
        {
            Type = UnionMember1IntersectionMember1Type.Meta,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalNodeNonChannel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnionMember2SerializationRoundtripWorks()
    {
        ElementalNodeNonChannel value = new UnionMember2()
        {
            Type = UnionMember2IntersectionMember1Type.Image,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalNodeNonChannel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnionMember3SerializationRoundtripWorks()
    {
        ElementalNodeNonChannel value = new UnionMember3()
        {
            Type = UnionMember3IntersectionMember1Type.Action,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalNodeNonChannel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnionMember4SerializationRoundtripWorks()
    {
        ElementalNodeNonChannel value = new UnionMember4()
        {
            Type = UnionMember4IntersectionMember1Type.Divider,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalNodeNonChannel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnionMember5SerializationRoundtripWorks()
    {
        ElementalNodeNonChannel value = new UnionMember5()
        {
            Type = UnionMember5IntersectionMember1Type.Quote,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalNodeNonChannel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnionMember6SerializationRoundtripWorks()
    {
        ElementalNodeNonChannel value = new UnionMember6()
        {
            Type = UnionMember6IntersectionMember1Type.Html,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalNodeNonChannel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UnionMember0Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionMember0
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Align = Align.Left,
            Bold = "bold",
            Color = "color",
            Content = "content",
            FontSize = "font_size",
            Format = Format.Markdown,
            Italic = "italic",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Strikethrough = "strikethrough",
            TextStyle = TextStyle.Text,
            Underline = "underline",
            Type = UnionMember0IntersectionMember1Type.Text,
        };

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        ApiEnum<string, Align> expectedAlign = Align.Left;
        string expectedBold = "bold";
        string expectedColor = "color";
        string expectedContent = "content";
        string expectedFontSize = "font_size";
        ApiEnum<string, Format> expectedFormat = Format.Markdown;
        string expectedItalic = "italic";
        string expectedLineHeight = "line_height";
        Dictionary<string, LocalesItem> expectedLocales = new() { { "foo", new("content") } };
        string expectedStrikethrough = "strikethrough";
        ApiEnum<string, TextStyle> expectedTextStyle = TextStyle.Text;
        string expectedUnderline = "underline";
        ApiEnum<string, UnionMember0IntersectionMember1Type> expectedType =
            UnionMember0IntersectionMember1Type.Text;

        Assert.NotNull(model.Channels);
        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], model.Channels[i]);
        }
        Assert.Equal(expectedIf, model.If);
        Assert.Equal(expectedLoop, model.Loop);
        Assert.Equal(expectedRef, model.Ref);
        Assert.Equal(expectedAlign, model.Align);
        Assert.Equal(expectedBold, model.Bold);
        Assert.Equal(expectedColor, model.Color);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedFontSize, model.FontSize);
        Assert.Equal(expectedFormat, model.Format);
        Assert.Equal(expectedItalic, model.Italic);
        Assert.Equal(expectedLineHeight, model.LineHeight);
        Assert.NotNull(model.Locales);
        Assert.Equal(expectedLocales.Count, model.Locales.Count);
        foreach (var item in expectedLocales)
        {
            Assert.True(model.Locales.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Locales[item.Key]);
        }
        Assert.Equal(expectedStrikethrough, model.Strikethrough);
        Assert.Equal(expectedTextStyle, model.TextStyle);
        Assert.Equal(expectedUnderline, model.Underline);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnionMember0
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Align = Align.Left,
            Bold = "bold",
            Color = "color",
            Content = "content",
            FontSize = "font_size",
            Format = Format.Markdown,
            Italic = "italic",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Strikethrough = "strikethrough",
            TextStyle = TextStyle.Text,
            Underline = "underline",
            Type = UnionMember0IntersectionMember1Type.Text,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember0>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionMember0
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Align = Align.Left,
            Bold = "bold",
            Color = "color",
            Content = "content",
            FontSize = "font_size",
            Format = Format.Markdown,
            Italic = "italic",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Strikethrough = "strikethrough",
            TextStyle = TextStyle.Text,
            Underline = "underline",
            Type = UnionMember0IntersectionMember1Type.Text,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember0>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        ApiEnum<string, Align> expectedAlign = Align.Left;
        string expectedBold = "bold";
        string expectedColor = "color";
        string expectedContent = "content";
        string expectedFontSize = "font_size";
        ApiEnum<string, Format> expectedFormat = Format.Markdown;
        string expectedItalic = "italic";
        string expectedLineHeight = "line_height";
        Dictionary<string, LocalesItem> expectedLocales = new() { { "foo", new("content") } };
        string expectedStrikethrough = "strikethrough";
        ApiEnum<string, TextStyle> expectedTextStyle = TextStyle.Text;
        string expectedUnderline = "underline";
        ApiEnum<string, UnionMember0IntersectionMember1Type> expectedType =
            UnionMember0IntersectionMember1Type.Text;

        Assert.NotNull(deserialized.Channels);
        Assert.Equal(expectedChannels.Count, deserialized.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], deserialized.Channels[i]);
        }
        Assert.Equal(expectedIf, deserialized.If);
        Assert.Equal(expectedLoop, deserialized.Loop);
        Assert.Equal(expectedRef, deserialized.Ref);
        Assert.Equal(expectedAlign, deserialized.Align);
        Assert.Equal(expectedBold, deserialized.Bold);
        Assert.Equal(expectedColor, deserialized.Color);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedFontSize, deserialized.FontSize);
        Assert.Equal(expectedFormat, deserialized.Format);
        Assert.Equal(expectedItalic, deserialized.Italic);
        Assert.Equal(expectedLineHeight, deserialized.LineHeight);
        Assert.NotNull(deserialized.Locales);
        Assert.Equal(expectedLocales.Count, deserialized.Locales.Count);
        foreach (var item in expectedLocales)
        {
            Assert.True(deserialized.Locales.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Locales[item.Key]);
        }
        Assert.Equal(expectedStrikethrough, deserialized.Strikethrough);
        Assert.Equal(expectedTextStyle, deserialized.TextStyle);
        Assert.Equal(expectedUnderline, deserialized.Underline);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnionMember0
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Align = Align.Left,
            Bold = "bold",
            Color = "color",
            Content = "content",
            FontSize = "font_size",
            Format = Format.Markdown,
            Italic = "italic",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Strikethrough = "strikethrough",
            TextStyle = TextStyle.Text,
            Underline = "underline",
            Type = UnionMember0IntersectionMember1Type.Text,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember0
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Bold = "bold",
            Color = "color",
            FontSize = "font_size",
            Format = Format.Markdown,
            Italic = "italic",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Strikethrough = "strikethrough",
            Underline = "underline",
        };

        Assert.Null(model.Align);
        Assert.False(model.RawData.ContainsKey("align"));
        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.TextStyle);
        Assert.False(model.RawData.ContainsKey("text_style"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionMember0
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Bold = "bold",
            Color = "color",
            FontSize = "font_size",
            Format = Format.Markdown,
            Italic = "italic",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Strikethrough = "strikethrough",
            Underline = "underline",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnionMember0
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Bold = "bold",
            Color = "color",
            FontSize = "font_size",
            Format = Format.Markdown,
            Italic = "italic",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Strikethrough = "strikethrough",
            Underline = "underline",

            // Null should be interpreted as omitted for these properties
            Align = null,
            Content = null,
            TextStyle = null,
            Type = null,
        };

        Assert.Null(model.Align);
        Assert.False(model.RawData.ContainsKey("align"));
        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.TextStyle);
        Assert.False(model.RawData.ContainsKey("text_style"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UnionMember0
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Bold = "bold",
            Color = "color",
            FontSize = "font_size",
            Format = Format.Markdown,
            Italic = "italic",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Strikethrough = "strikethrough",
            Underline = "underline",

            // Null should be interpreted as omitted for these properties
            Align = null,
            Content = null,
            TextStyle = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember0
        {
            Align = Align.Left,
            Content = "content",
            TextStyle = TextStyle.Text,
            Type = UnionMember0IntersectionMember1Type.Text,
        };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.If);
        Assert.False(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.False(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.False(model.RawData.ContainsKey("ref"));
        Assert.Null(model.Bold);
        Assert.False(model.RawData.ContainsKey("bold"));
        Assert.Null(model.Color);
        Assert.False(model.RawData.ContainsKey("color"));
        Assert.Null(model.FontSize);
        Assert.False(model.RawData.ContainsKey("font_size"));
        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
        Assert.Null(model.Italic);
        Assert.False(model.RawData.ContainsKey("italic"));
        Assert.Null(model.LineHeight);
        Assert.False(model.RawData.ContainsKey("line_height"));
        Assert.Null(model.Locales);
        Assert.False(model.RawData.ContainsKey("locales"));
        Assert.Null(model.Strikethrough);
        Assert.False(model.RawData.ContainsKey("strikethrough"));
        Assert.Null(model.Underline);
        Assert.False(model.RawData.ContainsKey("underline"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionMember0
        {
            Align = Align.Left,
            Content = "content",
            TextStyle = TextStyle.Text,
            Type = UnionMember0IntersectionMember1Type.Text,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UnionMember0
        {
            Align = Align.Left,
            Content = "content",
            TextStyle = TextStyle.Text,
            Type = UnionMember0IntersectionMember1Type.Text,

            Channels = null,
            If = null,
            Loop = null,
            Ref = null,
            Bold = null,
            Color = null,
            FontSize = null,
            Format = null,
            Italic = null,
            LineHeight = null,
            Locales = null,
            Strikethrough = null,
            Underline = null,
        };

        Assert.Null(model.Channels);
        Assert.True(model.RawData.ContainsKey("channels"));
        Assert.Null(model.If);
        Assert.True(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.True(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.True(model.RawData.ContainsKey("ref"));
        Assert.Null(model.Bold);
        Assert.True(model.RawData.ContainsKey("bold"));
        Assert.Null(model.Color);
        Assert.True(model.RawData.ContainsKey("color"));
        Assert.Null(model.FontSize);
        Assert.True(model.RawData.ContainsKey("font_size"));
        Assert.Null(model.Format);
        Assert.True(model.RawData.ContainsKey("format"));
        Assert.Null(model.Italic);
        Assert.True(model.RawData.ContainsKey("italic"));
        Assert.Null(model.LineHeight);
        Assert.True(model.RawData.ContainsKey("line_height"));
        Assert.Null(model.Locales);
        Assert.True(model.RawData.ContainsKey("locales"));
        Assert.Null(model.Strikethrough);
        Assert.True(model.RawData.ContainsKey("strikethrough"));
        Assert.Null(model.Underline);
        Assert.True(model.RawData.ContainsKey("underline"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UnionMember0
        {
            Align = Align.Left,
            Content = "content",
            TextStyle = TextStyle.Text,
            Type = UnionMember0IntersectionMember1Type.Text,

            Channels = null,
            If = null,
            Loop = null,
            Ref = null,
            Bold = null,
            Color = null,
            FontSize = null,
            Format = null,
            Italic = null,
            LineHeight = null,
            Locales = null,
            Strikethrough = null,
            Underline = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnionMember0
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Align = Align.Left,
            Bold = "bold",
            Color = "color",
            Content = "content",
            FontSize = "font_size",
            Format = Format.Markdown,
            Italic = "italic",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Strikethrough = "strikethrough",
            TextStyle = TextStyle.Text,
            Underline = "underline",
            Type = UnionMember0IntersectionMember1Type.Text,
        };

        UnionMember0 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnionMember0IntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionMember0IntersectionMember1
        {
            Type = UnionMember0IntersectionMember1Type.Text,
        };

        ApiEnum<string, UnionMember0IntersectionMember1Type> expectedType =
            UnionMember0IntersectionMember1Type.Text;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnionMember0IntersectionMember1
        {
            Type = UnionMember0IntersectionMember1Type.Text,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember0IntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionMember0IntersectionMember1
        {
            Type = UnionMember0IntersectionMember1Type.Text,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember0IntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, UnionMember0IntersectionMember1Type> expectedType =
            UnionMember0IntersectionMember1Type.Text;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnionMember0IntersectionMember1
        {
            Type = UnionMember0IntersectionMember1Type.Text,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember0IntersectionMember1 { };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionMember0IntersectionMember1 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnionMember0IntersectionMember1
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
        var model = new UnionMember0IntersectionMember1
        {
            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnionMember0IntersectionMember1
        {
            Type = UnionMember0IntersectionMember1Type.Text,
        };

        UnionMember0IntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnionMember0IntersectionMember1TypeTest : TestBase
{
    [Theory]
    [InlineData(UnionMember0IntersectionMember1Type.Text)]
    public void Validation_Works(UnionMember0IntersectionMember1Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember0IntersectionMember1Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember0IntersectionMember1Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UnionMember0IntersectionMember1Type.Text)]
    public void SerializationRoundtrip_Works(UnionMember0IntersectionMember1Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember0IntersectionMember1Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember0IntersectionMember1Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember0IntersectionMember1Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember0IntersectionMember1Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UnionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionMember1
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Title = "title",
            Type = UnionMember1IntersectionMember1Type.Meta,
        };

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        string expectedTitle = "title";
        ApiEnum<string, UnionMember1IntersectionMember1Type> expectedType =
            UnionMember1IntersectionMember1Type.Meta;

        Assert.NotNull(model.Channels);
        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], model.Channels[i]);
        }
        Assert.Equal(expectedIf, model.If);
        Assert.Equal(expectedLoop, model.Loop);
        Assert.Equal(expectedRef, model.Ref);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnionMember1
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Title = "title",
            Type = UnionMember1IntersectionMember1Type.Meta,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionMember1
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Title = "title",
            Type = UnionMember1IntersectionMember1Type.Meta,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        string expectedTitle = "title";
        ApiEnum<string, UnionMember1IntersectionMember1Type> expectedType =
            UnionMember1IntersectionMember1Type.Meta;

        Assert.NotNull(deserialized.Channels);
        Assert.Equal(expectedChannels.Count, deserialized.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], deserialized.Channels[i]);
        }
        Assert.Equal(expectedIf, deserialized.If);
        Assert.Equal(expectedLoop, deserialized.Loop);
        Assert.Equal(expectedRef, deserialized.Ref);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnionMember1
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Title = "title",
            Type = UnionMember1IntersectionMember1Type.Meta,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember1
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Title = "title",
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionMember1
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Title = "title",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnionMember1
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Title = "title",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UnionMember1
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Title = "title",

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember1 { Type = UnionMember1IntersectionMember1Type.Meta };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.If);
        Assert.False(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.False(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.False(model.RawData.ContainsKey("ref"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionMember1 { Type = UnionMember1IntersectionMember1Type.Meta };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UnionMember1
        {
            Type = UnionMember1IntersectionMember1Type.Meta,

            Channels = null,
            If = null,
            Loop = null,
            Ref = null,
            Title = null,
        };

        Assert.Null(model.Channels);
        Assert.True(model.RawData.ContainsKey("channels"));
        Assert.Null(model.If);
        Assert.True(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.True(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.True(model.RawData.ContainsKey("ref"));
        Assert.Null(model.Title);
        Assert.True(model.RawData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UnionMember1
        {
            Type = UnionMember1IntersectionMember1Type.Meta,

            Channels = null,
            If = null,
            Loop = null,
            Ref = null,
            Title = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnionMember1
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Title = "title",
            Type = UnionMember1IntersectionMember1Type.Meta,
        };

        UnionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnionMember1IntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionMember1IntersectionMember1
        {
            Type = UnionMember1IntersectionMember1Type.Meta,
        };

        ApiEnum<string, UnionMember1IntersectionMember1Type> expectedType =
            UnionMember1IntersectionMember1Type.Meta;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnionMember1IntersectionMember1
        {
            Type = UnionMember1IntersectionMember1Type.Meta,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember1IntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionMember1IntersectionMember1
        {
            Type = UnionMember1IntersectionMember1Type.Meta,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember1IntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, UnionMember1IntersectionMember1Type> expectedType =
            UnionMember1IntersectionMember1Type.Meta;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnionMember1IntersectionMember1
        {
            Type = UnionMember1IntersectionMember1Type.Meta,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember1IntersectionMember1 { };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionMember1IntersectionMember1 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnionMember1IntersectionMember1
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
        var model = new UnionMember1IntersectionMember1
        {
            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnionMember1IntersectionMember1
        {
            Type = UnionMember1IntersectionMember1Type.Meta,
        };

        UnionMember1IntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnionMember1IntersectionMember1TypeTest : TestBase
{
    [Theory]
    [InlineData(UnionMember1IntersectionMember1Type.Meta)]
    public void Validation_Works(UnionMember1IntersectionMember1Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember1IntersectionMember1Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember1IntersectionMember1Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UnionMember1IntersectionMember1Type.Meta)]
    public void SerializationRoundtrip_Works(UnionMember1IntersectionMember1Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember1IntersectionMember1Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember1IntersectionMember1Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember1IntersectionMember1Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember1IntersectionMember1Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UnionMember2Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionMember2
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
            Type = UnionMember2IntersectionMember1Type.Image,
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
        ApiEnum<string, UnionMember2IntersectionMember1Type> expectedType =
            UnionMember2IntersectionMember1Type.Image;

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
        var model = new UnionMember2
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
            Type = UnionMember2IntersectionMember1Type.Image,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember2>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionMember2
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
            Type = UnionMember2IntersectionMember1Type.Image,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember2>(
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
        ApiEnum<string, UnionMember2IntersectionMember1Type> expectedType =
            UnionMember2IntersectionMember1Type.Image;

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
        var model = new UnionMember2
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
            Type = UnionMember2IntersectionMember1Type.Image,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember2
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
        var model = new UnionMember2
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
        var model = new UnionMember2
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
        var model = new UnionMember2
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
        var model = new UnionMember2
        {
            Src = "src",
            Align = Alignment.Center,
            Type = UnionMember2IntersectionMember1Type.Image,
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
        var model = new UnionMember2
        {
            Src = "src",
            Align = Alignment.Center,
            Type = UnionMember2IntersectionMember1Type.Image,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UnionMember2
        {
            Src = "src",
            Align = Alignment.Center,
            Type = UnionMember2IntersectionMember1Type.Image,

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
        var model = new UnionMember2
        {
            Src = "src",
            Align = Alignment.Center,
            Type = UnionMember2IntersectionMember1Type.Image,

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
        var model = new UnionMember2
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
            Type = UnionMember2IntersectionMember1Type.Image,
        };

        UnionMember2 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnionMember2IntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionMember2IntersectionMember1
        {
            Type = UnionMember2IntersectionMember1Type.Image,
        };

        ApiEnum<string, UnionMember2IntersectionMember1Type> expectedType =
            UnionMember2IntersectionMember1Type.Image;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnionMember2IntersectionMember1
        {
            Type = UnionMember2IntersectionMember1Type.Image,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember2IntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionMember2IntersectionMember1
        {
            Type = UnionMember2IntersectionMember1Type.Image,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember2IntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, UnionMember2IntersectionMember1Type> expectedType =
            UnionMember2IntersectionMember1Type.Image;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnionMember2IntersectionMember1
        {
            Type = UnionMember2IntersectionMember1Type.Image,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember2IntersectionMember1 { };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionMember2IntersectionMember1 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnionMember2IntersectionMember1
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
        var model = new UnionMember2IntersectionMember1
        {
            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnionMember2IntersectionMember1
        {
            Type = UnionMember2IntersectionMember1Type.Image,
        };

        UnionMember2IntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnionMember2IntersectionMember1TypeTest : TestBase
{
    [Theory]
    [InlineData(UnionMember2IntersectionMember1Type.Image)]
    public void Validation_Works(UnionMember2IntersectionMember1Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember2IntersectionMember1Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember2IntersectionMember1Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UnionMember2IntersectionMember1Type.Image)]
    public void SerializationRoundtrip_Works(UnionMember2IntersectionMember1Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember2IntersectionMember1Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember2IntersectionMember1Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember2IntersectionMember1Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember2IntersectionMember1Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UnionMember3Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionMember3
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Href = "href",
            ActionID = "action_id",
            Align = Alignment.Center,
            BackgroundColor = "background_color",
            BorderRadius = "border_radius",
            BorderSize = "border_size",
            DisableTracking = true,
            FontSize = "font_size",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Padding = "padding",
            Style = Style.Button,
            Type = UnionMember3IntersectionMember1Type.Action,
        };

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        string expectedContent = "content";
        string expectedHref = "href";
        string expectedActionID = "action_id";
        ApiEnum<string, Alignment> expectedAlign = Alignment.Center;
        string expectedBackgroundColor = "background_color";
        string expectedBorderRadius = "border_radius";
        string expectedBorderSize = "border_size";
        bool expectedDisableTracking = true;
        string expectedFontSize = "font_size";
        Dictionary<string, LocalesItem> expectedLocales = new() { { "foo", new("content") } };
        string expectedPadding = "padding";
        ApiEnum<string, Style> expectedStyle = Style.Button;
        ApiEnum<string, UnionMember3IntersectionMember1Type> expectedType =
            UnionMember3IntersectionMember1Type.Action;

        Assert.NotNull(model.Channels);
        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], model.Channels[i]);
        }
        Assert.Equal(expectedIf, model.If);
        Assert.Equal(expectedLoop, model.Loop);
        Assert.Equal(expectedRef, model.Ref);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedHref, model.Href);
        Assert.Equal(expectedActionID, model.ActionID);
        Assert.Equal(expectedAlign, model.Align);
        Assert.Equal(expectedBackgroundColor, model.BackgroundColor);
        Assert.Equal(expectedBorderRadius, model.BorderRadius);
        Assert.Equal(expectedBorderSize, model.BorderSize);
        Assert.Equal(expectedDisableTracking, model.DisableTracking);
        Assert.Equal(expectedFontSize, model.FontSize);
        Assert.NotNull(model.Locales);
        Assert.Equal(expectedLocales.Count, model.Locales.Count);
        foreach (var item in expectedLocales)
        {
            Assert.True(model.Locales.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Locales[item.Key]);
        }
        Assert.Equal(expectedPadding, model.Padding);
        Assert.Equal(expectedStyle, model.Style);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnionMember3
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Href = "href",
            ActionID = "action_id",
            Align = Alignment.Center,
            BackgroundColor = "background_color",
            BorderRadius = "border_radius",
            BorderSize = "border_size",
            DisableTracking = true,
            FontSize = "font_size",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Padding = "padding",
            Style = Style.Button,
            Type = UnionMember3IntersectionMember1Type.Action,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember3>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionMember3
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Href = "href",
            ActionID = "action_id",
            Align = Alignment.Center,
            BackgroundColor = "background_color",
            BorderRadius = "border_radius",
            BorderSize = "border_size",
            DisableTracking = true,
            FontSize = "font_size",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Padding = "padding",
            Style = Style.Button,
            Type = UnionMember3IntersectionMember1Type.Action,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember3>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        string expectedContent = "content";
        string expectedHref = "href";
        string expectedActionID = "action_id";
        ApiEnum<string, Alignment> expectedAlign = Alignment.Center;
        string expectedBackgroundColor = "background_color";
        string expectedBorderRadius = "border_radius";
        string expectedBorderSize = "border_size";
        bool expectedDisableTracking = true;
        string expectedFontSize = "font_size";
        Dictionary<string, LocalesItem> expectedLocales = new() { { "foo", new("content") } };
        string expectedPadding = "padding";
        ApiEnum<string, Style> expectedStyle = Style.Button;
        ApiEnum<string, UnionMember3IntersectionMember1Type> expectedType =
            UnionMember3IntersectionMember1Type.Action;

        Assert.NotNull(deserialized.Channels);
        Assert.Equal(expectedChannels.Count, deserialized.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], deserialized.Channels[i]);
        }
        Assert.Equal(expectedIf, deserialized.If);
        Assert.Equal(expectedLoop, deserialized.Loop);
        Assert.Equal(expectedRef, deserialized.Ref);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedHref, deserialized.Href);
        Assert.Equal(expectedActionID, deserialized.ActionID);
        Assert.Equal(expectedAlign, deserialized.Align);
        Assert.Equal(expectedBackgroundColor, deserialized.BackgroundColor);
        Assert.Equal(expectedBorderRadius, deserialized.BorderRadius);
        Assert.Equal(expectedBorderSize, deserialized.BorderSize);
        Assert.Equal(expectedDisableTracking, deserialized.DisableTracking);
        Assert.Equal(expectedFontSize, deserialized.FontSize);
        Assert.NotNull(deserialized.Locales);
        Assert.Equal(expectedLocales.Count, deserialized.Locales.Count);
        foreach (var item in expectedLocales)
        {
            Assert.True(deserialized.Locales.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Locales[item.Key]);
        }
        Assert.Equal(expectedPadding, deserialized.Padding);
        Assert.Equal(expectedStyle, deserialized.Style);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnionMember3
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Href = "href",
            ActionID = "action_id",
            Align = Alignment.Center,
            BackgroundColor = "background_color",
            BorderRadius = "border_radius",
            BorderSize = "border_size",
            DisableTracking = true,
            FontSize = "font_size",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Padding = "padding",
            Style = Style.Button,
            Type = UnionMember3IntersectionMember1Type.Action,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember3
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Href = "href",
            ActionID = "action_id",
            BackgroundColor = "background_color",
            BorderRadius = "border_radius",
            BorderSize = "border_size",
            DisableTracking = true,
            FontSize = "font_size",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Padding = "padding",
            Style = Style.Button,
        };

        Assert.Null(model.Align);
        Assert.False(model.RawData.ContainsKey("align"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionMember3
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Href = "href",
            ActionID = "action_id",
            BackgroundColor = "background_color",
            BorderRadius = "border_radius",
            BorderSize = "border_size",
            DisableTracking = true,
            FontSize = "font_size",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Padding = "padding",
            Style = Style.Button,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnionMember3
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Href = "href",
            ActionID = "action_id",
            BackgroundColor = "background_color",
            BorderRadius = "border_radius",
            BorderSize = "border_size",
            DisableTracking = true,
            FontSize = "font_size",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Padding = "padding",
            Style = Style.Button,

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
        var model = new UnionMember3
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Href = "href",
            ActionID = "action_id",
            BackgroundColor = "background_color",
            BorderRadius = "border_radius",
            BorderSize = "border_size",
            DisableTracking = true,
            FontSize = "font_size",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Padding = "padding",
            Style = Style.Button,

            // Null should be interpreted as omitted for these properties
            Align = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember3
        {
            Content = "content",
            Href = "href",
            Align = Alignment.Center,
            Type = UnionMember3IntersectionMember1Type.Action,
        };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.If);
        Assert.False(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.False(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.False(model.RawData.ContainsKey("ref"));
        Assert.Null(model.ActionID);
        Assert.False(model.RawData.ContainsKey("action_id"));
        Assert.Null(model.BackgroundColor);
        Assert.False(model.RawData.ContainsKey("background_color"));
        Assert.Null(model.BorderRadius);
        Assert.False(model.RawData.ContainsKey("border_radius"));
        Assert.Null(model.BorderSize);
        Assert.False(model.RawData.ContainsKey("border_size"));
        Assert.Null(model.DisableTracking);
        Assert.False(model.RawData.ContainsKey("disable_tracking"));
        Assert.Null(model.FontSize);
        Assert.False(model.RawData.ContainsKey("font_size"));
        Assert.Null(model.Locales);
        Assert.False(model.RawData.ContainsKey("locales"));
        Assert.Null(model.Padding);
        Assert.False(model.RawData.ContainsKey("padding"));
        Assert.Null(model.Style);
        Assert.False(model.RawData.ContainsKey("style"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionMember3
        {
            Content = "content",
            Href = "href",
            Align = Alignment.Center,
            Type = UnionMember3IntersectionMember1Type.Action,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UnionMember3
        {
            Content = "content",
            Href = "href",
            Align = Alignment.Center,
            Type = UnionMember3IntersectionMember1Type.Action,

            Channels = null,
            If = null,
            Loop = null,
            Ref = null,
            ActionID = null,
            BackgroundColor = null,
            BorderRadius = null,
            BorderSize = null,
            DisableTracking = null,
            FontSize = null,
            Locales = null,
            Padding = null,
            Style = null,
        };

        Assert.Null(model.Channels);
        Assert.True(model.RawData.ContainsKey("channels"));
        Assert.Null(model.If);
        Assert.True(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.True(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.True(model.RawData.ContainsKey("ref"));
        Assert.Null(model.ActionID);
        Assert.True(model.RawData.ContainsKey("action_id"));
        Assert.Null(model.BackgroundColor);
        Assert.True(model.RawData.ContainsKey("background_color"));
        Assert.Null(model.BorderRadius);
        Assert.True(model.RawData.ContainsKey("border_radius"));
        Assert.Null(model.BorderSize);
        Assert.True(model.RawData.ContainsKey("border_size"));
        Assert.Null(model.DisableTracking);
        Assert.True(model.RawData.ContainsKey("disable_tracking"));
        Assert.Null(model.FontSize);
        Assert.True(model.RawData.ContainsKey("font_size"));
        Assert.Null(model.Locales);
        Assert.True(model.RawData.ContainsKey("locales"));
        Assert.Null(model.Padding);
        Assert.True(model.RawData.ContainsKey("padding"));
        Assert.Null(model.Style);
        Assert.True(model.RawData.ContainsKey("style"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UnionMember3
        {
            Content = "content",
            Href = "href",
            Align = Alignment.Center,
            Type = UnionMember3IntersectionMember1Type.Action,

            Channels = null,
            If = null,
            Loop = null,
            Ref = null,
            ActionID = null,
            BackgroundColor = null,
            BorderRadius = null,
            BorderSize = null,
            DisableTracking = null,
            FontSize = null,
            Locales = null,
            Padding = null,
            Style = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnionMember3
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Href = "href",
            ActionID = "action_id",
            Align = Alignment.Center,
            BackgroundColor = "background_color",
            BorderRadius = "border_radius",
            BorderSize = "border_size",
            DisableTracking = true,
            FontSize = "font_size",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Padding = "padding",
            Style = Style.Button,
            Type = UnionMember3IntersectionMember1Type.Action,
        };

        UnionMember3 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnionMember3IntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionMember3IntersectionMember1
        {
            Type = UnionMember3IntersectionMember1Type.Action,
        };

        ApiEnum<string, UnionMember3IntersectionMember1Type> expectedType =
            UnionMember3IntersectionMember1Type.Action;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnionMember3IntersectionMember1
        {
            Type = UnionMember3IntersectionMember1Type.Action,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember3IntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionMember3IntersectionMember1
        {
            Type = UnionMember3IntersectionMember1Type.Action,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember3IntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, UnionMember3IntersectionMember1Type> expectedType =
            UnionMember3IntersectionMember1Type.Action;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnionMember3IntersectionMember1
        {
            Type = UnionMember3IntersectionMember1Type.Action,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember3IntersectionMember1 { };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionMember3IntersectionMember1 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnionMember3IntersectionMember1
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
        var model = new UnionMember3IntersectionMember1
        {
            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnionMember3IntersectionMember1
        {
            Type = UnionMember3IntersectionMember1Type.Action,
        };

        UnionMember3IntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnionMember3IntersectionMember1TypeTest : TestBase
{
    [Theory]
    [InlineData(UnionMember3IntersectionMember1Type.Action)]
    public void Validation_Works(UnionMember3IntersectionMember1Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember3IntersectionMember1Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember3IntersectionMember1Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UnionMember3IntersectionMember1Type.Action)]
    public void SerializationRoundtrip_Works(UnionMember3IntersectionMember1Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember3IntersectionMember1Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember3IntersectionMember1Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember3IntersectionMember1Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember3IntersectionMember1Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UnionMember4Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionMember4
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Color = "color",
            Type = UnionMember4IntersectionMember1Type.Divider,
        };

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        string expectedColor = "color";
        ApiEnum<string, UnionMember4IntersectionMember1Type> expectedType =
            UnionMember4IntersectionMember1Type.Divider;

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
        var model = new UnionMember4
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Color = "color",
            Type = UnionMember4IntersectionMember1Type.Divider,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember4>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionMember4
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Color = "color",
            Type = UnionMember4IntersectionMember1Type.Divider,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember4>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        string expectedColor = "color";
        ApiEnum<string, UnionMember4IntersectionMember1Type> expectedType =
            UnionMember4IntersectionMember1Type.Divider;

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
        var model = new UnionMember4
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Color = "color",
            Type = UnionMember4IntersectionMember1Type.Divider,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember4
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
        var model = new UnionMember4
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
        var model = new UnionMember4
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
        var model = new UnionMember4
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
        var model = new UnionMember4 { Type = UnionMember4IntersectionMember1Type.Divider };

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
        var model = new UnionMember4 { Type = UnionMember4IntersectionMember1Type.Divider };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UnionMember4
        {
            Type = UnionMember4IntersectionMember1Type.Divider,

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
        var model = new UnionMember4
        {
            Type = UnionMember4IntersectionMember1Type.Divider,

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
        var model = new UnionMember4
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Color = "color",
            Type = UnionMember4IntersectionMember1Type.Divider,
        };

        UnionMember4 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnionMember4IntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionMember4IntersectionMember1
        {
            Type = UnionMember4IntersectionMember1Type.Divider,
        };

        ApiEnum<string, UnionMember4IntersectionMember1Type> expectedType =
            UnionMember4IntersectionMember1Type.Divider;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnionMember4IntersectionMember1
        {
            Type = UnionMember4IntersectionMember1Type.Divider,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember4IntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionMember4IntersectionMember1
        {
            Type = UnionMember4IntersectionMember1Type.Divider,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember4IntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, UnionMember4IntersectionMember1Type> expectedType =
            UnionMember4IntersectionMember1Type.Divider;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnionMember4IntersectionMember1
        {
            Type = UnionMember4IntersectionMember1Type.Divider,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember4IntersectionMember1 { };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionMember4IntersectionMember1 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnionMember4IntersectionMember1
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
        var model = new UnionMember4IntersectionMember1
        {
            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnionMember4IntersectionMember1
        {
            Type = UnionMember4IntersectionMember1Type.Divider,
        };

        UnionMember4IntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnionMember4IntersectionMember1TypeTest : TestBase
{
    [Theory]
    [InlineData(UnionMember4IntersectionMember1Type.Divider)]
    public void Validation_Works(UnionMember4IntersectionMember1Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember4IntersectionMember1Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember4IntersectionMember1Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UnionMember4IntersectionMember1Type.Divider)]
    public void SerializationRoundtrip_Works(UnionMember4IntersectionMember1Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember4IntersectionMember1Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember4IntersectionMember1Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember4IntersectionMember1Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember4IntersectionMember1Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UnionMember5Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionMember5
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Align = Alignment.Center,
            BorderColor = "border_color",
            FontSize = "font_size",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            TextStyle = TextStyle.Text,
            Type = UnionMember5IntersectionMember1Type.Quote,
        };

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        string expectedContent = "content";
        ApiEnum<string, Alignment> expectedAlign = Alignment.Center;
        string expectedBorderColor = "border_color";
        string expectedFontSize = "font_size";
        string expectedLineHeight = "line_height";
        Dictionary<string, LocalesItem> expectedLocales = new() { { "foo", new("content") } };
        ApiEnum<string, TextStyle> expectedTextStyle = TextStyle.Text;
        ApiEnum<string, UnionMember5IntersectionMember1Type> expectedType =
            UnionMember5IntersectionMember1Type.Quote;

        Assert.NotNull(model.Channels);
        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], model.Channels[i]);
        }
        Assert.Equal(expectedIf, model.If);
        Assert.Equal(expectedLoop, model.Loop);
        Assert.Equal(expectedRef, model.Ref);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedAlign, model.Align);
        Assert.Equal(expectedBorderColor, model.BorderColor);
        Assert.Equal(expectedFontSize, model.FontSize);
        Assert.Equal(expectedLineHeight, model.LineHeight);
        Assert.NotNull(model.Locales);
        Assert.Equal(expectedLocales.Count, model.Locales.Count);
        foreach (var item in expectedLocales)
        {
            Assert.True(model.Locales.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Locales[item.Key]);
        }
        Assert.Equal(expectedTextStyle, model.TextStyle);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnionMember5
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Align = Alignment.Center,
            BorderColor = "border_color",
            FontSize = "font_size",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            TextStyle = TextStyle.Text,
            Type = UnionMember5IntersectionMember1Type.Quote,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember5>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionMember5
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Align = Alignment.Center,
            BorderColor = "border_color",
            FontSize = "font_size",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            TextStyle = TextStyle.Text,
            Type = UnionMember5IntersectionMember1Type.Quote,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember5>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        string expectedContent = "content";
        ApiEnum<string, Alignment> expectedAlign = Alignment.Center;
        string expectedBorderColor = "border_color";
        string expectedFontSize = "font_size";
        string expectedLineHeight = "line_height";
        Dictionary<string, LocalesItem> expectedLocales = new() { { "foo", new("content") } };
        ApiEnum<string, TextStyle> expectedTextStyle = TextStyle.Text;
        ApiEnum<string, UnionMember5IntersectionMember1Type> expectedType =
            UnionMember5IntersectionMember1Type.Quote;

        Assert.NotNull(deserialized.Channels);
        Assert.Equal(expectedChannels.Count, deserialized.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], deserialized.Channels[i]);
        }
        Assert.Equal(expectedIf, deserialized.If);
        Assert.Equal(expectedLoop, deserialized.Loop);
        Assert.Equal(expectedRef, deserialized.Ref);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedAlign, deserialized.Align);
        Assert.Equal(expectedBorderColor, deserialized.BorderColor);
        Assert.Equal(expectedFontSize, deserialized.FontSize);
        Assert.Equal(expectedLineHeight, deserialized.LineHeight);
        Assert.NotNull(deserialized.Locales);
        Assert.Equal(expectedLocales.Count, deserialized.Locales.Count);
        foreach (var item in expectedLocales)
        {
            Assert.True(deserialized.Locales.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Locales[item.Key]);
        }
        Assert.Equal(expectedTextStyle, deserialized.TextStyle);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnionMember5
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Align = Alignment.Center,
            BorderColor = "border_color",
            FontSize = "font_size",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            TextStyle = TextStyle.Text,
            Type = UnionMember5IntersectionMember1Type.Quote,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember5
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            BorderColor = "border_color",
            FontSize = "font_size",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
        };

        Assert.Null(model.Align);
        Assert.False(model.RawData.ContainsKey("align"));
        Assert.Null(model.TextStyle);
        Assert.False(model.RawData.ContainsKey("text_style"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionMember5
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            BorderColor = "border_color",
            FontSize = "font_size",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnionMember5
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            BorderColor = "border_color",
            FontSize = "font_size",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },

            // Null should be interpreted as omitted for these properties
            Align = null,
            TextStyle = null,
            Type = null,
        };

        Assert.Null(model.Align);
        Assert.False(model.RawData.ContainsKey("align"));
        Assert.Null(model.TextStyle);
        Assert.False(model.RawData.ContainsKey("text_style"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UnionMember5
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            BorderColor = "border_color",
            FontSize = "font_size",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },

            // Null should be interpreted as omitted for these properties
            Align = null,
            TextStyle = null,
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember5
        {
            Content = "content",
            Align = Alignment.Center,
            TextStyle = TextStyle.Text,
            Type = UnionMember5IntersectionMember1Type.Quote,
        };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.If);
        Assert.False(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.False(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.False(model.RawData.ContainsKey("ref"));
        Assert.Null(model.BorderColor);
        Assert.False(model.RawData.ContainsKey("border_color"));
        Assert.Null(model.FontSize);
        Assert.False(model.RawData.ContainsKey("font_size"));
        Assert.Null(model.LineHeight);
        Assert.False(model.RawData.ContainsKey("line_height"));
        Assert.Null(model.Locales);
        Assert.False(model.RawData.ContainsKey("locales"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionMember5
        {
            Content = "content",
            Align = Alignment.Center,
            TextStyle = TextStyle.Text,
            Type = UnionMember5IntersectionMember1Type.Quote,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UnionMember5
        {
            Content = "content",
            Align = Alignment.Center,
            TextStyle = TextStyle.Text,
            Type = UnionMember5IntersectionMember1Type.Quote,

            Channels = null,
            If = null,
            Loop = null,
            Ref = null,
            BorderColor = null,
            FontSize = null,
            LineHeight = null,
            Locales = null,
        };

        Assert.Null(model.Channels);
        Assert.True(model.RawData.ContainsKey("channels"));
        Assert.Null(model.If);
        Assert.True(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.True(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.True(model.RawData.ContainsKey("ref"));
        Assert.Null(model.BorderColor);
        Assert.True(model.RawData.ContainsKey("border_color"));
        Assert.Null(model.FontSize);
        Assert.True(model.RawData.ContainsKey("font_size"));
        Assert.Null(model.LineHeight);
        Assert.True(model.RawData.ContainsKey("line_height"));
        Assert.Null(model.Locales);
        Assert.True(model.RawData.ContainsKey("locales"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UnionMember5
        {
            Content = "content",
            Align = Alignment.Center,
            TextStyle = TextStyle.Text,
            Type = UnionMember5IntersectionMember1Type.Quote,

            Channels = null,
            If = null,
            Loop = null,
            Ref = null,
            BorderColor = null,
            FontSize = null,
            LineHeight = null,
            Locales = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnionMember5
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Align = Alignment.Center,
            BorderColor = "border_color",
            FontSize = "font_size",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            TextStyle = TextStyle.Text,
            Type = UnionMember5IntersectionMember1Type.Quote,
        };

        UnionMember5 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnionMember5IntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionMember5IntersectionMember1
        {
            Type = UnionMember5IntersectionMember1Type.Quote,
        };

        ApiEnum<string, UnionMember5IntersectionMember1Type> expectedType =
            UnionMember5IntersectionMember1Type.Quote;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnionMember5IntersectionMember1
        {
            Type = UnionMember5IntersectionMember1Type.Quote,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember5IntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionMember5IntersectionMember1
        {
            Type = UnionMember5IntersectionMember1Type.Quote,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember5IntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, UnionMember5IntersectionMember1Type> expectedType =
            UnionMember5IntersectionMember1Type.Quote;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnionMember5IntersectionMember1
        {
            Type = UnionMember5IntersectionMember1Type.Quote,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember5IntersectionMember1 { };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionMember5IntersectionMember1 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnionMember5IntersectionMember1
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
        var model = new UnionMember5IntersectionMember1
        {
            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnionMember5IntersectionMember1
        {
            Type = UnionMember5IntersectionMember1Type.Quote,
        };

        UnionMember5IntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnionMember5IntersectionMember1TypeTest : TestBase
{
    [Theory]
    [InlineData(UnionMember5IntersectionMember1Type.Quote)]
    public void Validation_Works(UnionMember5IntersectionMember1Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember5IntersectionMember1Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember5IntersectionMember1Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UnionMember5IntersectionMember1Type.Quote)]
    public void SerializationRoundtrip_Works(UnionMember5IntersectionMember1Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember5IntersectionMember1Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember5IntersectionMember1Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember5IntersectionMember1Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember5IntersectionMember1Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class UnionMember6Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionMember6
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Type = UnionMember6IntersectionMember1Type.Html,
        };

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        string expectedContent = "content";
        Dictionary<string, LocalesItem> expectedLocales = new() { { "foo", new("content") } };
        ApiEnum<string, UnionMember6IntersectionMember1Type> expectedType =
            UnionMember6IntersectionMember1Type.Html;

        Assert.NotNull(model.Channels);
        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], model.Channels[i]);
        }
        Assert.Equal(expectedIf, model.If);
        Assert.Equal(expectedLoop, model.Loop);
        Assert.Equal(expectedRef, model.Ref);
        Assert.Equal(expectedContent, model.Content);
        Assert.NotNull(model.Locales);
        Assert.Equal(expectedLocales.Count, model.Locales.Count);
        foreach (var item in expectedLocales)
        {
            Assert.True(model.Locales.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Locales[item.Key]);
        }
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnionMember6
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Type = UnionMember6IntersectionMember1Type.Html,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember6>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionMember6
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Type = UnionMember6IntersectionMember1Type.Html,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember6>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        string expectedContent = "content";
        Dictionary<string, LocalesItem> expectedLocales = new() { { "foo", new("content") } };
        ApiEnum<string, UnionMember6IntersectionMember1Type> expectedType =
            UnionMember6IntersectionMember1Type.Html;

        Assert.NotNull(deserialized.Channels);
        Assert.Equal(expectedChannels.Count, deserialized.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], deserialized.Channels[i]);
        }
        Assert.Equal(expectedIf, deserialized.If);
        Assert.Equal(expectedLoop, deserialized.Loop);
        Assert.Equal(expectedRef, deserialized.Ref);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.NotNull(deserialized.Locales);
        Assert.Equal(expectedLocales.Count, deserialized.Locales.Count);
        foreach (var item in expectedLocales)
        {
            Assert.True(deserialized.Locales.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Locales[item.Key]);
        }
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnionMember6
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Type = UnionMember6IntersectionMember1Type.Html,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember6
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionMember6
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnionMember6
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UnionMember6
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },

            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember6
        {
            Content = "content",
            Type = UnionMember6IntersectionMember1Type.Html,
        };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.If);
        Assert.False(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.False(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.False(model.RawData.ContainsKey("ref"));
        Assert.Null(model.Locales);
        Assert.False(model.RawData.ContainsKey("locales"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionMember6
        {
            Content = "content",
            Type = UnionMember6IntersectionMember1Type.Html,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new UnionMember6
        {
            Content = "content",
            Type = UnionMember6IntersectionMember1Type.Html,

            Channels = null,
            If = null,
            Loop = null,
            Ref = null,
            Locales = null,
        };

        Assert.Null(model.Channels);
        Assert.True(model.RawData.ContainsKey("channels"));
        Assert.Null(model.If);
        Assert.True(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.True(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.True(model.RawData.ContainsKey("ref"));
        Assert.Null(model.Locales);
        Assert.True(model.RawData.ContainsKey("locales"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new UnionMember6
        {
            Content = "content",
            Type = UnionMember6IntersectionMember1Type.Html,

            Channels = null,
            If = null,
            Loop = null,
            Ref = null,
            Locales = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnionMember6
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Type = UnionMember6IntersectionMember1Type.Html,
        };

        UnionMember6 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnionMember6IntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UnionMember6IntersectionMember1
        {
            Type = UnionMember6IntersectionMember1Type.Html,
        };

        ApiEnum<string, UnionMember6IntersectionMember1Type> expectedType =
            UnionMember6IntersectionMember1Type.Html;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UnionMember6IntersectionMember1
        {
            Type = UnionMember6IntersectionMember1Type.Html,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember6IntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UnionMember6IntersectionMember1
        {
            Type = UnionMember6IntersectionMember1Type.Html,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UnionMember6IntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, UnionMember6IntersectionMember1Type> expectedType =
            UnionMember6IntersectionMember1Type.Html;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UnionMember6IntersectionMember1
        {
            Type = UnionMember6IntersectionMember1Type.Html,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new UnionMember6IntersectionMember1 { };

        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new UnionMember6IntersectionMember1 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new UnionMember6IntersectionMember1
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
        var model = new UnionMember6IntersectionMember1
        {
            // Null should be interpreted as omitted for these properties
            Type = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UnionMember6IntersectionMember1
        {
            Type = UnionMember6IntersectionMember1Type.Html,
        };

        UnionMember6IntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnionMember6IntersectionMember1TypeTest : TestBase
{
    [Theory]
    [InlineData(UnionMember6IntersectionMember1Type.Html)]
    public void Validation_Works(UnionMember6IntersectionMember1Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember6IntersectionMember1Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember6IntersectionMember1Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(UnionMember6IntersectionMember1Type.Html)]
    public void SerializationRoundtrip_Works(UnionMember6IntersectionMember1Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, UnionMember6IntersectionMember1Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember6IntersectionMember1Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember6IntersectionMember1Type>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, UnionMember6IntersectionMember1Type>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
