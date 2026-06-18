using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;
using TryCourier.Models.Providers;
using TryCourier.Models.Providers.Catalog;

namespace TryCourier.Tests.Models.Providers.Catalog;

public class CatalogListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CatalogListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
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
                },
            ],
        };

        Paging expectedPaging = new() { More = true, Cursor = "cursor" };
        List<ProvidersCatalogEntry> expectedResults =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedPaging, model.Paging);
        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], model.Results[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CatalogListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
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
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CatalogListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CatalogListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
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
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CatalogListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Paging expectedPaging = new() { More = true, Cursor = "cursor" };
        List<ProvidersCatalogEntry> expectedResults =
        [
            new()
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
            },
        ];

        Assert.Equal(expectedPaging, deserialized.Paging);
        Assert.Equal(expectedResults.Count, deserialized.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], deserialized.Results[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CatalogListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CatalogListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
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
                },
            ],
        };

        CatalogListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
