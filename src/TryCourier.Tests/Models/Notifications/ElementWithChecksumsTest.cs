using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Notifications;

namespace TryCourier.Tests.Models.Notifications;

public class ElementWithChecksumsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementWithChecksums
        {
            Checksum = "checksum",
            Type = "type",
            ID = "id",
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
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("checksum") } },
        };

        string expectedChecksum = "checksum";
        string expectedType = "type";
        string expectedID = "id";
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
        Dictionary<string, LocalesItem> expectedLocales = new() { { "foo", new("checksum") } };

        Assert.Equal(expectedChecksum, model.Checksum);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedID, model.ID);
        Assert.NotNull(model.Elements);
        Assert.Equal(expectedElements.Count, model.Elements.Count);
        for (int i = 0; i < expectedElements.Count; i++)
        {
            Assert.Equal(expectedElements[i], model.Elements[i]);
        }
        Assert.NotNull(model.Locales);
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
        var model = new ElementWithChecksums
        {
            Checksum = "checksum",
            Type = "type",
            ID = "id",
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
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("checksum") } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementWithChecksums>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ElementWithChecksums
        {
            Checksum = "checksum",
            Type = "type",
            ID = "id",
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
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("checksum") } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementWithChecksums>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedChecksum = "checksum";
        string expectedType = "type";
        string expectedID = "id";
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
        Dictionary<string, LocalesItem> expectedLocales = new() { { "foo", new("checksum") } };

        Assert.Equal(expectedChecksum, deserialized.Checksum);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedID, deserialized.ID);
        Assert.NotNull(deserialized.Elements);
        Assert.Equal(expectedElements.Count, deserialized.Elements.Count);
        for (int i = 0; i < expectedElements.Count; i++)
        {
            Assert.Equal(expectedElements[i], deserialized.Elements[i]);
        }
        Assert.NotNull(deserialized.Locales);
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
        var model = new ElementWithChecksums
        {
            Checksum = "checksum",
            Type = "type",
            ID = "id",
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
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("checksum") } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementWithChecksums { Checksum = "checksum", Type = "type" };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Elements);
        Assert.False(model.RawData.ContainsKey("elements"));
        Assert.Null(model.Locales);
        Assert.False(model.RawData.ContainsKey("locales"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ElementWithChecksums { Checksum = "checksum", Type = "type" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ElementWithChecksums
        {
            Checksum = "checksum",
            Type = "type",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Elements = null,
            Locales = null,
        };

        Assert.Null(model.ID);
        Assert.False(model.RawData.ContainsKey("id"));
        Assert.Null(model.Elements);
        Assert.False(model.RawData.ContainsKey("elements"));
        Assert.Null(model.Locales);
        Assert.False(model.RawData.ContainsKey("locales"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ElementWithChecksums
        {
            Checksum = "checksum",
            Type = "type",

            // Null should be interpreted as omitted for these properties
            ID = null,
            Elements = null,
            Locales = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ElementWithChecksums
        {
            Checksum = "checksum",
            Type = "type",
            ID = "id",
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
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("checksum") } },
        };

        ElementWithChecksums copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LocalesItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LocalesItem { Checksum = "checksum" };

        string expectedChecksum = "checksum";

        Assert.Equal(expectedChecksum, model.Checksum);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LocalesItem { Checksum = "checksum" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LocalesItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LocalesItem { Checksum = "checksum" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LocalesItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedChecksum = "checksum";

        Assert.Equal(expectedChecksum, deserialized.Checksum);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LocalesItem { Checksum = "checksum" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LocalesItem { Checksum = "checksum" };

        LocalesItem copied = new(model);

        Assert.Equal(model, copied);
    }
}
