using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Notifications;

namespace TryCourier.Tests.Models.Notifications;

public class NotificationRetrieveContentResponseTest : TestBase
{
    [Fact]
    public void ContentGetValidationWorks()
    {
        NotificationRetrieveContentResponse value = new NotificationContentGetResponse()
        {
            Elements =
            [
                new()
                {
                    Checksum = "checksum",
                    Type = "type",
                    ID = "id",
                    Elements = [],
                    Locales = new Dictionary<string, LocalesItem>() { { "foo", new("checksum") } },
                },
            ],
            Version = "2022-01-01",
        };
        value.Validate();
    }

    [Fact]
    public void GetContentValidationWorks()
    {
        NotificationRetrieveContentResponse value = new NotificationGetContent()
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
                    Locales = new Dictionary<string, ChannelLocalesItem>()
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
        value.Validate();
    }

    [Fact]
    public void ContentGetSerializationRoundtripWorks()
    {
        NotificationRetrieveContentResponse value = new NotificationContentGetResponse()
        {
            Elements =
            [
                new()
                {
                    Checksum = "checksum",
                    Type = "type",
                    ID = "id",
                    Elements = [],
                    Locales = new Dictionary<string, LocalesItem>() { { "foo", new("checksum") } },
                },
            ],
            Version = "2022-01-01",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationRetrieveContentResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void GetContentSerializationRoundtripWorks()
    {
        NotificationRetrieveContentResponse value = new NotificationGetContent()
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
                    Locales = new Dictionary<string, ChannelLocalesItem>()
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationRetrieveContentResponse>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
