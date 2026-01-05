using System.Collections.Generic;
using System.Text.Json;
using Courier.Models;
using Courier.Models.Audiences;

namespace Courier.Tests.Models.Audiences;

public class AudienceListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AudienceListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    Description = "description",
                    Filter = new SingleFilterConfig()
                    {
                        Operator = SingleFilterConfigOperator.EndsWith,
                        Path = "path",
                        Value = "value",
                    },
                    Name = "name",
                    UpdatedAt = "updated_at",
                },
            ],
            Paging = new() { More = true, Cursor = "cursor" },
        };

        List<Audience> expectedItems =
        [
            new()
            {
                ID = "id",
                CreatedAt = "created_at",
                Description = "description",
                Filter = new SingleFilterConfig()
                {
                    Operator = SingleFilterConfigOperator.EndsWith,
                    Path = "path",
                    Value = "value",
                },
                Name = "name",
                UpdatedAt = "updated_at",
            },
        ];
        Paging expectedPaging = new() { More = true, Cursor = "cursor" };

        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedPaging, model.Paging);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AudienceListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    Description = "description",
                    Filter = new SingleFilterConfig()
                    {
                        Operator = SingleFilterConfigOperator.EndsWith,
                        Path = "path",
                        Value = "value",
                    },
                    Name = "name",
                    UpdatedAt = "updated_at",
                },
            ],
            Paging = new() { More = true, Cursor = "cursor" },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AudienceListResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AudienceListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    Description = "description",
                    Filter = new SingleFilterConfig()
                    {
                        Operator = SingleFilterConfigOperator.EndsWith,
                        Path = "path",
                        Value = "value",
                    },
                    Name = "name",
                    UpdatedAt = "updated_at",
                },
            ],
            Paging = new() { More = true, Cursor = "cursor" },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AudienceListResponse>(element);
        Assert.NotNull(deserialized);

        List<Audience> expectedItems =
        [
            new()
            {
                ID = "id",
                CreatedAt = "created_at",
                Description = "description",
                Filter = new SingleFilterConfig()
                {
                    Operator = SingleFilterConfigOperator.EndsWith,
                    Path = "path",
                    Value = "value",
                },
                Name = "name",
                UpdatedAt = "updated_at",
            },
        ];
        Paging expectedPaging = new() { More = true, Cursor = "cursor" };

        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedPaging, deserialized.Paging);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AudienceListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    Description = "description",
                    Filter = new SingleFilterConfig()
                    {
                        Operator = SingleFilterConfigOperator.EndsWith,
                        Path = "path",
                        Value = "value",
                    },
                    Name = "name",
                    UpdatedAt = "updated_at",
                },
            ],
            Paging = new() { More = true, Cursor = "cursor" },
        };

        model.Validate();
    }
}
