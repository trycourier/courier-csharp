using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;

namespace TryCourier.Tests.Models;

public class ElementalQuoteNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalQuoteNode
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ElementalQuoteNode
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalQuoteNode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ElementalQuoteNode
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalQuoteNode>(
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ElementalQuoteNode
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalQuoteNode
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
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ElementalQuoteNode
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
        var model = new ElementalQuoteNode
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
        };

        Assert.Null(model.Align);
        Assert.False(model.RawData.ContainsKey("align"));
        Assert.Null(model.TextStyle);
        Assert.False(model.RawData.ContainsKey("text_style"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ElementalQuoteNode
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalQuoteNode
        {
            Content = "content",
            Align = Alignment.Center,
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
        var model = new ElementalQuoteNode
        {
            Content = "content",
            Align = Alignment.Center,
            TextStyle = TextStyle.Text,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ElementalQuoteNode
        {
            Content = "content",
            Align = Alignment.Center,
            TextStyle = TextStyle.Text,

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
        var model = new ElementalQuoteNode
        {
            Content = "content",
            Align = Alignment.Center,
            TextStyle = TextStyle.Text,

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
        var model = new ElementalQuoteNode
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
        };

        ElementalQuoteNode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ElementalQuoteNodeIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalQuoteNodeIntersectionMember1
        {
            Content = "content",
            Align = Alignment.Center,
            BorderColor = "border_color",
            FontSize = "font_size",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            TextStyle = TextStyle.Text,
        };

        string expectedContent = "content";
        ApiEnum<string, Alignment> expectedAlign = Alignment.Center;
        string expectedBorderColor = "border_color";
        string expectedFontSize = "font_size";
        string expectedLineHeight = "line_height";
        Dictionary<string, LocalesItem> expectedLocales = new() { { "foo", new("content") } };
        ApiEnum<string, TextStyle> expectedTextStyle = TextStyle.Text;

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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ElementalQuoteNodeIntersectionMember1
        {
            Content = "content",
            Align = Alignment.Center,
            BorderColor = "border_color",
            FontSize = "font_size",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            TextStyle = TextStyle.Text,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalQuoteNodeIntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ElementalQuoteNodeIntersectionMember1
        {
            Content = "content",
            Align = Alignment.Center,
            BorderColor = "border_color",
            FontSize = "font_size",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            TextStyle = TextStyle.Text,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalQuoteNodeIntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        ApiEnum<string, Alignment> expectedAlign = Alignment.Center;
        string expectedBorderColor = "border_color";
        string expectedFontSize = "font_size";
        string expectedLineHeight = "line_height";
        Dictionary<string, LocalesItem> expectedLocales = new() { { "foo", new("content") } };
        ApiEnum<string, TextStyle> expectedTextStyle = TextStyle.Text;

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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ElementalQuoteNodeIntersectionMember1
        {
            Content = "content",
            Align = Alignment.Center,
            BorderColor = "border_color",
            FontSize = "font_size",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            TextStyle = TextStyle.Text,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalQuoteNodeIntersectionMember1
        {
            Content = "content",
            Align = Alignment.Center,
            BorderColor = "border_color",
            FontSize = "font_size",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
        };

        Assert.Null(model.TextStyle);
        Assert.False(model.RawData.ContainsKey("text_style"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ElementalQuoteNodeIntersectionMember1
        {
            Content = "content",
            Align = Alignment.Center,
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
        var model = new ElementalQuoteNodeIntersectionMember1
        {
            Content = "content",
            Align = Alignment.Center,
            BorderColor = "border_color",
            FontSize = "font_size",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },

            // Null should be interpreted as omitted for these properties
            TextStyle = null,
        };

        Assert.Null(model.TextStyle);
        Assert.False(model.RawData.ContainsKey("text_style"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ElementalQuoteNodeIntersectionMember1
        {
            Content = "content",
            Align = Alignment.Center,
            BorderColor = "border_color",
            FontSize = "font_size",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },

            // Null should be interpreted as omitted for these properties
            TextStyle = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalQuoteNodeIntersectionMember1
        {
            Content = "content",
            TextStyle = TextStyle.Text,
        };

        Assert.Null(model.Align);
        Assert.False(model.RawData.ContainsKey("align"));
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
        var model = new ElementalQuoteNodeIntersectionMember1
        {
            Content = "content",
            TextStyle = TextStyle.Text,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ElementalQuoteNodeIntersectionMember1
        {
            Content = "content",
            TextStyle = TextStyle.Text,

            Align = null,
            BorderColor = null,
            FontSize = null,
            LineHeight = null,
            Locales = null,
        };

        Assert.Null(model.Align);
        Assert.True(model.RawData.ContainsKey("align"));
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
        var model = new ElementalQuoteNodeIntersectionMember1
        {
            Content = "content",
            TextStyle = TextStyle.Text,

            Align = null,
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
        var model = new ElementalQuoteNodeIntersectionMember1
        {
            Content = "content",
            Align = Alignment.Center,
            BorderColor = "border_color",
            FontSize = "font_size",
            LineHeight = "line_height",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            TextStyle = TextStyle.Text,
        };

        ElementalQuoteNodeIntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}
