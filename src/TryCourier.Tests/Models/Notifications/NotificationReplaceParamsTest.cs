using System;
using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Notifications;
using Models = TryCourier.Models;

namespace TryCourier.Tests.Models.Notifications;

public class NotificationReplaceParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NotificationReplaceParams
        {
            ID = "id",
            Notification = new()
            {
                Brand = new("id"),
                Content = new()
                {
                    Elements =
                    [
                        new Models::ElementalChannelNodeWithType()
                        {
                            Channels = ["string"],
                            If = "if",
                            Loop = "loop",
                            Ref = "ref",
                            Channel = "email",
                            Elements =
                            [
                                new Models::UnionMember1()
                                {
                                    Channels = ["string"],
                                    If = "if",
                                    Loop = "loop",
                                    Ref = "ref",
                                    Title = "Updated",
                                    Type = Models::UnionMember1IntersectionMember1Type.Meta,
                                },
                                new Models::UnionMember0()
                                {
                                    Channels = ["string"],
                                    If = "if",
                                    Loop = "loop",
                                    Ref = "ref",
                                    Align = Models::Align.Left,
                                    Bold = "bold",
                                    Color = "color",
                                    Content = "Updated content.",
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
                                    Type = Models::UnionMember0IntersectionMember1Type.Text,
                                },
                            ],
                            FontSize = "font_size",
                            LineHeight = "line_height",
                            Padding = "padding",
                            Raw = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Type =
                                Models::ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
                        },
                    ],
                    Version = "2022-01-01",
                },
                Name = "Updated Name",
                Routing = new("strategy_id"),
                Subscription = new("topic_id"),
                Tags = ["updated"],
                Email = new()
                {
                    Bcc = ["string"],
                    Cc = ["string"],
                    From = "from",
                    ReplyTo = "reply_to",
                },
                Alias = "alias",
            },
            State = NotificationReplaceParamsState.Published,
        };

        string expectedID = "id";
        NotificationTemplateWritePayload expectedNotification = new()
        {
            Brand = new("id"),
            Content = new()
            {
                Elements =
                [
                    new Models::ElementalChannelNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Channel = "email",
                        Elements =
                        [
                            new Models::UnionMember1()
                            {
                                Channels = ["string"],
                                If = "if",
                                Loop = "loop",
                                Ref = "ref",
                                Title = "Updated",
                                Type = Models::UnionMember1IntersectionMember1Type.Meta,
                            },
                            new Models::UnionMember0()
                            {
                                Channels = ["string"],
                                If = "if",
                                Loop = "loop",
                                Ref = "ref",
                                Align = Models::Align.Left,
                                Bold = "bold",
                                Color = "color",
                                Content = "Updated content.",
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
                                Type = Models::UnionMember0IntersectionMember1Type.Text,
                            },
                        ],
                        FontSize = "font_size",
                        LineHeight = "line_height",
                        Padding = "padding",
                        Raw = new Dictionary<string, JsonElement>()
                        {
                            { "foo", JsonSerializer.SerializeToElement("bar") },
                        },
                        Type = Models::ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
                    },
                ],
                Version = "2022-01-01",
            },
            Name = "Updated Name",
            Routing = new("strategy_id"),
            Subscription = new("topic_id"),
            Tags = ["updated"],
            Email = new()
            {
                Bcc = ["string"],
                Cc = ["string"],
                From = "from",
                ReplyTo = "reply_to",
            },
            Alias = "alias",
        };
        ApiEnum<string, NotificationReplaceParamsState> expectedState =
            NotificationReplaceParamsState.Published;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedNotification, parameters.Notification);
        Assert.Equal(expectedState, parameters.State);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new NotificationReplaceParams
        {
            ID = "id",
            Notification = new()
            {
                Brand = new("id"),
                Content = new()
                {
                    Elements =
                    [
                        new Models::ElementalChannelNodeWithType()
                        {
                            Channels = ["string"],
                            If = "if",
                            Loop = "loop",
                            Ref = "ref",
                            Channel = "email",
                            Elements =
                            [
                                new Models::UnionMember1()
                                {
                                    Channels = ["string"],
                                    If = "if",
                                    Loop = "loop",
                                    Ref = "ref",
                                    Title = "Updated",
                                    Type = Models::UnionMember1IntersectionMember1Type.Meta,
                                },
                                new Models::UnionMember0()
                                {
                                    Channels = ["string"],
                                    If = "if",
                                    Loop = "loop",
                                    Ref = "ref",
                                    Align = Models::Align.Left,
                                    Bold = "bold",
                                    Color = "color",
                                    Content = "Updated content.",
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
                                    Type = Models::UnionMember0IntersectionMember1Type.Text,
                                },
                            ],
                            FontSize = "font_size",
                            LineHeight = "line_height",
                            Padding = "padding",
                            Raw = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Type =
                                Models::ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
                        },
                    ],
                    Version = "2022-01-01",
                },
                Name = "Updated Name",
                Routing = new("strategy_id"),
                Subscription = new("topic_id"),
                Tags = ["updated"],
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

        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new NotificationReplaceParams
        {
            ID = "id",
            Notification = new()
            {
                Brand = new("id"),
                Content = new()
                {
                    Elements =
                    [
                        new Models::ElementalChannelNodeWithType()
                        {
                            Channels = ["string"],
                            If = "if",
                            Loop = "loop",
                            Ref = "ref",
                            Channel = "email",
                            Elements =
                            [
                                new Models::UnionMember1()
                                {
                                    Channels = ["string"],
                                    If = "if",
                                    Loop = "loop",
                                    Ref = "ref",
                                    Title = "Updated",
                                    Type = Models::UnionMember1IntersectionMember1Type.Meta,
                                },
                                new Models::UnionMember0()
                                {
                                    Channels = ["string"],
                                    If = "if",
                                    Loop = "loop",
                                    Ref = "ref",
                                    Align = Models::Align.Left,
                                    Bold = "bold",
                                    Color = "color",
                                    Content = "Updated content.",
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
                                    Type = Models::UnionMember0IntersectionMember1Type.Text,
                                },
                            ],
                            FontSize = "font_size",
                            LineHeight = "line_height",
                            Padding = "padding",
                            Raw = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Type =
                                Models::ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
                        },
                    ],
                    Version = "2022-01-01",
                },
                Name = "Updated Name",
                Routing = new("strategy_id"),
                Subscription = new("topic_id"),
                Tags = ["updated"],
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

        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
    }

    [Fact]
    public void Url_Works()
    {
        NotificationReplaceParams parameters = new()
        {
            ID = "id",
            Notification = new()
            {
                Brand = new("id"),
                Content = new()
                {
                    Elements =
                    [
                        new Models::ElementalChannelNodeWithType()
                        {
                            Channels = ["string"],
                            If = "if",
                            Loop = "loop",
                            Ref = "ref",
                            Channel = "email",
                            Elements =
                            [
                                new Models::UnionMember1()
                                {
                                    Channels = ["string"],
                                    If = "if",
                                    Loop = "loop",
                                    Ref = "ref",
                                    Title = "Updated",
                                    Type = Models::UnionMember1IntersectionMember1Type.Meta,
                                },
                                new Models::UnionMember0()
                                {
                                    Channels = ["string"],
                                    If = "if",
                                    Loop = "loop",
                                    Ref = "ref",
                                    Align = Models::Align.Left,
                                    Bold = "bold",
                                    Color = "color",
                                    Content = "Updated content.",
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
                                    Type = Models::UnionMember0IntersectionMember1Type.Text,
                                },
                            ],
                            FontSize = "font_size",
                            LineHeight = "line_height",
                            Padding = "padding",
                            Raw = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Type =
                                Models::ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
                        },
                    ],
                    Version = "2022-01-01",
                },
                Name = "Updated Name",
                Routing = new("strategy_id"),
                Subscription = new("topic_id"),
                Tags = ["updated"],
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

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.courier.com/notifications/id"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NotificationReplaceParams
        {
            ID = "id",
            Notification = new()
            {
                Brand = new("id"),
                Content = new()
                {
                    Elements =
                    [
                        new Models::ElementalChannelNodeWithType()
                        {
                            Channels = ["string"],
                            If = "if",
                            Loop = "loop",
                            Ref = "ref",
                            Channel = "email",
                            Elements =
                            [
                                new Models::UnionMember1()
                                {
                                    Channels = ["string"],
                                    If = "if",
                                    Loop = "loop",
                                    Ref = "ref",
                                    Title = "Updated",
                                    Type = Models::UnionMember1IntersectionMember1Type.Meta,
                                },
                                new Models::UnionMember0()
                                {
                                    Channels = ["string"],
                                    If = "if",
                                    Loop = "loop",
                                    Ref = "ref",
                                    Align = Models::Align.Left,
                                    Bold = "bold",
                                    Color = "color",
                                    Content = "Updated content.",
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
                                    Type = Models::UnionMember0IntersectionMember1Type.Text,
                                },
                            ],
                            FontSize = "font_size",
                            LineHeight = "line_height",
                            Padding = "padding",
                            Raw = new Dictionary<string, JsonElement>()
                            {
                                { "foo", JsonSerializer.SerializeToElement("bar") },
                            },
                            Type =
                                Models::ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
                        },
                    ],
                    Version = "2022-01-01",
                },
                Name = "Updated Name",
                Routing = new("strategy_id"),
                Subscription = new("topic_id"),
                Tags = ["updated"],
                Email = new()
                {
                    Bcc = ["string"],
                    Cc = ["string"],
                    From = "from",
                    ReplyTo = "reply_to",
                },
                Alias = "alias",
            },
            State = NotificationReplaceParamsState.Published,
        };

        NotificationReplaceParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class NotificationReplaceParamsStateTest : TestBase
{
    [Theory]
    [InlineData(NotificationReplaceParamsState.Draft)]
    [InlineData(NotificationReplaceParamsState.Published)]
    public void Validation_Works(NotificationReplaceParamsState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NotificationReplaceParamsState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NotificationReplaceParamsState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(NotificationReplaceParamsState.Draft)]
    [InlineData(NotificationReplaceParamsState.Published)]
    public void SerializationRoundtrip_Works(NotificationReplaceParamsState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, NotificationReplaceParamsState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NotificationReplaceParamsState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, NotificationReplaceParamsState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, NotificationReplaceParamsState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
