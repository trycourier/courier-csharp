using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Notifications;

namespace TryCourier.Tests.Models.Notifications;

public class NotificationContentGetResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NotificationContentGetResponse
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

        List<ElementWithChecksums> expectedElements =
        [
            new()
            {
                Checksum = "checksum",
                Type = "type",
                ID = "id",
                Elements = [],
                Locales = new Dictionary<string, LocalesItem>() { { "foo", new("checksum") } },
            },
        ];
        string expectedVersion = "2022-01-01";

        Assert.Equal(expectedElements.Count, model.Elements.Count);
        for (int i = 0; i < expectedElements.Count; i++)
        {
            Assert.Equal(expectedElements[i], model.Elements[i]);
        }
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NotificationContentGetResponse
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

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationContentGetResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NotificationContentGetResponse
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

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NotificationContentGetResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ElementWithChecksums> expectedElements =
        [
            new()
            {
                Checksum = "checksum",
                Type = "type",
                ID = "id",
                Elements = [],
                Locales = new Dictionary<string, LocalesItem>() { { "foo", new("checksum") } },
            },
        ];
        string expectedVersion = "2022-01-01";

        Assert.Equal(expectedElements.Count, deserialized.Elements.Count);
        for (int i = 0; i < expectedElements.Count; i++)
        {
            Assert.Equal(expectedElements[i], deserialized.Elements[i]);
        }
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NotificationContentGetResponse
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

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NotificationContentGetResponse
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

        NotificationContentGetResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
