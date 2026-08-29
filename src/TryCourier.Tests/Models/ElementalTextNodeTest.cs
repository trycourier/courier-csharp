using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models;

namespace TryCourier.Tests.Models;

public class ElementalTextNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalTextNode
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ElementalTextNode
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalTextNode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ElementalTextNode
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalTextNode>(
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ElementalTextNode
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalTextNode
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
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ElementalTextNode
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
        var model = new ElementalTextNode
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
        };

        Assert.Null(model.Align);
        Assert.False(model.RawData.ContainsKey("align"));
        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.TextStyle);
        Assert.False(model.RawData.ContainsKey("text_style"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ElementalTextNode
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalTextNode
        {
            Align = Align.Left,
            Content = "content",
            TextStyle = TextStyle.Text,
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
        var model = new ElementalTextNode
        {
            Align = Align.Left,
            Content = "content",
            TextStyle = TextStyle.Text,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ElementalTextNode
        {
            Align = Align.Left,
            Content = "content",
            TextStyle = TextStyle.Text,

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
        var model = new ElementalTextNode
        {
            Align = Align.Left,
            Content = "content",
            TextStyle = TextStyle.Text,

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
        var model = new ElementalTextNode
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
        };

        ElementalTextNode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ElementalTextNodeIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalTextNodeIntersectionMember1
        {
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
        };

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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ElementalTextNodeIntersectionMember1
        {
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalTextNodeIntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ElementalTextNodeIntersectionMember1
        {
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalTextNodeIntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ElementalTextNodeIntersectionMember1
        {
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalTextNodeIntersectionMember1
        {
            Bold = "bold",
            Color = "color",
            FontSize = "font_size",
            Format = Format.Markdown,
            Italic = "italic",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Strikethrough = "strikethrough",
            TextStyle = TextStyle.Text,
            Underline = "underline",
        };

        Assert.Null(model.Align);
        Assert.False(model.RawData.ContainsKey("align"));
        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ElementalTextNodeIntersectionMember1
        {
            Bold = "bold",
            Color = "color",
            FontSize = "font_size",
            Format = Format.Markdown,
            Italic = "italic",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Strikethrough = "strikethrough",
            TextStyle = TextStyle.Text,
            Underline = "underline",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ElementalTextNodeIntersectionMember1
        {
            Bold = "bold",
            Color = "color",
            FontSize = "font_size",
            Format = Format.Markdown,
            Italic = "italic",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Strikethrough = "strikethrough",
            TextStyle = TextStyle.Text,
            Underline = "underline",

            // Null should be interpreted as omitted for these properties
            Align = null,
            Content = null,
        };

        Assert.Null(model.Align);
        Assert.False(model.RawData.ContainsKey("align"));
        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ElementalTextNodeIntersectionMember1
        {
            Bold = "bold",
            Color = "color",
            FontSize = "font_size",
            Format = Format.Markdown,
            Italic = "italic",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Strikethrough = "strikethrough",
            TextStyle = TextStyle.Text,
            Underline = "underline",

            // Null should be interpreted as omitted for these properties
            Align = null,
            Content = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalTextNodeIntersectionMember1
        {
            Align = Align.Left,
            Content = "content",
        };

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
        Assert.Null(model.TextStyle);
        Assert.False(model.RawData.ContainsKey("text_style"));
        Assert.Null(model.Underline);
        Assert.False(model.RawData.ContainsKey("underline"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ElementalTextNodeIntersectionMember1
        {
            Align = Align.Left,
            Content = "content",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ElementalTextNodeIntersectionMember1
        {
            Align = Align.Left,
            Content = "content",

            Bold = null,
            Color = null,
            FontSize = null,
            Format = null,
            Italic = null,
            LineHeight = null,
            Locales = null,
            Strikethrough = null,
            TextStyle = null,
            Underline = null,
        };

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
        Assert.Null(model.TextStyle);
        Assert.True(model.RawData.ContainsKey("text_style"));
        Assert.Null(model.Underline);
        Assert.True(model.RawData.ContainsKey("underline"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ElementalTextNodeIntersectionMember1
        {
            Align = Align.Left,
            Content = "content",

            Bold = null,
            Color = null,
            FontSize = null,
            Format = null,
            Italic = null,
            LineHeight = null,
            Locales = null,
            Strikethrough = null,
            TextStyle = null,
            Underline = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ElementalTextNodeIntersectionMember1
        {
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
        };

        ElementalTextNodeIntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AlignTest : TestBase
{
    [Theory]
    [InlineData(Align.Left)]
    [InlineData(Align.Center)]
    [InlineData(Align.Right)]
    public void Validation_Works(Align rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Align> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Align>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Align.Left)]
    [InlineData(Align.Center)]
    [InlineData(Align.Right)]
    public void SerializationRoundtrip_Works(Align rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Align> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Align>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Align>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Align>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class FormatTest : TestBase
{
    [Theory]
    [InlineData(Format.Markdown)]
    public void Validation_Works(Format rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Format> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Format>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Format.Markdown)]
    public void SerializationRoundtrip_Works(Format rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Format> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Format>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Format>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Format>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
