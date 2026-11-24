using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models;
using Notifications = TryCourier.Models.Notifications;

namespace TryCourier.Tests.Models.Notifications;

public class NotificationTemplateCreateRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Notifications::NotificationTemplateCreateRequest
        {
            Notification = new()
            {
                Brand = new("id"),
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
                    Version = "version",
                },
                Name = "name",
                Routing = new("strategy_id"),
                Subscription = new("topic_id"),
                Tags = ["string"],
                Email = new()
                {
                    Bcc = ["string"],
                    Cc = ["string"],
                    From = "from",
                    ReplyTo = "reply_to",
                },
                Alias = "alias",
            },
            State = Notifications::NotificationTemplateCreateRequestState.Draft,
        };

        Notifications::NotificationTemplateWritePayload expectedNotification = new()
        {
            Brand = new("id"),
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
                Version = "version",
            },
            Name = "name",
            Routing = new("strategy_id"),
            Subscription = new("topic_id"),
            Tags = ["string"],
            Email = new()
            {
                Bcc = ["string"],
                Cc = ["string"],
                From = "from",
                ReplyTo = "reply_to",
            },
            Alias = "alias",
        };
        ApiEnum<string, Notifications::NotificationTemplateCreateRequestState> expectedState =
            Notifications::NotificationTemplateCreateRequestState.Draft;

        Assert.Equal(expectedNotification, model.Notification);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Notifications::NotificationTemplateCreateRequest
        {
            Notification = new()
            {
                Brand = new("id"),
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
                    Version = "version",
                },
                Name = "name",
                Routing = new("strategy_id"),
                Subscription = new("topic_id"),
                Tags = ["string"],
                Email = new()
                {
                    Bcc = ["string"],
                    Cc = ["string"],
                    From = "from",
                    ReplyTo = "reply_to",
                },
                Alias = "alias",
            },
            State = Notifications::NotificationTemplateCreateRequestState.Draft,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Notifications::NotificationTemplateCreateRequest>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Notifications::NotificationTemplateCreateRequest
        {
            Notification = new()
            {
                Brand = new("id"),
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
                    Version = "version",
                },
                Name = "name",
                Routing = new("strategy_id"),
                Subscription = new("topic_id"),
                Tags = ["string"],
                Email = new()
                {
                    Bcc = ["string"],
                    Cc = ["string"],
                    From = "from",
                    ReplyTo = "reply_to",
                },
                Alias = "alias",
            },
            State = Notifications::NotificationTemplateCreateRequestState.Draft,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Notifications::NotificationTemplateCreateRequest>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        Notifications::NotificationTemplateWritePayload expectedNotification = new()
        {
            Brand = new("id"),
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
                Version = "version",
            },
            Name = "name",
            Routing = new("strategy_id"),
            Subscription = new("topic_id"),
            Tags = ["string"],
            Email = new()
            {
                Bcc = ["string"],
                Cc = ["string"],
                From = "from",
                ReplyTo = "reply_to",
            },
            Alias = "alias",
        };
        ApiEnum<string, Notifications::NotificationTemplateCreateRequestState> expectedState =
            Notifications::NotificationTemplateCreateRequestState.Draft;

        Assert.Equal(expectedNotification, deserialized.Notification);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Notifications::NotificationTemplateCreateRequest
        {
            Notification = new()
            {
                Brand = new("id"),
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
                    Version = "version",
                },
                Name = "name",
                Routing = new("strategy_id"),
                Subscription = new("topic_id"),
                Tags = ["string"],
                Email = new()
                {
                    Bcc = ["string"],
                    Cc = ["string"],
                    From = "from",
                    ReplyTo = "reply_to",
                },
                Alias = "alias",
            },
            State = Notifications::NotificationTemplateCreateRequestState.Draft,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Notifications::NotificationTemplateCreateRequest
        {
            Notification = new()
            {
                Brand = new("id"),
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
                    Version = "version",
                },
                Name = "name",
                Routing = new("strategy_id"),
                Subscription = new("topic_id"),
                Tags = ["string"],
                Email = new()
                {
                    Bcc = ["string"],
                    Cc = ["string"],
                    From = "from",
                    ReplyTo = "reply_to",
                },
                Alias = "alias",
            },
        };

        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Notifications::NotificationTemplateCreateRequest
        {
            Notification = new()
            {
                Brand = new("id"),
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
                    Version = "version",
                },
                Name = "name",
                Routing = new("strategy_id"),
                Subscription = new("topic_id"),
                Tags = ["string"],
                Email = new()
                {
                    Bcc = ["string"],
                    Cc = ["string"],
                    From = "from",
                    ReplyTo = "reply_to",
                },
                Alias = "alias",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Notifications::NotificationTemplateCreateRequest
        {
            Notification = new()
            {
                Brand = new("id"),
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
                    Version = "version",
                },
                Name = "name",
                Routing = new("strategy_id"),
                Subscription = new("topic_id"),
                Tags = ["string"],
                Email = new()
                {
                    Bcc = ["string"],
                    Cc = ["string"],
                    From = "from",
                    ReplyTo = "reply_to",
                },
                Alias = "alias",
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
        var model = new Notifications::NotificationTemplateCreateRequest
        {
            Notification = new()
            {
                Brand = new("id"),
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
                    Version = "version",
                },
                Name = "name",
                Routing = new("strategy_id"),
                Subscription = new("topic_id"),
                Tags = ["string"],
                Email = new()
                {
                    Bcc = ["string"],
                    Cc = ["string"],
                    From = "from",
                    ReplyTo = "reply_to",
                },
                Alias = "alias",
            },

            // Null should be interpreted as omitted for these properties
            State = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Notifications::NotificationTemplateCreateRequest
        {
            Notification = new()
            {
                Brand = new("id"),
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
                    Version = "version",
                },
                Name = "name",
                Routing = new("strategy_id"),
                Subscription = new("topic_id"),
                Tags = ["string"],
                Email = new()
                {
                    Bcc = ["string"],
                    Cc = ["string"],
                    From = "from",
                    ReplyTo = "reply_to",
                },
                Alias = "alias",
            },
            State = Notifications::NotificationTemplateCreateRequestState.Draft,
        };

        Notifications::NotificationTemplateCreateRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NotificationTemplateCreateRequestStateTest : TestBase
{
    [Theory]
    [InlineData(Notifications::NotificationTemplateCreateRequestState.Draft)]
    [InlineData(Notifications::NotificationTemplateCreateRequestState.Published)]
    public void Validation_Works(Notifications::NotificationTemplateCreateRequestState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Notifications::NotificationTemplateCreateRequestState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Notifications::NotificationTemplateCreateRequestState>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Notifications::NotificationTemplateCreateRequestState.Draft)]
    [InlineData(Notifications::NotificationTemplateCreateRequestState.Published)]
    public void SerializationRoundtrip_Works(
        Notifications::NotificationTemplateCreateRequestState rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Notifications::NotificationTemplateCreateRequestState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Notifications::NotificationTemplateCreateRequestState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Notifications::NotificationTemplateCreateRequestState>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Notifications::NotificationTemplateCreateRequestState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
