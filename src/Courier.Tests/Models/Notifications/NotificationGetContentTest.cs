using System.Collections.Generic;
using Courier.Core;
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

        Assert.Equal(expectedBlocks.Count, model.Blocks.Count);
        for (int i = 0; i < expectedBlocks.Count; i++)
        {
            Assert.Equal(expectedBlocks[i], model.Blocks[i]);
        }
        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], model.Channels[i]);
        }
        Assert.Equal(expectedChecksum, model.Checksum);
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
}
