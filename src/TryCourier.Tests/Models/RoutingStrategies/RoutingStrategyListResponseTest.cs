using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;
using TryCourier.Models.RoutingStrategies;

namespace TryCourier.Tests.Models.RoutingStrategies;

public class RoutingStrategyListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RoutingStrategyListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    Created = 0,
                    Creator = "creator",
                    Name = "name",
                    Description = "description",
                    Tags = ["string"],
                    Updated = 0,
                    Updater = "updater",
                },
            ],
        };

        Paging expectedPaging = new() { More = true, Cursor = "cursor" };
        List<RoutingStrategySummary> expectedResults =
        [
            new()
            {
                ID = "id",
                Created = 0,
                Creator = "creator",
                Name = "name",
                Description = "description",
                Tags = ["string"],
                Updated = 0,
                Updater = "updater",
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
        var model = new RoutingStrategyListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    Created = 0,
                    Creator = "creator",
                    Name = "name",
                    Description = "description",
                    Tags = ["string"],
                    Updated = 0,
                    Updater = "updater",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RoutingStrategyListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RoutingStrategyListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    Created = 0,
                    Creator = "creator",
                    Name = "name",
                    Description = "description",
                    Tags = ["string"],
                    Updated = 0,
                    Updater = "updater",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RoutingStrategyListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Paging expectedPaging = new() { More = true, Cursor = "cursor" };
        List<RoutingStrategySummary> expectedResults =
        [
            new()
            {
                ID = "id",
                Created = 0,
                Creator = "creator",
                Name = "name",
                Description = "description",
                Tags = ["string"],
                Updated = 0,
                Updater = "updater",
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
        var model = new RoutingStrategyListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    Created = 0,
                    Creator = "creator",
                    Name = "name",
                    Description = "description",
                    Tags = ["string"],
                    Updated = 0,
                    Updater = "updater",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RoutingStrategyListResponse
        {
            Paging = new() { More = true, Cursor = "cursor" },
            Results =
            [
                new()
                {
                    ID = "id",
                    Created = 0,
                    Creator = "creator",
                    Name = "name",
                    Description = "description",
                    Tags = ["string"],
                    Updated = 0,
                    Updater = "updater",
                },
            ],
        };

        RoutingStrategyListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
