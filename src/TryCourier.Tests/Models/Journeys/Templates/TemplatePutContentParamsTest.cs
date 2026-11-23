using System;
using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models;
using TryCourier.Models.Journeys.Templates;
using Notifications = TryCourier.Models.Notifications;

namespace TryCourier.Tests.Models.Journeys.Templates;

public class TemplatePutContentParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new TemplatePutContentParams
        {
            TemplateID = "x",
            NotificationID = "x",
            Content = new()
            {
                Elements =
                [
                    new ElementalChannelNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Channel = "email",
                        Elements =
                        [
                            new UnionMember1()
                            {
                                Channels = ["string"],
                                If = "if",
                                Loop = "loop",
                                Ref = "ref",
                                Title = "Welcome!",
                                Type = UnionMember1IntersectionMember1Type.Meta,
                            },
                            new UnionMember0()
                            {
                                Channels = ["string"],
                                If = "if",
                                Loop = "loop",
                                Ref = "ref",
                                Align = Align.Left,
                                Bold = "bold",
                                Color = "color",
                                Content = "Hello {{data.name}}.",
                                FontSize = "font_size",
                                Format = Format.Markdown,
                                Italic = "italic",
                                LineHeight = "line_height",
                                Locales = new Dictionary<string, LocalesItem>()
                                {
                                    { "foo", new("content") },
                                },
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
                    },
                ],
                Scope = TemplatePutContentParamsContentScope.Default,
                Version = "2022-01-01",
            },
            State = Notifications::NotificationTemplateState.Draft,
        };

        string expectedTemplateID = "x";
        string expectedNotificationID = "x";
        TemplatePutContentParamsContent expectedContent = new()
        {
            Elements =
            [
                new ElementalChannelNodeWithType()
                {
                    Channels = ["string"],
                    If = "if",
                    Loop = "loop",
                    Ref = "ref",
                    Channel = "email",
                    Elements =
                    [
                        new UnionMember1()
                        {
                            Channels = ["string"],
                            If = "if",
                            Loop = "loop",
                            Ref = "ref",
                            Title = "Welcome!",
                            Type = UnionMember1IntersectionMember1Type.Meta,
                        },
                        new UnionMember0()
                        {
                            Channels = ["string"],
                            If = "if",
                            Loop = "loop",
                            Ref = "ref",
                            Align = Align.Left,
                            Bold = "bold",
                            Color = "color",
                            Content = "Hello {{data.name}}.",
                            FontSize = "font_size",
                            Format = Format.Markdown,
                            Italic = "italic",
                            LineHeight = "line_height",
                            Locales = new Dictionary<string, LocalesItem>()
                            {
                                { "foo", new("content") },
                            },
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
                },
            ],
            Scope = TemplatePutContentParamsContentScope.Default,
            Version = "2022-01-01",
        };
        ApiEnum<string, Notifications::NotificationTemplateState> expectedState =
            Notifications::NotificationTemplateState.Draft;

        Assert.Equal(expectedTemplateID, parameters.TemplateID);
        Assert.Equal(expectedNotificationID, parameters.NotificationID);
        Assert.Equal(expectedContent, parameters.Content);
        Assert.Equal(expectedState, parameters.State);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new TemplatePutContentParams
        {
            TemplateID = "x",
            NotificationID = "x",
            Content = new()
            {
                Elements =
                [
                    new ElementalChannelNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Channel = "email",
                        Elements =
                        [
                            new UnionMember1()
                            {
                                Channels = ["string"],
                                If = "if",
                                Loop = "loop",
                                Ref = "ref",
                                Title = "Welcome!",
                                Type = UnionMember1IntersectionMember1Type.Meta,
                            },
                            new UnionMember0()
                            {
                                Channels = ["string"],
                                If = "if",
                                Loop = "loop",
                                Ref = "ref",
                                Align = Align.Left,
                                Bold = "bold",
                                Color = "color",
                                Content = "Hello {{data.name}}.",
                                FontSize = "font_size",
                                Format = Format.Markdown,
                                Italic = "italic",
                                LineHeight = "line_height",
                                Locales = new Dictionary<string, LocalesItem>()
                                {
                                    { "foo", new("content") },
                                },
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
                    },
                ],
                Scope = TemplatePutContentParamsContentScope.Default,
                Version = "2022-01-01",
            },
        };

        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new TemplatePutContentParams
        {
            TemplateID = "x",
            NotificationID = "x",
            Content = new()
            {
                Elements =
                [
                    new ElementalChannelNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Channel = "email",
                        Elements =
                        [
                            new UnionMember1()
                            {
                                Channels = ["string"],
                                If = "if",
                                Loop = "loop",
                                Ref = "ref",
                                Title = "Welcome!",
                                Type = UnionMember1IntersectionMember1Type.Meta,
                            },
                            new UnionMember0()
                            {
                                Channels = ["string"],
                                If = "if",
                                Loop = "loop",
                                Ref = "ref",
                                Align = Align.Left,
                                Bold = "bold",
                                Color = "color",
                                Content = "Hello {{data.name}}.",
                                FontSize = "font_size",
                                Format = Format.Markdown,
                                Italic = "italic",
                                LineHeight = "line_height",
                                Locales = new Dictionary<string, LocalesItem>()
                                {
                                    { "foo", new("content") },
                                },
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
                    },
                ],
                Scope = TemplatePutContentParamsContentScope.Default,
                Version = "2022-01-01",
            },

            // Null should be interpreted as omitted for these properties
            State = null,
        };

        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
    }

    [Fact]
    public void Url_Works()
    {
        TemplatePutContentParams parameters = new()
        {
            TemplateID = "x",
            NotificationID = "x",
            Content = new()
            {
                Elements =
                [
                    new ElementalChannelNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Channel = "email",
                        Elements =
                        [
                            new UnionMember1()
                            {
                                Channels = ["string"],
                                If = "if",
                                Loop = "loop",
                                Ref = "ref",
                                Title = "Welcome!",
                                Type = UnionMember1IntersectionMember1Type.Meta,
                            },
                            new UnionMember0()
                            {
                                Channels = ["string"],
                                If = "if",
                                Loop = "loop",
                                Ref = "ref",
                                Align = Align.Left,
                                Bold = "bold",
                                Color = "color",
                                Content = "Hello {{data.name}}.",
                                FontSize = "font_size",
                                Format = Format.Markdown,
                                Italic = "italic",
                                LineHeight = "line_height",
                                Locales = new Dictionary<string, LocalesItem>()
                                {
                                    { "foo", new("content") },
                                },
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
                    },
                ],
                Scope = TemplatePutContentParamsContentScope.Default,
                Version = "2022-01-01",
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/journeys/x/templates/x/content"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new TemplatePutContentParams
        {
            TemplateID = "x",
            NotificationID = "x",
            Content = new()
            {
                Elements =
                [
                    new ElementalChannelNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Channel = "email",
                        Elements =
                        [
                            new UnionMember1()
                            {
                                Channels = ["string"],
                                If = "if",
                                Loop = "loop",
                                Ref = "ref",
                                Title = "Welcome!",
                                Type = UnionMember1IntersectionMember1Type.Meta,
                            },
                            new UnionMember0()
                            {
                                Channels = ["string"],
                                If = "if",
                                Loop = "loop",
                                Ref = "ref",
                                Align = Align.Left,
                                Bold = "bold",
                                Color = "color",
                                Content = "Hello {{data.name}}.",
                                FontSize = "font_size",
                                Format = Format.Markdown,
                                Italic = "italic",
                                LineHeight = "line_height",
                                Locales = new Dictionary<string, LocalesItem>()
                                {
                                    { "foo", new("content") },
                                },
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
                    },
                ],
                Scope = TemplatePutContentParamsContentScope.Default,
                Version = "2022-01-01",
            },
            State = Notifications::NotificationTemplateState.Draft,
        };

        TemplatePutContentParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class TemplatePutContentParamsContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplatePutContentParamsContent
        {
            Elements =
            [
                new ElementalTextNodeWithType()
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
                },
            ],
            Scope = TemplatePutContentParamsContentScope.Default,
            Version = "version",
        };

        List<ElementalNode> expectedElements =
        [
            new ElementalTextNodeWithType()
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
            },
        ];
        ApiEnum<string, TemplatePutContentParamsContentScope> expectedScope =
            TemplatePutContentParamsContentScope.Default;
        string expectedVersion = "version";

        Assert.Equal(expectedElements.Count, model.Elements.Count);
        for (int i = 0; i < expectedElements.Count; i++)
        {
            Assert.Equal(expectedElements[i], model.Elements[i]);
        }
        Assert.Equal(expectedScope, model.Scope);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TemplatePutContentParamsContent
        {
            Elements =
            [
                new ElementalTextNodeWithType()
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
                },
            ],
            Scope = TemplatePutContentParamsContentScope.Default,
            Version = "version",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplatePutContentParamsContent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplatePutContentParamsContent
        {
            Elements =
            [
                new ElementalTextNodeWithType()
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
                },
            ],
            Scope = TemplatePutContentParamsContentScope.Default,
            Version = "version",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TemplatePutContentParamsContent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ElementalNode> expectedElements =
        [
            new ElementalTextNodeWithType()
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
            },
        ];
        ApiEnum<string, TemplatePutContentParamsContentScope> expectedScope =
            TemplatePutContentParamsContentScope.Default;
        string expectedVersion = "version";

        Assert.Equal(expectedElements.Count, deserialized.Elements.Count);
        for (int i = 0; i < expectedElements.Count; i++)
        {
            Assert.Equal(expectedElements[i], deserialized.Elements[i]);
        }
        Assert.Equal(expectedScope, deserialized.Scope);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TemplatePutContentParamsContent
        {
            Elements =
            [
                new ElementalTextNodeWithType()
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
                },
            ],
            Scope = TemplatePutContentParamsContentScope.Default,
            Version = "version",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplatePutContentParamsContent
        {
            Elements =
            [
                new ElementalTextNodeWithType()
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
                },
            ],
        };

        Assert.Null(model.Scope);
        Assert.False(model.RawData.ContainsKey("scope"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplatePutContentParamsContent
        {
            Elements =
            [
                new ElementalTextNodeWithType()
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TemplatePutContentParamsContent
        {
            Elements =
            [
                new ElementalTextNodeWithType()
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
                },
            ],

            // Null should be interpreted as omitted for these properties
            Scope = null,
            Version = null,
        };

        Assert.Null(model.Scope);
        Assert.False(model.RawData.ContainsKey("scope"));
        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplatePutContentParamsContent
        {
            Elements =
            [
                new ElementalTextNodeWithType()
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
                },
            ],

            // Null should be interpreted as omitted for these properties
            Scope = null,
            Version = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TemplatePutContentParamsContent
        {
            Elements =
            [
                new ElementalTextNodeWithType()
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
                },
            ],
            Scope = TemplatePutContentParamsContentScope.Default,
            Version = "version",
        };

        TemplatePutContentParamsContent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TemplatePutContentParamsContentScopeTest : TestBase
{
    [Theory]
    [InlineData(TemplatePutContentParamsContentScope.Default)]
    [InlineData(TemplatePutContentParamsContentScope.Strict)]
    public void Validation_Works(TemplatePutContentParamsContentScope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TemplatePutContentParamsContentScope> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, TemplatePutContentParamsContentScope>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TemplatePutContentParamsContentScope.Default)]
    [InlineData(TemplatePutContentParamsContentScope.Strict)]
    public void SerializationRoundtrip_Works(TemplatePutContentParamsContentScope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TemplatePutContentParamsContentScope> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TemplatePutContentParamsContentScope>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, TemplatePutContentParamsContentScope>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TemplatePutContentParamsContentScope>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
