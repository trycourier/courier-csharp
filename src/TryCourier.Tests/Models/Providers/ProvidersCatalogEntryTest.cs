using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Providers;

namespace TryCourier.Tests.Models.Providers;

public class ProvidersCatalogEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProvidersCatalogEntry
        {
            Channel = "channel",
            Description = "description",
            Name = "name",
            Provider = "provider",
            Settings = new Dictionary<string, SettingsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Required = true,
                        Type = "type",
                        Values = ["string"],
                    }
                },
            },
        };

        string expectedChannel = "channel";
        string expectedDescription = "description";
        string expectedName = "name";
        string expectedProvider = "provider";
        Dictionary<string, SettingsItem> expectedSettings = new()
        {
            {
                "foo",
                new()
                {
                    Required = true,
                    Type = "type",
                    Values = ["string"],
                }
            },
        };

        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedProvider, model.Provider);
        Assert.Equal(expectedSettings.Count, model.Settings.Count);
        foreach (var item in expectedSettings)
        {
            Assert.True(model.Settings.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Settings[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProvidersCatalogEntry
        {
            Channel = "channel",
            Description = "description",
            Name = "name",
            Provider = "provider",
            Settings = new Dictionary<string, SettingsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Required = true,
                        Type = "type",
                        Values = ["string"],
                    }
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProvidersCatalogEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProvidersCatalogEntry
        {
            Channel = "channel",
            Description = "description",
            Name = "name",
            Provider = "provider",
            Settings = new Dictionary<string, SettingsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Required = true,
                        Type = "type",
                        Values = ["string"],
                    }
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProvidersCatalogEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedChannel = "channel";
        string expectedDescription = "description";
        string expectedName = "name";
        string expectedProvider = "provider";
        Dictionary<string, SettingsItem> expectedSettings = new()
        {
            {
                "foo",
                new()
                {
                    Required = true,
                    Type = "type",
                    Values = ["string"],
                }
            },
        };

        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedProvider, deserialized.Provider);
        Assert.Equal(expectedSettings.Count, deserialized.Settings.Count);
        foreach (var item in expectedSettings)
        {
            Assert.True(deserialized.Settings.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Settings[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProvidersCatalogEntry
        {
            Channel = "channel",
            Description = "description",
            Name = "name",
            Provider = "provider",
            Settings = new Dictionary<string, SettingsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Required = true,
                        Type = "type",
                        Values = ["string"],
                    }
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProvidersCatalogEntry
        {
            Channel = "channel",
            Description = "description",
            Name = "name",
            Provider = "provider",
            Settings = new Dictionary<string, SettingsItem>()
            {
                {
                    "foo",
                    new()
                    {
                        Required = true,
                        Type = "type",
                        Values = ["string"],
                    }
                },
            },
        };

        ProvidersCatalogEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SettingsItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SettingsItem
        {
            Required = true,
            Type = "type",
            Values = ["string"],
        };

        bool expectedRequired = true;
        string expectedType = "type";
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedRequired, model.Required);
        Assert.Equal(expectedType, model.Type);
        Assert.NotNull(model.Values);
        Assert.Equal(expectedValues.Count, model.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], model.Values[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SettingsItem
        {
            Required = true,
            Type = "type",
            Values = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SettingsItem>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SettingsItem
        {
            Required = true,
            Type = "type",
            Values = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SettingsItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedRequired = true;
        string expectedType = "type";
        List<string> expectedValues = ["string"];

        Assert.Equal(expectedRequired, deserialized.Required);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.NotNull(deserialized.Values);
        Assert.Equal(expectedValues.Count, deserialized.Values.Count);
        for (int i = 0; i < expectedValues.Count; i++)
        {
            Assert.Equal(expectedValues[i], deserialized.Values[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SettingsItem
        {
            Required = true,
            Type = "type",
            Values = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SettingsItem { Required = true, Type = "type" };

        Assert.Null(model.Values);
        Assert.False(model.RawData.ContainsKey("values"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SettingsItem { Required = true, Type = "type" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SettingsItem
        {
            Required = true,
            Type = "type",

            // Null should be interpreted as omitted for these properties
            Values = null,
        };

        Assert.Null(model.Values);
        Assert.False(model.RawData.ContainsKey("values"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SettingsItem
        {
            Required = true,
            Type = "type",

            // Null should be interpreted as omitted for these properties
            Values = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SettingsItem
        {
            Required = true,
            Type = "type",
            Values = ["string"],
        };

        SettingsItem copied = new(model);

        Assert.Equal(model, copied);
    }
}
