using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;
using Notifications = TryCourier.Models.Notifications;

namespace TryCourier.Tests.Models.Notifications;

public class NotificationTemplatePayloadTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Notifications::NotificationTemplatePayload
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Notifications::NotificationTemplatePayload
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Notifications::NotificationTemplatePayload>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Notifications::NotificationTemplatePayload
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Notifications::NotificationTemplatePayload>(
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Notifications::NotificationTemplatePayload
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Notifications::NotificationTemplatePayload
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
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Notifications::NotificationTemplatePayload
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
        var model = new Notifications::NotificationTemplatePayload
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
        };

        Assert.Null(model.Email);
        Assert.True(model.RawData.ContainsKey("email"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Notifications::NotificationTemplatePayload
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Notifications::NotificationTemplatePayload
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
        };

        Notifications::NotificationTemplatePayload copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BrandTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Notifications::Brand { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, model.ID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Notifications::Brand { ID = "id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Notifications::Brand>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Notifications::Brand { ID = "id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Notifications::Brand>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";

        Assert.Equal(expectedID, deserialized.ID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Notifications::Brand { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Notifications::Brand { ID = "id" };

        Notifications::Brand copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RoutingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Notifications::Routing { StrategyID = "strategy_id" };

        string expectedStrategyID = "strategy_id";

        Assert.Equal(expectedStrategyID, model.StrategyID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Notifications::Routing { StrategyID = "strategy_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Notifications::Routing>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Notifications::Routing { StrategyID = "strategy_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Notifications::Routing>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedStrategyID = "strategy_id";

        Assert.Equal(expectedStrategyID, deserialized.StrategyID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Notifications::Routing { StrategyID = "strategy_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Notifications::Routing { StrategyID = "strategy_id" };

        Notifications::Routing copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Notifications::Subscription { TopicID = "topic_id" };

        string expectedTopicID = "topic_id";

        Assert.Equal(expectedTopicID, model.TopicID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Notifications::Subscription { TopicID = "topic_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Notifications::Subscription>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Notifications::Subscription { TopicID = "topic_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Notifications::Subscription>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedTopicID = "topic_id";

        Assert.Equal(expectedTopicID, deserialized.TopicID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Notifications::Subscription { TopicID = "topic_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Notifications::Subscription { TopicID = "topic_id" };

        Notifications::Subscription copied = new(model);

        Assert.Equal(model, copied);
    }
}
