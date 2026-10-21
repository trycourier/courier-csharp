using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;

namespace TryCourier.Tests.Models;

public class ElementalNodeTest : TestBase
{
    [Fact]
    public void TextNodeWithTypeValidationWorks()
    {
        ElementalNode value = new ElementalTextNodeWithType()
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
            Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
        };
        value.Validate();
    }

    [Fact]
    public void MetaNodeWithTypeValidationWorks()
    {
        ElementalNode value = new ElementalMetaNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Title = "title",
            Type = ElementalMetaNodeWithTypeIntersectionMember1Type.Meta,
        };
        value.Validate();
    }

    [Fact]
    public void ChannelNodeWithTypeValidationWorks()
    {
        ElementalNode value = new ElementalChannelNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Channel = "email",
            Elements =
            [
                new UnionMember0()
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
                },
            ],
            FontSize = "font_size",
            LineHeight = "line_height",
            Padding = "padding",
            Raw = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
        };
        value.Validate();
    }

    [Fact]
    public void ImageNodeWithTypeValidationWorks()
    {
        ElementalNode value = new ElementalImageNodeWithType()
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
        value.Validate();
    }

    [Fact]
    public void ActionNodeWithTypeValidationWorks()
    {
        ElementalNode value = new ElementalActionNodeWithType()
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
            Type = Type.Action,
        };
        value.Validate();
    }

    [Fact]
    public void DividerNodeWithTypeValidationWorks()
    {
        ElementalNode value = new ElementalDividerNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Color = "color",
            Type = ElementalDividerNodeWithTypeIntersectionMember1Type.Divider,
        };
        value.Validate();
    }

    [Fact]
    public void QuoteNodeWithTypeValidationWorks()
    {
        ElementalNode value = new ElementalQuoteNodeWithType()
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
            Type = ElementalQuoteNodeWithTypeIntersectionMember1Type.Quote,
        };
        value.Validate();
    }

    [Fact]
    public void HtmlNodeWithTypeValidationWorks()
    {
        ElementalNode value = new ElementalHtmlNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Type = ElementalHtmlNodeWithTypeIntersectionMember1Type.Html,
        };
        value.Validate();
    }

    [Fact]
    public void TextNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new ElementalTextNodeWithType()
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
            Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MetaNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new ElementalMetaNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Title = "title",
            Type = ElementalMetaNodeWithTypeIntersectionMember1Type.Meta,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ChannelNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new ElementalChannelNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Channel = "email",
            Elements =
            [
                new UnionMember0()
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
                },
            ],
            FontSize = "font_size",
            LineHeight = "line_height",
            Padding = "padding",
            Raw = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImageNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new ElementalImageNodeWithType()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ActionNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new ElementalActionNodeWithType()
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
            Type = Type.Action,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DividerNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new ElementalDividerNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Color = "color",
            Type = ElementalDividerNodeWithTypeIntersectionMember1Type.Divider,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void QuoteNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new ElementalQuoteNodeWithType()
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
            Type = ElementalQuoteNodeWithTypeIntersectionMember1Type.Quote,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void HtmlNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new ElementalHtmlNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
            Type = ElementalHtmlNodeWithTypeIntersectionMember1Type.Html,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
