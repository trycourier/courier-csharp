using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Providers;

namespace TryCourier.Tests.Models.Providers;

public class ProviderTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Provider
        {
            ID = "id",
            Created = 0,
            ProviderValue = "provider",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Title = "title",
            Alias = "alias",
            Updated = 0,
        };

        string expectedID = "id";
        long expectedCreated = 0;
        string expectedProviderValue = "provider";
        Dictionary<string, JsonElement> expectedSettings = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedTitle = "title";
        string expectedAlias = "alias";
        long expectedUpdated = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreated, model.Created);
        Assert.Equal(expectedProviderValue, model.ProviderValue);
        Assert.Equal(expectedSettings.Count, model.Settings.Count);
        foreach (var item in expectedSettings)
        {
            Assert.True(model.Settings.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Settings[item.Key]));
        }
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedAlias, model.Alias);
        Assert.Equal(expectedUpdated, model.Updated);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Provider
        {
            ID = "id",
            Created = 0,
            ProviderValue = "provider",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Title = "title",
            Alias = "alias",
            Updated = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Provider>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Provider
        {
            ID = "id",
            Created = 0,
            ProviderValue = "provider",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Title = "title",
            Alias = "alias",
            Updated = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Provider>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedCreated = 0;
        string expectedProviderValue = "provider";
        Dictionary<string, JsonElement> expectedSettings = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedTitle = "title";
        string expectedAlias = "alias";
        long expectedUpdated = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreated, deserialized.Created);
        Assert.Equal(expectedProviderValue, deserialized.ProviderValue);
        Assert.Equal(expectedSettings.Count, deserialized.Settings.Count);
        foreach (var item in expectedSettings)
        {
            Assert.True(deserialized.Settings.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Settings[item.Key]));
        }
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedAlias, deserialized.Alias);
        Assert.Equal(expectedUpdated, deserialized.Updated);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Provider
        {
            ID = "id",
            Created = 0,
            ProviderValue = "provider",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Title = "title",
            Alias = "alias",
            Updated = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Provider
        {
            ID = "id",
            Created = 0,
            ProviderValue = "provider",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Title = "title",
            Updated = 0,
        };

        Assert.Null(model.Alias);
        Assert.False(model.RawData.ContainsKey("alias"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Provider
        {
            ID = "id",
            Created = 0,
            ProviderValue = "provider",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Title = "title",
            Updated = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Provider
        {
            ID = "id",
            Created = 0,
            ProviderValue = "provider",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Title = "title",
            Updated = 0,

            // Null should be interpreted as omitted for these properties
            Alias = null,
        };

        Assert.Null(model.Alias);
        Assert.False(model.RawData.ContainsKey("alias"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Provider
        {
            ID = "id",
            Created = 0,
            ProviderValue = "provider",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Title = "title",
            Updated = 0,

            // Null should be interpreted as omitted for these properties
            Alias = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Provider
        {
            ID = "id",
            Created = 0,
            ProviderValue = "provider",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Title = "title",
            Alias = "alias",
        };

        Assert.Null(model.Updated);
        Assert.False(model.RawData.ContainsKey("updated"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Provider
        {
            ID = "id",
            Created = 0,
            ProviderValue = "provider",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Title = "title",
            Alias = "alias",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Provider
        {
            ID = "id",
            Created = 0,
            ProviderValue = "provider",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Title = "title",
            Alias = "alias",

            Updated = null,
        };

        Assert.Null(model.Updated);
        Assert.True(model.RawData.ContainsKey("updated"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Provider
        {
            ID = "id",
            Created = 0,
            ProviderValue = "provider",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Title = "title",
            Alias = "alias",

            Updated = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Provider
        {
            ID = "id",
            Created = 0,
            ProviderValue = "provider",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Title = "title",
            Alias = "alias",
            Updated = 0,
        };

        Provider copied = new(model);

        Assert.Equal(model, copied);
    }
}
