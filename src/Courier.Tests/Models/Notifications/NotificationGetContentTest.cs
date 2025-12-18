using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Notifications;

namespace Courier.Tests.Models.Notifications;

public class NotificationGetContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NotificationGetContent
        {
            Blocks =
            [
                new()
                {
                    ID = "id",
                    Type = BlockType.Action,
                    Alias = "alias",
                    Checksum = "checksum",
                    Content = "string",
                    Context = "context",
                    Locales = new Dictionary<string, Locale>() { { "foo", "string" } },
                },
            ],
            Channels =
            [
                new()
                {
                    ID = "id",
                    Checksum = "checksum",
                    Content = new() { Subject = "subject", Title = "title" },
                    Locales = new Dictionary<string, LocalesItem>()
                    {
                        {
                            "foo",
                            new() { Subject = "subject", Title = "title" }
                        },
                    },
                    Type = "type",
                },
            ],
            Checksum = "checksum",
        };

        List<Block> expectedBlocks =
        [
            new()
            {
                ID = "id",
                Type = BlockType.Action,
                Alias = "alias",
                Checksum = "checksum",
                Content = "string",
                Context = "context",
                Locales = new Dictionary<string, Locale>() { { "foo", "string" } },
            },
        ];
        List<Channel> expectedChannels =
        [
            new()
            {
                ID = "id",
                Checksum = "checksum",
                Content = new() { Subject = "subject", Title = "title" },
                Locales = new Dictionary<string, LocalesItem>()
                {
                    {
                        "foo",
                        new() { Subject = "subject", Title = "title" }
                    },
                },
                Type = "type",
            },
        ];
        string expectedChecksum = "checksum";

        Assert.NotNull(model.Blocks);
        Assert.Equal(expectedBlocks.Count, model.Blocks.Count);
        for (int i = 0; i < expectedBlocks.Count; i++)
        {
            Assert.Equal(expectedBlocks[i], model.Blocks[i]);
        }
        Assert.NotNull(model.Channels);
        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], model.Channels[i]);
        }
        Assert.Equal(expectedChecksum, model.Checksum);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NotificationGetContent
        {
            Blocks =
            [
                new()
                {
                    ID = "id",
                    Type = BlockType.Action,
                    Alias = "alias",
                    Checksum = "checksum",
                    Content = "string",
                    Context = "context",
                    Locales = new Dictionary<string, Locale>() { { "foo", "string" } },
                },
            ],
            Channels =
            [
                new()
                {
                    ID = "id",
                    Checksum = "checksum",
                    Content = new() { Subject = "subject", Title = "title" },
                    Locales = new Dictionary<string, LocalesItem>()
                    {
                        {
                            "foo",
                            new() { Subject = "subject", Title = "title" }
                        },
                    },
                    Type = "type",
                },
            ],
            Checksum = "checksum",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NotificationGetContent>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NotificationGetContent
        {
            Blocks =
            [
                new()
                {
                    ID = "id",
                    Type = BlockType.Action,
                    Alias = "alias",
                    Checksum = "checksum",
                    Content = "string",
                    Context = "context",
                    Locales = new Dictionary<string, Locale>() { { "foo", "string" } },
                },
            ],
            Channels =
            [
                new()
                {
                    ID = "id",
                    Checksum = "checksum",
                    Content = new() { Subject = "subject", Title = "title" },
                    Locales = new Dictionary<string, LocalesItem>()
                    {
                        {
                            "foo",
                            new() { Subject = "subject", Title = "title" }
                        },
                    },
                    Type = "type",
                },
            ],
            Checksum = "checksum",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NotificationGetContent>(element);
        Assert.NotNull(deserialized);

        List<Block> expectedBlocks =
        [
            new()
            {
                ID = "id",
                Type = BlockType.Action,
                Alias = "alias",
                Checksum = "checksum",
                Content = "string",
                Context = "context",
                Locales = new Dictionary<string, Locale>() { { "foo", "string" } },
            },
        ];
        List<Channel> expectedChannels =
        [
            new()
            {
                ID = "id",
                Checksum = "checksum",
                Content = new() { Subject = "subject", Title = "title" },
                Locales = new Dictionary<string, LocalesItem>()
                {
                    {
                        "foo",
                        new() { Subject = "subject", Title = "title" }
                    },
                },
                Type = "type",
            },
        ];
        string expectedChecksum = "checksum";

        Assert.NotNull(deserialized.Blocks);
        Assert.Equal(expectedBlocks.Count, deserialized.Blocks.Count);
        for (int i = 0; i < expectedBlocks.Count; i++)
        {
            Assert.Equal(expectedBlocks[i], deserialized.Blocks[i]);
        }
        Assert.NotNull(deserialized.Channels);
        Assert.Equal(expectedChannels.Count, deserialized.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], deserialized.Channels[i]);
        }
        Assert.Equal(expectedChecksum, deserialized.Checksum);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NotificationGetContent
        {
            Blocks =
            [
                new()
                {
                    ID = "id",
                    Type = BlockType.Action,
                    Alias = "alias",
                    Checksum = "checksum",
                    Content = "string",
                    Context = "context",
                    Locales = new Dictionary<string, Locale>() { { "foo", "string" } },
                },
            ],
            Channels =
            [
                new()
                {
                    ID = "id",
                    Checksum = "checksum",
                    Content = new() { Subject = "subject", Title = "title" },
                    Locales = new Dictionary<string, LocalesItem>()
                    {
                        {
                            "foo",
                            new() { Subject = "subject", Title = "title" }
                        },
                    },
                    Type = "type",
                },
            ],
            Checksum = "checksum",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NotificationGetContent { };

        Assert.Null(model.Blocks);
        Assert.False(model.RawData.ContainsKey("blocks"));
        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.Checksum);
        Assert.False(model.RawData.ContainsKey("checksum"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new NotificationGetContent { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NotificationGetContent
        {
            Blocks = null,
            Channels = null,
            Checksum = null,
        };

        Assert.Null(model.Blocks);
        Assert.True(model.RawData.ContainsKey("blocks"));
        Assert.Null(model.Channels);
        Assert.True(model.RawData.ContainsKey("channels"));
        Assert.Null(model.Checksum);
        Assert.True(model.RawData.ContainsKey("checksum"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NotificationGetContent
        {
            Blocks = null,
            Channels = null,
            Checksum = null,
        };

        model.Validate();
    }
}

public class BlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Block
        {
            ID = "id",
            Type = BlockType.Action,
            Alias = "alias",
            Checksum = "checksum",
            Content = "string",
            Context = "context",
            Locales = new Dictionary<string, Locale>() { { "foo", "string" } },
        };

        string expectedID = "id";
        ApiEnum<string, BlockType> expectedType = BlockType.Action;
        string expectedAlias = "alias";
        string expectedChecksum = "checksum";
        Content expectedContent = "string";
        string expectedContext = "context";
        Dictionary<string, Locale> expectedLocales = new() { { "foo", "string" } };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedAlias, model.Alias);
        Assert.Equal(expectedChecksum, model.Checksum);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedContext, model.Context);
        Assert.Equal(expectedLocales.Count, model.Locales.Count);
        foreach (var item in expectedLocales)
        {
            Assert.True(model.Locales.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Locales[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Block
        {
            ID = "id",
            Type = BlockType.Action,
            Alias = "alias",
            Checksum = "checksum",
            Content = "string",
            Context = "context",
            Locales = new Dictionary<string, Locale>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Block>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Block
        {
            ID = "id",
            Type = BlockType.Action,
            Alias = "alias",
            Checksum = "checksum",
            Content = "string",
            Context = "context",
            Locales = new Dictionary<string, Locale>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Block>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, BlockType> expectedType = BlockType.Action;
        string expectedAlias = "alias";
        string expectedChecksum = "checksum";
        Content expectedContent = "string";
        string expectedContext = "context";
        Dictionary<string, Locale> expectedLocales = new() { { "foo", "string" } };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedAlias, deserialized.Alias);
        Assert.Equal(expectedChecksum, deserialized.Checksum);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedContext, deserialized.Context);
        Assert.Equal(expectedLocales.Count, deserialized.Locales.Count);
        foreach (var item in expectedLocales)
        {
            Assert.True(deserialized.Locales.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Locales[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Block
        {
            ID = "id",
            Type = BlockType.Action,
            Alias = "alias",
            Checksum = "checksum",
            Content = "string",
            Context = "context",
            Locales = new Dictionary<string, Locale>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Block { ID = "id", Type = BlockType.Action };

        Assert.Null(model.Alias);
        Assert.False(model.RawData.ContainsKey("alias"));
        Assert.Null(model.Checksum);
        Assert.False(model.RawData.ContainsKey("checksum"));
        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.Context);
        Assert.False(model.RawData.ContainsKey("context"));
        Assert.Null(model.Locales);
        Assert.False(model.RawData.ContainsKey("locales"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Block { ID = "id", Type = BlockType.Action };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Block
        {
            ID = "id",
            Type = BlockType.Action,

            Alias = null,
            Checksum = null,
            Content = null,
            Context = null,
            Locales = null,
        };

        Assert.Null(model.Alias);
        Assert.True(model.RawData.ContainsKey("alias"));
        Assert.Null(model.Checksum);
        Assert.True(model.RawData.ContainsKey("checksum"));
        Assert.Null(model.Content);
        Assert.True(model.RawData.ContainsKey("content"));
        Assert.Null(model.Context);
        Assert.True(model.RawData.ContainsKey("context"));
        Assert.Null(model.Locales);
        Assert.True(model.RawData.ContainsKey("locales"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Block
        {
            ID = "id",
            Type = BlockType.Action,

            Alias = null,
            Checksum = null,
            Content = null,
            Context = null,
            Locales = null,
        };

        model.Validate();
    }
}

public class BlockTypeTest : TestBase
{
    [Theory]
    [InlineData(BlockType.Action)]
    [InlineData(BlockType.Divider)]
    [InlineData(BlockType.Image)]
    [InlineData(BlockType.Jsonnet)]
    [InlineData(BlockType.List)]
    [InlineData(BlockType.Markdown)]
    [InlineData(BlockType.Quote)]
    [InlineData(BlockType.Template)]
    [InlineData(BlockType.Text)]
    public void Validation_Works(BlockType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BlockType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BlockType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BlockType.Action)]
    [InlineData(BlockType.Divider)]
    [InlineData(BlockType.Image)]
    [InlineData(BlockType.Jsonnet)]
    [InlineData(BlockType.List)]
    [InlineData(BlockType.Markdown)]
    [InlineData(BlockType.Quote)]
    [InlineData(BlockType.Template)]
    [InlineData(BlockType.Text)]
    public void SerializationRoundtrip_Works(BlockType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BlockType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BlockType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BlockType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BlockType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ContentTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Content value = new("string");
        value.Validate();
    }

    [Fact]
    public void NotificationContentHierarchyValidationWorks()
    {
        Content value = new(
            new NotificationContentHierarchy() { Children = "children", Parent = "parent" }
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Content value = new("string");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Content>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NotificationContentHierarchySerializationRoundtripWorks()
    {
        Content value = new(
            new NotificationContentHierarchy() { Children = "children", Parent = "parent" }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Content>(element);

        Assert.Equal(value, deserialized);
    }
}

public class NotificationContentHierarchyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NotificationContentHierarchy { Children = "children", Parent = "parent" };

        string expectedChildren = "children";
        string expectedParent = "parent";

        Assert.Equal(expectedChildren, model.Children);
        Assert.Equal(expectedParent, model.Parent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NotificationContentHierarchy { Children = "children", Parent = "parent" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NotificationContentHierarchy>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NotificationContentHierarchy { Children = "children", Parent = "parent" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<NotificationContentHierarchy>(element);
        Assert.NotNull(deserialized);

        string expectedChildren = "children";
        string expectedParent = "parent";

        Assert.Equal(expectedChildren, deserialized.Children);
        Assert.Equal(expectedParent, deserialized.Parent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NotificationContentHierarchy { Children = "children", Parent = "parent" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new NotificationContentHierarchy { };

        Assert.Null(model.Children);
        Assert.False(model.RawData.ContainsKey("children"));
        Assert.Null(model.Parent);
        Assert.False(model.RawData.ContainsKey("parent"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new NotificationContentHierarchy { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new NotificationContentHierarchy { Children = null, Parent = null };

        Assert.Null(model.Children);
        Assert.True(model.RawData.ContainsKey("children"));
        Assert.Null(model.Parent);
        Assert.True(model.RawData.ContainsKey("parent"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new NotificationContentHierarchy { Children = null, Parent = null };

        model.Validate();
    }
}

public class LocaleTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Locale value = new("string");
        value.Validate();
    }

    [Fact]
    public void NotificationContentHierarchyValidationWorks()
    {
        Locale value = new(
            new LocaleNotificationContentHierarchy() { Children = "children", Parent = "parent" }
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Locale value = new("string");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Locale>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NotificationContentHierarchySerializationRoundtripWorks()
    {
        Locale value = new(
            new LocaleNotificationContentHierarchy() { Children = "children", Parent = "parent" }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Locale>(element);

        Assert.Equal(value, deserialized);
    }
}

public class LocaleNotificationContentHierarchyTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LocaleNotificationContentHierarchy
        {
            Children = "children",
            Parent = "parent",
        };

        string expectedChildren = "children";
        string expectedParent = "parent";

        Assert.Equal(expectedChildren, model.Children);
        Assert.Equal(expectedParent, model.Parent);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LocaleNotificationContentHierarchy
        {
            Children = "children",
            Parent = "parent",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<LocaleNotificationContentHierarchy>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LocaleNotificationContentHierarchy
        {
            Children = "children",
            Parent = "parent",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<LocaleNotificationContentHierarchy>(element);
        Assert.NotNull(deserialized);

        string expectedChildren = "children";
        string expectedParent = "parent";

        Assert.Equal(expectedChildren, deserialized.Children);
        Assert.Equal(expectedParent, deserialized.Parent);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LocaleNotificationContentHierarchy
        {
            Children = "children",
            Parent = "parent",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LocaleNotificationContentHierarchy { };

        Assert.Null(model.Children);
        Assert.False(model.RawData.ContainsKey("children"));
        Assert.Null(model.Parent);
        Assert.False(model.RawData.ContainsKey("parent"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new LocaleNotificationContentHierarchy { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new LocaleNotificationContentHierarchy { Children = null, Parent = null };

        Assert.Null(model.Children);
        Assert.True(model.RawData.ContainsKey("children"));
        Assert.Null(model.Parent);
        Assert.True(model.RawData.ContainsKey("parent"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LocaleNotificationContentHierarchy { Children = null, Parent = null };

        model.Validate();
    }
}

public class ChannelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Channel
        {
            ID = "id",
            Checksum = "checksum",
            Content = new() { Subject = "subject", Title = "title" },
            Locales = new Dictionary<string, LocalesItem>()
            {
                {
                    "foo",
                    new() { Subject = "subject", Title = "title" }
                },
            },
            Type = "type",
        };

        string expectedID = "id";
        string expectedChecksum = "checksum";
        ChannelContent expectedContent = new() { Subject = "subject", Title = "title" };
        Dictionary<string, LocalesItem> expectedLocales = new()
        {
            {
                "foo",
                new() { Subject = "subject", Title = "title" }
            },
        };
        string expectedType = "type";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedChecksum, model.Checksum);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedLocales.Count, model.Locales.Count);
        foreach (var item in expectedLocales)
        {
            Assert.True(model.Locales.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Locales[item.Key]);
        }
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Channel
        {
            ID = "id",
            Checksum = "checksum",
            Content = new() { Subject = "subject", Title = "title" },
            Locales = new Dictionary<string, LocalesItem>()
            {
                {
                    "foo",
                    new() { Subject = "subject", Title = "title" }
                },
            },
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Channel>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Channel
        {
            ID = "id",
            Checksum = "checksum",
            Content = new() { Subject = "subject", Title = "title" },
            Locales = new Dictionary<string, LocalesItem>()
            {
                {
                    "foo",
                    new() { Subject = "subject", Title = "title" }
                },
            },
            Type = "type",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Channel>(element);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedChecksum = "checksum";
        ChannelContent expectedContent = new() { Subject = "subject", Title = "title" };
        Dictionary<string, LocalesItem> expectedLocales = new()
        {
            {
                "foo",
                new() { Subject = "subject", Title = "title" }
            },
        };
        string expectedType = "type";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedChecksum, deserialized.Checksum);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedLocales.Count, deserialized.Locales.Count);
        foreach (var item in expectedLocales)
        {
            Assert.True(deserialized.Locales.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Locales[item.Key]);
        }
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Channel
        {
            ID = "id",
            Checksum = "checksum",
            Content = new() { Subject = "subject", Title = "title" },
            Locales = new Dictionary<string, LocalesItem>()
            {
                {
                    "foo",
                    new() { Subject = "subject", Title = "title" }
                },
            },
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Channel { ID = "id" };

        Assert.Null(model.Checksum);
        Assert.False(model.RawData.ContainsKey("checksum"));
        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.Locales);
        Assert.False(model.RawData.ContainsKey("locales"));
        Assert.Null(model.Type);
        Assert.False(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Channel { ID = "id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Channel
        {
            ID = "id",

            Checksum = null,
            Content = null,
            Locales = null,
            Type = null,
        };

        Assert.Null(model.Checksum);
        Assert.True(model.RawData.ContainsKey("checksum"));
        Assert.Null(model.Content);
        Assert.True(model.RawData.ContainsKey("content"));
        Assert.Null(model.Locales);
        Assert.True(model.RawData.ContainsKey("locales"));
        Assert.Null(model.Type);
        Assert.True(model.RawData.ContainsKey("type"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Channel
        {
            ID = "id",

            Checksum = null,
            Content = null,
            Locales = null,
            Type = null,
        };

        model.Validate();
    }
}

public class ChannelContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChannelContent { Subject = "subject", Title = "title" };

        string expectedSubject = "subject";
        string expectedTitle = "title";

        Assert.Equal(expectedSubject, model.Subject);
        Assert.Equal(expectedTitle, model.Title);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChannelContent { Subject = "subject", Title = "title" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ChannelContent>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChannelContent { Subject = "subject", Title = "title" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ChannelContent>(element);
        Assert.NotNull(deserialized);

        string expectedSubject = "subject";
        string expectedTitle = "title";

        Assert.Equal(expectedSubject, deserialized.Subject);
        Assert.Equal(expectedTitle, deserialized.Title);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChannelContent { Subject = "subject", Title = "title" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChannelContent { };

        Assert.Null(model.Subject);
        Assert.False(model.RawData.ContainsKey("subject"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChannelContent { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ChannelContent { Subject = null, Title = null };

        Assert.Null(model.Subject);
        Assert.True(model.RawData.ContainsKey("subject"));
        Assert.Null(model.Title);
        Assert.True(model.RawData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChannelContent { Subject = null, Title = null };

        model.Validate();
    }
}

public class LocalesItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LocalesItem { Subject = "subject", Title = "title" };

        string expectedSubject = "subject";
        string expectedTitle = "title";

        Assert.Equal(expectedSubject, model.Subject);
        Assert.Equal(expectedTitle, model.Title);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LocalesItem { Subject = "subject", Title = "title" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<LocalesItem>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LocalesItem { Subject = "subject", Title = "title" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<LocalesItem>(element);
        Assert.NotNull(deserialized);

        string expectedSubject = "subject";
        string expectedTitle = "title";

        Assert.Equal(expectedSubject, deserialized.Subject);
        Assert.Equal(expectedTitle, deserialized.Title);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LocalesItem { Subject = "subject", Title = "title" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LocalesItem { };

        Assert.Null(model.Subject);
        Assert.False(model.RawData.ContainsKey("subject"));
        Assert.Null(model.Title);
        Assert.False(model.RawData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new LocalesItem { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new LocalesItem { Subject = null, Title = null };

        Assert.Null(model.Subject);
        Assert.True(model.RawData.ContainsKey("subject"));
        Assert.Null(model.Title);
        Assert.True(model.RawData.ContainsKey("title"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LocalesItem { Subject = null, Title = null };

        model.Validate();
    }
}
