using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Previews;

namespace TryCourier.Tests.Models.Previews;

public class DeviceSetListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DeviceSetListResponse
        {
            Results =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    DeviceIds = ["string"],
                    Name = "name",
                    UpdatedAt = "updated_at",
                    ArchivedAt = "archived_at",
                },
            ],
        };

        List<DeviceSet> expectedResults =
        [
            new()
            {
                ID = "id",
                CreatedAt = "created_at",
                DeviceIds = ["string"],
                Name = "name",
                UpdatedAt = "updated_at",
                ArchivedAt = "archived_at",
            },
        ];

        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], model.Results[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DeviceSetListResponse
        {
            Results =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    DeviceIds = ["string"],
                    Name = "name",
                    UpdatedAt = "updated_at",
                    ArchivedAt = "archived_at",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeviceSetListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DeviceSetListResponse
        {
            Results =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    DeviceIds = ["string"],
                    Name = "name",
                    UpdatedAt = "updated_at",
                    ArchivedAt = "archived_at",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DeviceSetListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<DeviceSet> expectedResults =
        [
            new()
            {
                ID = "id",
                CreatedAt = "created_at",
                DeviceIds = ["string"],
                Name = "name",
                UpdatedAt = "updated_at",
                ArchivedAt = "archived_at",
            },
        ];

        Assert.Equal(expectedResults.Count, deserialized.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], deserialized.Results[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DeviceSetListResponse
        {
            Results =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    DeviceIds = ["string"],
                    Name = "name",
                    UpdatedAt = "updated_at",
                    ArchivedAt = "archived_at",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DeviceSetListResponse
        {
            Results =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    DeviceIds = ["string"],
                    Name = "name",
                    UpdatedAt = "updated_at",
                    ArchivedAt = "archived_at",
                },
            ],
        };

        DeviceSetListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
