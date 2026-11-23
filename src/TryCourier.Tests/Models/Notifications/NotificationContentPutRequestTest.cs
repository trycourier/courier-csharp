using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models;
using Notifications = TryCourier.Models.Notifications;

namespace TryCourier.Tests.Models.Notifications;

public class NotificationContentPutRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Notifications::NotificationContentPutRequest
        {
            Content = new()
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
                        Locales = new Dictionary<string, LocalesItem>()
                        {
                            { "foo", new("content") },
                        },
                        Strikethrough = "strikethrough",
                        TextStyle = TextStyle.Text,
                        Underline = "underline",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Scope = Notifications::NotificationContentPutRequestContentScope.Default,
                Version = "version",
            },
            State = Notifications::NotificationTemplateState.Draft,
        };

        Notifications::NotificationContentPutRequestContent expectedContent = new()
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
            Scope = Notifications::NotificationContentPutRequestContentScope.Default,
            Version = "version",
        };
        ApiEnum<string, Notifications::NotificationTemplateState> expectedState =
            Notifications::NotificationTemplateState.Draft;

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Notifications::NotificationContentPutRequest
        {
            Content = new()
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
                        Locales = new Dictionary<string, LocalesItem>()
                        {
                            { "foo", new("content") },
                        },
                        Strikethrough = "strikethrough",
                        TextStyle = TextStyle.Text,
                        Underline = "underline",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Scope = Notifications::NotificationContentPutRequestContentScope.Default,
                Version = "version",
            },
            State = Notifications::NotificationTemplateState.Draft,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Notifications::NotificationContentPutRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Notifications::NotificationContentPutRequest
        {
            Content = new()
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
                        Locales = new Dictionary<string, LocalesItem>()
                        {
                            { "foo", new("content") },
                        },
                        Strikethrough = "strikethrough",
                        TextStyle = TextStyle.Text,
                        Underline = "underline",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Scope = Notifications::NotificationContentPutRequestContentScope.Default,
                Version = "version",
            },
            State = Notifications::NotificationTemplateState.Draft,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Notifications::NotificationContentPutRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Notifications::NotificationContentPutRequestContent expectedContent = new()
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
            Scope = Notifications::NotificationContentPutRequestContentScope.Default,
            Version = "version",
        };
        ApiEnum<string, Notifications::NotificationTemplateState> expectedState =
            Notifications::NotificationTemplateState.Draft;

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Notifications::NotificationContentPutRequest
        {
            Content = new()
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
                        Locales = new Dictionary<string, LocalesItem>()
                        {
                            { "foo", new("content") },
                        },
                        Strikethrough = "strikethrough",
                        TextStyle = TextStyle.Text,
                        Underline = "underline",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Scope = Notifications::NotificationContentPutRequestContentScope.Default,
                Version = "version",
            },
            State = Notifications::NotificationTemplateState.Draft,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Notifications::NotificationContentPutRequest
        {
            Content = new()
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
                        Locales = new Dictionary<string, LocalesItem>()
                        {
                            { "foo", new("content") },
                        },
                        Strikethrough = "strikethrough",
                        TextStyle = TextStyle.Text,
                        Underline = "underline",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Scope = Notifications::NotificationContentPutRequestContentScope.Default,
                Version = "version",
            },
        };

        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Notifications::NotificationContentPutRequest
        {
            Content = new()
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
                        Locales = new Dictionary<string, LocalesItem>()
                        {
                            { "foo", new("content") },
                        },
                        Strikethrough = "strikethrough",
                        TextStyle = TextStyle.Text,
                        Underline = "underline",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Scope = Notifications::NotificationContentPutRequestContentScope.Default,
                Version = "version",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Notifications::NotificationContentPutRequest
        {
            Content = new()
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
                        Locales = new Dictionary<string, LocalesItem>()
                        {
                            { "foo", new("content") },
                        },
                        Strikethrough = "strikethrough",
                        TextStyle = TextStyle.Text,
                        Underline = "underline",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Scope = Notifications::NotificationContentPutRequestContentScope.Default,
                Version = "version",
            },

            // Null should be interpreted as omitted for these properties
            State = null,
        };

        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Notifications::NotificationContentPutRequest
        {
            Content = new()
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
                        Locales = new Dictionary<string, LocalesItem>()
                        {
                            { "foo", new("content") },
                        },
                        Strikethrough = "strikethrough",
                        TextStyle = TextStyle.Text,
                        Underline = "underline",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Scope = Notifications::NotificationContentPutRequestContentScope.Default,
                Version = "version",
            },

            // Null should be interpreted as omitted for these properties
            State = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Notifications::NotificationContentPutRequest
        {
            Content = new()
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
                        Locales = new Dictionary<string, LocalesItem>()
                        {
                            { "foo", new("content") },
                        },
                        Strikethrough = "strikethrough",
                        TextStyle = TextStyle.Text,
                        Underline = "underline",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Scope = Notifications::NotificationContentPutRequestContentScope.Default,
                Version = "version",
            },
            State = Notifications::NotificationTemplateState.Draft,
        };

        Notifications::NotificationContentPutRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NotificationContentPutRequestContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Notifications::NotificationContentPutRequestContent
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
            Scope = Notifications::NotificationContentPutRequestContentScope.Default,
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
        ApiEnum<string, Notifications::NotificationContentPutRequestContentScope> expectedScope =
            Notifications::NotificationContentPutRequestContentScope.Default;
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
        var model = new Notifications::NotificationContentPutRequestContent
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
            Scope = Notifications::NotificationContentPutRequestContentScope.Default,
            Version = "version",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Notifications::NotificationContentPutRequestContent>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Notifications::NotificationContentPutRequestContent
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
            Scope = Notifications::NotificationContentPutRequestContentScope.Default,
            Version = "version",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Notifications::NotificationContentPutRequestContent>(
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
        ApiEnum<string, Notifications::NotificationContentPutRequestContentScope> expectedScope =
            Notifications::NotificationContentPutRequestContentScope.Default;
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
        var model = new Notifications::NotificationContentPutRequestContent
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
            Scope = Notifications::NotificationContentPutRequestContentScope.Default,
            Version = "version",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Notifications::NotificationContentPutRequestContent
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
        var model = new Notifications::NotificationContentPutRequestContent
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
        var model = new Notifications::NotificationContentPutRequestContent
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
        var model = new Notifications::NotificationContentPutRequestContent
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
        var model = new Notifications::NotificationContentPutRequestContent
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
            Scope = Notifications::NotificationContentPutRequestContentScope.Default,
            Version = "version",
        };

        Notifications::NotificationContentPutRequestContent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NotificationContentPutRequestContentScopeTest : TestBase
{
    [Theory]
    [InlineData(Notifications::NotificationContentPutRequestContentScope.Default)]
    [InlineData(Notifications::NotificationContentPutRequestContentScope.Strict)]
    public void Validation_Works(Notifications::NotificationContentPutRequestContentScope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Notifications::NotificationContentPutRequestContentScope> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Notifications::NotificationContentPutRequestContentScope>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Notifications::NotificationContentPutRequestContentScope.Default)]
    [InlineData(Notifications::NotificationContentPutRequestContentScope.Strict)]
    public void SerializationRoundtrip_Works(
        Notifications::NotificationContentPutRequestContentScope rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Notifications::NotificationContentPutRequestContentScope> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Notifications::NotificationContentPutRequestContentScope>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Notifications::NotificationContentPutRequestContentScope>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Notifications::NotificationContentPutRequestContentScope>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
