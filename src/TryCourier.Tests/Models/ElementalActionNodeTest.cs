using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models;

namespace TryCourier.Tests.Models;

public class ElementalActionNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalActionNode
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ElementalActionNode
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalActionNode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ElementalActionNode
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalActionNode>(
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ElementalActionNode
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalActionNode
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
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ElementalActionNode
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
        var model = new ElementalActionNode
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
        };

        Assert.Null(model.Align);
        Assert.False(model.RawData.ContainsKey("align"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ElementalActionNode
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalActionNode
        {
            Content = "content",
            Href = "href",
            Align = Alignment.Center,
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
        var model = new ElementalActionNode
        {
            Content = "content",
            Href = "href",
            Align = Alignment.Center,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ElementalActionNode
        {
            Content = "content",
            Href = "href",
            Align = Alignment.Center,

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
        var model = new ElementalActionNode
        {
            Content = "content",
            Href = "href",
            Align = Alignment.Center,

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
        var model = new ElementalActionNode
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
        };

        ElementalActionNode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntersectionMember1
        {
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
        };

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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntersectionMember1
        {
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntersectionMember1
        {
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IntersectionMember1
        {
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new IntersectionMember1 { Content = "content", Href = "href" };

        Assert.Null(model.ActionID);
        Assert.False(model.RawData.ContainsKey("action_id"));
        Assert.Null(model.Align);
        Assert.False(model.RawData.ContainsKey("align"));
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
        var model = new IntersectionMember1 { Content = "content", Href = "href" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new IntersectionMember1
        {
            Content = "content",
            Href = "href",

            ActionID = null,
            Align = null,
            BackgroundColor = null,
            BorderRadius = null,
            BorderSize = null,
            DisableTracking = null,
            FontSize = null,
            Locales = null,
            Padding = null,
            Style = null,
        };

        Assert.Null(model.ActionID);
        Assert.True(model.RawData.ContainsKey("action_id"));
        Assert.Null(model.Align);
        Assert.True(model.RawData.ContainsKey("align"));
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
        var model = new IntersectionMember1
        {
            Content = "content",
            Href = "href",

            ActionID = null,
            Align = null,
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
        var model = new IntersectionMember1
        {
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
        };

        IntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StyleTest : TestBase
{
    [Theory]
    [InlineData(Style.Button)]
    [InlineData(Style.Link)]
    public void Validation_Works(Style rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Style> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Style>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Style.Button)]
    [InlineData(Style.Link)]
    public void SerializationRoundtrip_Works(Style rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Style> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Style>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Style>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Style>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
