using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;
using TryCourier.Models.Providers;

namespace TryCourier.Tests.Models.Providers;

public class ProviderListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProviderListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
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
                },
            ],
        };

        Paging expectedPaging = new() { More = true, Cursor = "cursor" };
        List<Provider> expectedResults =
        [
            new()
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
        var model = new ProviderListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
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
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProviderListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProviderListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
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
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProviderListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Paging expectedPaging = new() { More = true, Cursor = "cursor" };
        List<Provider> expectedResults =
        [
            new()
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
        var model = new ProviderListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
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
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProviderListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
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
                },
            ],
        };

        ProviderListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
