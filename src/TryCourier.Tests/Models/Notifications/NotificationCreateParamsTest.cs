using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models.Notifications;
using Models = TryCourier.Models;

namespace TryCourier.Tests.Models.Notifications;

public class NotificationCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NotificationCreateParams
        {
            Notification = new()
            {
                Brand = new("bnd_01kx4mrd0pfzw8wt7pn7p2fzag"),
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
                                    Title = "Welcome!",
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
                                    Content = "Hello {{data.name}}.",
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
                Name = "Welcome Email",
                Routing = new("rs_01kx4h2jdafq8bk9amzvy6hbv0"),
                Subscription = new("pt_01kx4h2jdafq8bk9a26x0kvd1t"),
                Tags = ["onboarding", "welcome"],
                Email = new()
                {
                    Bcc = ["string"],
                    Cc = ["string"],
                    From = "from",
                    ReplyTo = "reply_to",
                },
                Alias = "welcome",
            },
            State = State.Draft,
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",
        };

        NotificationTemplateWritePayload expectedNotification = new()
        {
            Brand = new("bnd_01kx4mrd0pfzw8wt7pn7p2fzag"),
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
                                Title = "Welcome!",
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
                                Content = "Hello {{data.name}}.",
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
            Name = "Welcome Email",
            Routing = new("rs_01kx4h2jdafq8bk9amzvy6hbv0"),
            Subscription = new("pt_01kx4h2jdafq8bk9a26x0kvd1t"),
            Tags = ["onboarding", "welcome"],
            Email = new()
            {
                Bcc = ["string"],
                Cc = ["string"],
                From = "from",
                ReplyTo = "reply_to",
            },
            Alias = "welcome",
        };
        ApiEnum<string, State> expectedState = State.Draft;
        string expectedIdempotencyKey = "order-ORD-456-user-123";
        string expectedXIdempotencyExpiration = "1785312000";

        Assert.Equal(expectedNotification, parameters.Notification);
        Assert.Equal(expectedState, parameters.State);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXIdempotencyExpiration, parameters.XIdempotencyExpiration);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new NotificationCreateParams
        {
            Notification = new()
            {
                Brand = new("bnd_01kx4mrd0pfzw8wt7pn7p2fzag"),
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
                                    Title = "Welcome!",
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
                                    Content = "Hello {{data.name}}.",
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
                Name = "Welcome Email",
                Routing = new("rs_01kx4h2jdafq8bk9amzvy6hbv0"),
                Subscription = new("pt_01kx4h2jdafq8bk9a26x0kvd1t"),
                Tags = ["onboarding", "welcome"],
                Email = new()
                {
                    Bcc = ["string"],
                    Cc = ["string"],
                    From = "from",
                    ReplyTo = "reply_to",
                },
                Alias = "welcome",
            },
        };

        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XIdempotencyExpiration);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-idempotency-expiration"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new NotificationCreateParams
        {
            Notification = new()
            {
                Brand = new("bnd_01kx4mrd0pfzw8wt7pn7p2fzag"),
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
                                    Title = "Welcome!",
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
                                    Content = "Hello {{data.name}}.",
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
                Name = "Welcome Email",
                Routing = new("rs_01kx4h2jdafq8bk9amzvy6hbv0"),
                Subscription = new("pt_01kx4h2jdafq8bk9a26x0kvd1t"),
                Tags = ["onboarding", "welcome"],
                Email = new()
                {
                    Bcc = ["string"],
                    Cc = ["string"],
                    From = "from",
                    ReplyTo = "reply_to",
                },
                Alias = "welcome",
            },

            // Null should be interpreted as omitted for these properties
            State = null,
            IdempotencyKey = null,
            XIdempotencyExpiration = null,
        };

        Assert.Null(parameters.State);
        Assert.False(parameters.RawBodyData.ContainsKey("state"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XIdempotencyExpiration);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-idempotency-expiration"));
    }

    [Fact]
    public void Url_Works()
    {
        NotificationCreateParams parameters = new()
        {
            Notification = new()
            {
                Brand = new("bnd_01kx4mrd0pfzw8wt7pn7p2fzag"),
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
                                    Title = "Welcome!",
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
                                    Content = "Hello {{data.name}}.",
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
                Name = "Welcome Email",
                Routing = new("rs_01kx4h2jdafq8bk9amzvy6hbv0"),
                Subscription = new("pt_01kx4h2jdafq8bk9a26x0kvd1t"),
                Tags = ["onboarding", "welcome"],
                Email = new()
                {
                    Bcc = ["string"],
                    Cc = ["string"],
                    From = "from",
                    ReplyTo = "reply_to",
                },
                Alias = "welcome",
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.courier.com/notifications"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        NotificationCreateParams parameters = new()
        {
            Notification = new()
            {
                Brand = new("bnd_01kx4mrd0pfzw8wt7pn7p2fzag"),
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
                                    Title = "Welcome!",
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
                                    Content = "Hello {{data.name}}.",
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
                Name = "Welcome Email",
                Routing = new("rs_01kx4h2jdafq8bk9amzvy6hbv0"),
                Subscription = new("pt_01kx4h2jdafq8bk9a26x0kvd1t"),
                Tags = ["onboarding", "welcome"],
                Email = new()
                {
                    Bcc = ["string"],
                    Cc = ["string"],
                    From = "from",
                    ReplyTo = "reply_to",
                },
                Alias = "welcome",
            },
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(
            ["order-ORD-456-user-123"],
            requestMessage.Headers.GetValues("Idempotency-Key")
        );
        Assert.Equal(["1785312000"], requestMessage.Headers.GetValues("x-idempotency-expiration"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NotificationCreateParams
        {
            Notification = new()
            {
                Brand = new("bnd_01kx4mrd0pfzw8wt7pn7p2fzag"),
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
                                    Title = "Welcome!",
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
                                    Content = "Hello {{data.name}}.",
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
                Name = "Welcome Email",
                Routing = new("rs_01kx4h2jdafq8bk9amzvy6hbv0"),
                Subscription = new("pt_01kx4h2jdafq8bk9a26x0kvd1t"),
                Tags = ["onboarding", "welcome"],
                Email = new()
                {
                    Bcc = ["string"],
                    Cc = ["string"],
                    From = "from",
                    ReplyTo = "reply_to",
                },
                Alias = "welcome",
            },
            State = State.Draft,
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",
        };

        NotificationCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class StateTest : TestBase
{
    [Theory]
    [InlineData(State.Draft)]
    [InlineData(State.Published)]
    public void Validation_Works(State rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, State> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(State.Draft)]
    [InlineData(State.Published)]
    public void SerializationRoundtrip_Works(State rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, State> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
