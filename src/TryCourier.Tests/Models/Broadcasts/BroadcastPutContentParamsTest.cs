using System;
using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Broadcasts;
using Models = TryCourier.Models;
using Notifications = TryCourier.Models.Notifications;

namespace TryCourier.Tests.Models.Broadcasts;

public class BroadcastPutContentParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BroadcastPutContentParams
        {
            BroadcastID = "broadcastId",
            Content = new()
            {
                Elements =
                [
                    new Models::ElementalMetaNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Title = "Spring Sale is here",
                        Type = Models::ElementalMetaNodeWithTypeIntersectionMember1Type.Meta,
                    },
                    new Models::ElementalTextNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Align = Models::Align.Left,
                        Bold = "bold",
                        Color = "color",
                        Content = "Hello! Check out our spring sale.",
                        FontSize = "font_size",
                        Format = Models::Format.Markdown,
                        Italic = "italic",
                        LineHeight = "line_height",
                        Locales = new Dictionary<string, Models::LocalesItem>()
                        {
                            { "foo", new("content") },
                        },
                        Strikethrough = "strikethrough",
                        TextStyle = Models::TextStyle.Text,
                        Underline = "underline",
                        Type = Models::ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Scope = Scope.Default,
                Version = "2022-01-01",
            },
            State = Notifications::NotificationTemplateState.Draft,
        };

        string expectedBroadcastID = "broadcastId";
        Content expectedContent = new()
        {
            Elements =
            [
                new Models::ElementalMetaNodeWithType()
                {
                    Channels = ["string"],
                    If = "if",
                    Loop = "loop",
                    Ref = "ref",
                    Title = "Spring Sale is here",
                    Type = Models::ElementalMetaNodeWithTypeIntersectionMember1Type.Meta,
                },
                new Models::ElementalTextNodeWithType()
                {
                    Channels = ["string"],
                    If = "if",
                    Loop = "loop",
                    Ref = "ref",
                    Align = Models::Align.Left,
                    Bold = "bold",
                    Color = "color",
                    Content = "Hello! Check out our spring sale.",
                    FontSize = "font_size",
                    Format = Models::Format.Markdown,
                    Italic = "italic",
                    LineHeight = "line_height",
                    Locales = new Dictionary<string, Models::LocalesItem>()
                    {
                        { "foo", new("content") },
                    },
                    Strikethrough = "strikethrough",
                    TextStyle = Models::TextStyle.Text,
                    Underline = "underline",
                    Type = Models::ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                },
            ],
            Scope = Scope.Default,
            Version = "2022-01-01",
        };
        ApiEnum<string, Notifications::NotificationTemplateState> expectedState =
            Notifications::NotificationTemplateState.Draft;

        Assert.Equal(expectedBroadcastID, parameters.BroadcastID);
        Assert.Equal(expectedContent, parameters.Content);
        Assert.Equal(expectedState, parameters.State);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BroadcastPutContentParams
        {
            BroadcastID = "broadcastId",
            Content = new()
            {
                Elements =
                [
                    new Models::ElementalMetaNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Title = "Spring Sale is here",
                        Type = Models::ElementalMetaNodeWithTypeIntersectionMember1Type.Meta,
                    },
                    new Models::ElementalTextNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Align = Models::Align.Left,
                        Bold = "bold",
                        Color = "color",
                        Content = "Hello! Check out our spring sale.",
                        FontSize = "font_size",
                        Format = Models::Format.Markdown,
                        Italic = "italic",
                        LineHeight = "line_height",
                        Locales = new Dictionary<string, Models::LocalesItem>()
                        {
                            { "foo", new("content") },
                        },
                        Strikethrough = "strikethrough",
                        TextStyle = Models::TextStyle.Text,
                        Underline = "underline",
                        Type = Models::ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Scope = Scope.Default,
                Version = "2022-01-01",
            },
        };

        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BroadcastPutContentParams
        {
            BroadcastID = "broadcastId",
            Content = new()
            {
                Elements =
                [
                    new Models::ElementalMetaNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Title = "Spring Sale is here",
                        Type = Models::ElementalMetaNodeWithTypeIntersectionMember1Type.Meta,
                    },
                    new Models::ElementalTextNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Align = Models::Align.Left,
                        Bold = "bold",
                        Color = "color",
                        Content = "Hello! Check out our spring sale.",
                        FontSize = "font_size",
                        Format = Models::Format.Markdown,
                        Italic = "italic",
                        LineHeight = "line_height",
                        Locales = new Dictionary<string, Models::LocalesItem>()
                        {
                            { "foo", new("content") },
                        },
                        Strikethrough = "strikethrough",
                        TextStyle = Models::TextStyle.Text,
                        Underline = "underline",
                        Type = Models::ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Scope = Scope.Default,
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
        BroadcastPutContentParams parameters = new()
        {
            BroadcastID = "broadcastId",
            Content = new()
            {
                Elements =
                [
                    new Models::ElementalMetaNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Title = "Spring Sale is here",
                        Type = Models::ElementalMetaNodeWithTypeIntersectionMember1Type.Meta,
                    },
                    new Models::ElementalTextNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Align = Models::Align.Left,
                        Bold = "bold",
                        Color = "color",
                        Content = "Hello! Check out our spring sale.",
                        FontSize = "font_size",
                        Format = Models::Format.Markdown,
                        Italic = "italic",
                        LineHeight = "line_height",
                        Locales = new Dictionary<string, Models::LocalesItem>()
                        {
                            { "foo", new("content") },
                        },
                        Strikethrough = "strikethrough",
                        TextStyle = Models::TextStyle.Text,
                        Underline = "underline",
                        Type = Models::ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Scope = Scope.Default,
                Version = "2022-01-01",
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/broadcasts/broadcastId/content"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BroadcastPutContentParams
        {
            BroadcastID = "broadcastId",
            Content = new()
            {
                Elements =
                [
                    new Models::ElementalMetaNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Title = "Spring Sale is here",
                        Type = Models::ElementalMetaNodeWithTypeIntersectionMember1Type.Meta,
                    },
                    new Models::ElementalTextNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Align = Models::Align.Left,
                        Bold = "bold",
                        Color = "color",
                        Content = "Hello! Check out our spring sale.",
                        FontSize = "font_size",
                        Format = Models::Format.Markdown,
                        Italic = "italic",
                        LineHeight = "line_height",
                        Locales = new Dictionary<string, Models::LocalesItem>()
                        {
                            { "foo", new("content") },
                        },
                        Strikethrough = "strikethrough",
                        TextStyle = Models::TextStyle.Text,
                        Underline = "underline",
                        Type = Models::ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Scope = Scope.Default,
                Version = "2022-01-01",
            },
            State = Notifications::NotificationTemplateState.Draft,
        };

        BroadcastPutContentParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Content
        {
            Elements =
            [
                new Models::ElementalTextNodeWithType()
                {
                    Channels = ["string"],
                    If = "if",
                    Loop = "loop",
                    Ref = "ref",
                    Align = Models::Align.Left,
                    Bold = "bold",
                    Color = "color",
                    Content = "content",
                    FontSize = "font_size",
                    Format = Models::Format.Markdown,
                    Italic = "italic",
                    LineHeight = "line_height",
                    Locales = new Dictionary<string, Models::LocalesItem>()
                    {
                        { "foo", new("content") },
                    },
                    Strikethrough = "strikethrough",
                    TextStyle = Models::TextStyle.Text,
                    Underline = "underline",
                    Type = Models::ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                },
            ],
            Scope = Scope.Default,
            Version = "version",
        };

        List<Models::ElementalNode> expectedElements =
        [
            new Models::ElementalTextNodeWithType()
            {
                Channels = ["string"],
                If = "if",
                Loop = "loop",
                Ref = "ref",
                Align = Models::Align.Left,
                Bold = "bold",
                Color = "color",
                Content = "content",
                FontSize = "font_size",
                Format = Models::Format.Markdown,
                Italic = "italic",
                LineHeight = "line_height",
                Locales = new Dictionary<string, Models::LocalesItem>()
                {
                    { "foo", new("content") },
                },
                Strikethrough = "strikethrough",
                TextStyle = Models::TextStyle.Text,
                Underline = "underline",
                Type = Models::ElementalTextNodeWithTypeIntersectionMember1Type.Text,
            },
        ];
        ApiEnum<string, Scope> expectedScope = Scope.Default;
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
        var model = new Content
        {
            Elements =
            [
                new Models::ElementalTextNodeWithType()
                {
                    Channels = ["string"],
                    If = "if",
                    Loop = "loop",
                    Ref = "ref",
                    Align = Models::Align.Left,
                    Bold = "bold",
                    Color = "color",
                    Content = "content",
                    FontSize = "font_size",
                    Format = Models::Format.Markdown,
                    Italic = "italic",
                    LineHeight = "line_height",
                    Locales = new Dictionary<string, Models::LocalesItem>()
                    {
                        { "foo", new("content") },
                    },
                    Strikethrough = "strikethrough",
                    TextStyle = Models::TextStyle.Text,
                    Underline = "underline",
                    Type = Models::ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                },
            ],
            Scope = Scope.Default,
            Version = "version",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Content
        {
            Elements =
            [
                new Models::ElementalTextNodeWithType()
                {
                    Channels = ["string"],
                    If = "if",
                    Loop = "loop",
                    Ref = "ref",
                    Align = Models::Align.Left,
                    Bold = "bold",
                    Color = "color",
                    Content = "content",
                    FontSize = "font_size",
                    Format = Models::Format.Markdown,
                    Italic = "italic",
                    LineHeight = "line_height",
                    Locales = new Dictionary<string, Models::LocalesItem>()
                    {
                        { "foo", new("content") },
                    },
                    Strikethrough = "strikethrough",
                    TextStyle = Models::TextStyle.Text,
                    Underline = "underline",
                    Type = Models::ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                },
            ],
            Scope = Scope.Default,
            Version = "version",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Models::ElementalNode> expectedElements =
        [
            new Models::ElementalTextNodeWithType()
            {
                Channels = ["string"],
                If = "if",
                Loop = "loop",
                Ref = "ref",
                Align = Models::Align.Left,
                Bold = "bold",
                Color = "color",
                Content = "content",
                FontSize = "font_size",
                Format = Models::Format.Markdown,
                Italic = "italic",
                LineHeight = "line_height",
                Locales = new Dictionary<string, Models::LocalesItem>()
                {
                    { "foo", new("content") },
                },
                Strikethrough = "strikethrough",
                TextStyle = Models::TextStyle.Text,
                Underline = "underline",
                Type = Models::ElementalTextNodeWithTypeIntersectionMember1Type.Text,
            },
        ];
        ApiEnum<string, Scope> expectedScope = Scope.Default;
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
        var model = new Content
        {
            Elements =
            [
                new Models::ElementalTextNodeWithType()
                {
                    Channels = ["string"],
                    If = "if",
                    Loop = "loop",
                    Ref = "ref",
                    Align = Models::Align.Left,
                    Bold = "bold",
                    Color = "color",
                    Content = "content",
                    FontSize = "font_size",
                    Format = Models::Format.Markdown,
                    Italic = "italic",
                    LineHeight = "line_height",
                    Locales = new Dictionary<string, Models::LocalesItem>()
                    {
                        { "foo", new("content") },
                    },
                    Strikethrough = "strikethrough",
                    TextStyle = Models::TextStyle.Text,
                    Underline = "underline",
                    Type = Models::ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                },
            ],
            Scope = Scope.Default,
            Version = "version",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Content
        {
            Elements =
            [
                new Models::ElementalTextNodeWithType()
                {
                    Channels = ["string"],
                    If = "if",
                    Loop = "loop",
                    Ref = "ref",
                    Align = Models::Align.Left,
                    Bold = "bold",
                    Color = "color",
                    Content = "content",
                    FontSize = "font_size",
                    Format = Models::Format.Markdown,
                    Italic = "italic",
                    LineHeight = "line_height",
                    Locales = new Dictionary<string, Models::LocalesItem>()
                    {
                        { "foo", new("content") },
                    },
                    Strikethrough = "strikethrough",
                    TextStyle = Models::TextStyle.Text,
                    Underline = "underline",
                    Type = Models::ElementalTextNodeWithTypeIntersectionMember1Type.Text,
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
        var model = new Content
        {
            Elements =
            [
                new Models::ElementalTextNodeWithType()
                {
                    Channels = ["string"],
                    If = "if",
                    Loop = "loop",
                    Ref = "ref",
                    Align = Models::Align.Left,
                    Bold = "bold",
                    Color = "color",
                    Content = "content",
                    FontSize = "font_size",
                    Format = Models::Format.Markdown,
                    Italic = "italic",
                    LineHeight = "line_height",
                    Locales = new Dictionary<string, Models::LocalesItem>()
                    {
                        { "foo", new("content") },
                    },
                    Strikethrough = "strikethrough",
                    TextStyle = Models::TextStyle.Text,
                    Underline = "underline",
                    Type = Models::ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Content
        {
            Elements =
            [
                new Models::ElementalTextNodeWithType()
                {
                    Channels = ["string"],
                    If = "if",
                    Loop = "loop",
                    Ref = "ref",
                    Align = Models::Align.Left,
                    Bold = "bold",
                    Color = "color",
                    Content = "content",
                    FontSize = "font_size",
                    Format = Models::Format.Markdown,
                    Italic = "italic",
                    LineHeight = "line_height",
                    Locales = new Dictionary<string, Models::LocalesItem>()
                    {
                        { "foo", new("content") },
                    },
                    Strikethrough = "strikethrough",
                    TextStyle = Models::TextStyle.Text,
                    Underline = "underline",
                    Type = Models::ElementalTextNodeWithTypeIntersectionMember1Type.Text,
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
        var model = new Content
        {
            Elements =
            [
                new Models::ElementalTextNodeWithType()
                {
                    Channels = ["string"],
                    If = "if",
                    Loop = "loop",
                    Ref = "ref",
                    Align = Models::Align.Left,
                    Bold = "bold",
                    Color = "color",
                    Content = "content",
                    FontSize = "font_size",
                    Format = Models::Format.Markdown,
                    Italic = "italic",
                    LineHeight = "line_height",
                    Locales = new Dictionary<string, Models::LocalesItem>()
                    {
                        { "foo", new("content") },
                    },
                    Strikethrough = "strikethrough",
                    TextStyle = Models::TextStyle.Text,
                    Underline = "underline",
                    Type = Models::ElementalTextNodeWithTypeIntersectionMember1Type.Text,
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
        var model = new Content
        {
            Elements =
            [
                new Models::ElementalTextNodeWithType()
                {
                    Channels = ["string"],
                    If = "if",
                    Loop = "loop",
                    Ref = "ref",
                    Align = Models::Align.Left,
                    Bold = "bold",
                    Color = "color",
                    Content = "content",
                    FontSize = "font_size",
                    Format = Models::Format.Markdown,
                    Italic = "italic",
                    LineHeight = "line_height",
                    Locales = new Dictionary<string, Models::LocalesItem>()
                    {
                        { "foo", new("content") },
                    },
                    Strikethrough = "strikethrough",
                    TextStyle = Models::TextStyle.Text,
                    Underline = "underline",
                    Type = Models::ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                },
            ],
            Scope = Scope.Default,
            Version = "version",
        };

        Content copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ScopeTest : TestBase
{
    [Theory]
    [InlineData(Scope.Default)]
    [InlineData(Scope.Strict)]
    public void Validation_Works(Scope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Scope> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Scope>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Scope.Default)]
    [InlineData(Scope.Strict)]
    public void SerializationRoundtrip_Works(Scope rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Scope> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Scope>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Scope>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Scope>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
