using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;
using Notifications = TryCourier.Models.Notifications;

namespace TryCourier.Tests.Models.Notifications;

public class NotificationTemplateWritePayloadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Notifications::NotificationTemplateWritePayload
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

        Notifications::Brand expectedBrand = new("id");
        ElementalContent expectedContent = new()
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
            Version = "version",
        };
        string expectedName = "name";
        Notifications::Routing expectedRouting = new("strategy_id");
        Notifications::Subscription expectedSubscription = new("topic_id");
        List<string> expectedTags = ["string"];
        Notifications::NotificationTemplateEmail expectedEmail = new()
        {
            Bcc = ["string"],
            Cc = ["string"],
            From = "from",
            ReplyTo = "reply_to",
        };
        string expectedAlias = "alias";

        Assert.Equal(expectedBrand, model.Brand);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedRouting, model.Routing);
        Assert.Equal(expectedSubscription, model.Subscription);
        Assert.Equal(expectedTags.Count, model.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], model.Tags[i]);
        }
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedAlias, model.Alias);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Notifications::NotificationTemplateWritePayload
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Notifications::NotificationTemplateWritePayload>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Notifications::NotificationTemplateWritePayload
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Notifications::NotificationTemplateWritePayload>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        Notifications::Brand expectedBrand = new("id");
        ElementalContent expectedContent = new()
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
            Version = "version",
        };
        string expectedName = "name";
        Notifications::Routing expectedRouting = new("strategy_id");
        Notifications::Subscription expectedSubscription = new("topic_id");
        List<string> expectedTags = ["string"];
        Notifications::NotificationTemplateEmail expectedEmail = new()
        {
            Bcc = ["string"],
            Cc = ["string"],
            From = "from",
            ReplyTo = "reply_to",
        };
        string expectedAlias = "alias";

        Assert.Equal(expectedBrand, deserialized.Brand);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedRouting, deserialized.Routing);
        Assert.Equal(expectedSubscription, deserialized.Subscription);
        Assert.Equal(expectedTags.Count, deserialized.Tags.Count);
        for (int i = 0; i < expectedTags.Count; i++)
        {
            Assert.Equal(expectedTags[i], deserialized.Tags[i]);
        }
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedAlias, deserialized.Alias);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Notifications::NotificationTemplateWritePayload
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

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Notifications::NotificationTemplateWritePayload
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
        };

        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Alias);
        Assert.False(model.RawData.ContainsKey("alias"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Notifications::NotificationTemplateWritePayload
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Notifications::NotificationTemplateWritePayload
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

            Email = null,
            Alias = null,
        };

        Assert.Null(model.Email);
        Assert.True(model.RawData.ContainsKey("email"));
        Assert.Null(model.Alias);
        Assert.True(model.RawData.ContainsKey("alias"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Notifications::NotificationTemplateWritePayload
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

            Email = null,
            Alias = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Notifications::NotificationTemplateWritePayload
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

        Notifications::NotificationTemplateWritePayload copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NotificationTemplateAliasWriteFieldsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Notifications::NotificationTemplateAliasWriteFields { Alias = "alias" };

        string expectedAlias = "alias";

        Assert.Equal(expectedAlias, model.Alias);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Notifications::NotificationTemplateAliasWriteFields { Alias = "alias" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Notifications::NotificationTemplateAliasWriteFields>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Notifications::NotificationTemplateAliasWriteFields { Alias = "alias" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Notifications::NotificationTemplateAliasWriteFields>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedAlias = "alias";

        Assert.Equal(expectedAlias, deserialized.Alias);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Notifications::NotificationTemplateAliasWriteFields { Alias = "alias" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Notifications::NotificationTemplateAliasWriteFields { };

        Assert.Null(model.Alias);
        Assert.False(model.RawData.ContainsKey("alias"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Notifications::NotificationTemplateAliasWriteFields { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Notifications::NotificationTemplateAliasWriteFields { Alias = null };

        Assert.Null(model.Alias);
        Assert.True(model.RawData.ContainsKey("alias"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Notifications::NotificationTemplateAliasWriteFields { Alias = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Notifications::NotificationTemplateAliasWriteFields { Alias = "alias" };

        Notifications::NotificationTemplateAliasWriteFields copied = new(model);

        Assert.Equal(model, copied);
    }
}
