using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Exceptions;
using TryCourier.Models;
using Notifications = TryCourier.Models.Notifications;

namespace TryCourier.Tests.Models.Notifications;

public class NotificationTemplateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Notifications::NotificationTemplateResponse
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
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = Notifications::NotificationTemplateResponseFieldsState.Draft,
            Alias = "string",
            Updated = 0,
            Updater = "updater",
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
        string expectedID = "id";
        long expectedCreated = 0;
        string expectedCreator = "creator";
        ApiEnum<string, Notifications::NotificationTemplateResponseFieldsState> expectedState =
            Notifications::NotificationTemplateResponseFieldsState.Draft;
        Notifications::NotificationTemplateAlias expectedAlias = "string";
        long expectedUpdated = 0;
        string expectedUpdater = "updater";

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
        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedCreator, model.Creator);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedAlias, model.Alias);
        Assert.Equal(expectedUpdated, model.Updated);
        Assert.Equal(expectedUpdater, model.Updater);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Notifications::NotificationTemplateResponse
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
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = Notifications::NotificationTemplateResponseFieldsState.Draft,
            Alias = "string",
            Updated = 0,
            Updater = "updater",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Notifications::NotificationTemplateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Notifications::NotificationTemplateResponse
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
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = Notifications::NotificationTemplateResponseFieldsState.Draft,
            Alias = "string",
            Updated = 0,
            Updater = "updater",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Notifications::NotificationTemplateResponse>(
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
        string expectedID = "id";
        long expectedCreated = 0;
        string expectedCreator = "creator";
        ApiEnum<string, Notifications::NotificationTemplateResponseFieldsState> expectedState =
            Notifications::NotificationTemplateResponseFieldsState.Draft;
        Notifications::NotificationTemplateAlias expectedAlias = "string";
        long expectedUpdated = 0;
        string expectedUpdater = "updater";

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
        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreated, deserialized.Created);
        Assert.Equal(expectedCreator, deserialized.Creator);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedAlias, deserialized.Alias);
        Assert.Equal(expectedUpdated, deserialized.Updated);
        Assert.Equal(expectedUpdater, deserialized.Updater);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Notifications::NotificationTemplateResponse
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
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = Notifications::NotificationTemplateResponseFieldsState.Draft,
            Alias = "string",
            Updated = 0,
            Updater = "updater",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Notifications::NotificationTemplateResponse
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
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = Notifications::NotificationTemplateResponseFieldsState.Draft,
        };

        Assert.Null(model.Alias);
        Assert.False(model.RawData.ContainsKey("alias"));
        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
        Assert.Null(model.Updater);
        Assert.False(model.RawData.ContainsKey("updater"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Notifications::NotificationTemplateResponse
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
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = Notifications::NotificationTemplateResponseFieldsState.Draft,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Notifications::NotificationTemplateResponse
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
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = Notifications::NotificationTemplateResponseFieldsState.Draft,

            // Null should be interpreted as omitted for these properties
            Alias = null,
            Updated = null,
            Updater = null,
        };

        Assert.Null(model.Alias);
        Assert.False(model.RawData.ContainsKey("alias"));
        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
        Assert.Null(model.Updater);
        Assert.False(model.RawData.ContainsKey("updater"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Notifications::NotificationTemplateResponse
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
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = Notifications::NotificationTemplateResponseFieldsState.Draft,

            // Null should be interpreted as omitted for these properties
            Alias = null,
            Updated = null,
            Updater = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Notifications::NotificationTemplateResponse
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
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = Notifications::NotificationTemplateResponseFieldsState.Draft,
            Alias = "string",
            Updated = 0,
            Updater = "updater",
        };

        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Notifications::NotificationTemplateResponse
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
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = Notifications::NotificationTemplateResponseFieldsState.Draft,
            Alias = "string",
            Updated = 0,
            Updater = "updater",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Notifications::NotificationTemplateResponse
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
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = Notifications::NotificationTemplateResponseFieldsState.Draft,
            Alias = "string",
            Updated = 0,
            Updater = "updater",

            Email = null,
        };

        Assert.Null(model.Email);
        Assert.True(model.RawData.ContainsKey("email"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Notifications::NotificationTemplateResponse
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
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = Notifications::NotificationTemplateResponseFieldsState.Draft,
            Alias = "string",
            Updated = 0,
            Updater = "updater",

            Email = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Notifications::NotificationTemplateResponse
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
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = Notifications::NotificationTemplateResponseFieldsState.Draft,
            Alias = "string",
            Updated = 0,
            Updater = "updater",
        };

        Notifications::NotificationTemplateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NotificationTemplateResponseFieldsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Notifications::NotificationTemplateResponseFields
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = Notifications::NotificationTemplateResponseFieldsState.Draft,
            Alias = "string",
            Updated = 0,
            Updater = "updater",
        };

        string expectedID = "id";
        long expectedCreated = 0;
        string expectedCreator = "creator";
        ApiEnum<string, Notifications::NotificationTemplateResponseFieldsState> expectedState =
            Notifications::NotificationTemplateResponseFieldsState.Draft;
        Notifications::NotificationTemplateAlias expectedAlias = "string";
        long expectedUpdated = 0;
        string expectedUpdater = "updater";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedCreator, model.Creator);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedAlias, model.Alias);
        Assert.Equal(expectedUpdated, model.Updated);
        Assert.Equal(expectedUpdater, model.Updater);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Notifications::NotificationTemplateResponseFields
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = Notifications::NotificationTemplateResponseFieldsState.Draft,
            Alias = "string",
            Updated = 0,
            Updater = "updater",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Notifications::NotificationTemplateResponseFields>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Notifications::NotificationTemplateResponseFields
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = Notifications::NotificationTemplateResponseFieldsState.Draft,
            Alias = "string",
            Updated = 0,
            Updater = "updater",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Notifications::NotificationTemplateResponseFields>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedCreated = 0;
        string expectedCreator = "creator";
        ApiEnum<string, Notifications::NotificationTemplateResponseFieldsState> expectedState =
            Notifications::NotificationTemplateResponseFieldsState.Draft;
        Notifications::NotificationTemplateAlias expectedAlias = "string";
        long expectedUpdated = 0;
        string expectedUpdater = "updater";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreated, deserialized.Created);
        Assert.Equal(expectedCreator, deserialized.Creator);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedAlias, deserialized.Alias);
        Assert.Equal(expectedUpdated, deserialized.Updated);
        Assert.Equal(expectedUpdater, deserialized.Updater);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Notifications::NotificationTemplateResponseFields
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = Notifications::NotificationTemplateResponseFieldsState.Draft,
            Alias = "string",
            Updated = 0,
            Updater = "updater",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Notifications::NotificationTemplateResponseFields
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = Notifications::NotificationTemplateResponseFieldsState.Draft,
        };

        Assert.Null(model.Alias);
        Assert.False(model.RawData.ContainsKey("alias"));
        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
        Assert.Null(model.Updater);
        Assert.False(model.RawData.ContainsKey("updater"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Notifications::NotificationTemplateResponseFields
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = Notifications::NotificationTemplateResponseFieldsState.Draft,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Notifications::NotificationTemplateResponseFields
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = Notifications::NotificationTemplateResponseFieldsState.Draft,

            // Null should be interpreted as omitted for these properties
            Alias = null,
            Updated = null,
            Updater = null,
        };

        Assert.Null(model.Alias);
        Assert.False(model.RawData.ContainsKey("alias"));
        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
        Assert.Null(model.Updater);
        Assert.False(model.RawData.ContainsKey("updater"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Notifications::NotificationTemplateResponseFields
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = Notifications::NotificationTemplateResponseFieldsState.Draft,

            // Null should be interpreted as omitted for these properties
            Alias = null,
            Updated = null,
            Updater = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Notifications::NotificationTemplateResponseFields
        {
            ID = "id",
            Created = 0,
            Creator = "creator",
            State = Notifications::NotificationTemplateResponseFieldsState.Draft,
            Alias = "string",
            Updated = 0,
            Updater = "updater",
        };

        Notifications::NotificationTemplateResponseFields copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class NotificationTemplateResponseFieldsStateTest : TestBase
{
    [Theory]
    [InlineData(Notifications::NotificationTemplateResponseFieldsState.Draft)]
    [InlineData(Notifications::NotificationTemplateResponseFieldsState.Published)]
    public void Validation_Works(Notifications::NotificationTemplateResponseFieldsState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Notifications::NotificationTemplateResponseFieldsState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Notifications::NotificationTemplateResponseFieldsState>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Notifications::NotificationTemplateResponseFieldsState.Draft)]
    [InlineData(Notifications::NotificationTemplateResponseFieldsState.Published)]
    public void SerializationRoundtrip_Works(
        Notifications::NotificationTemplateResponseFieldsState rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Notifications::NotificationTemplateResponseFieldsState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Notifications::NotificationTemplateResponseFieldsState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Notifications::NotificationTemplateResponseFieldsState>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Notifications::NotificationTemplateResponseFieldsState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
