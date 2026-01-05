using System.Collections.Generic;
using System.Text.Json;
using Courier.Models;
using Courier.Models.Lists;

namespace Courier.Tests.Models.Lists;

public class ListListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ListListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Created = "created",
                    Updated = "updated",
                },
            ],
            Paging = new() { More = true, Cursor = "cursor" },
        };

        List<SubscriptionList> expectedItems =
        [
            new()
            {
                ID = "id",
                Name = "name",
                Created = "created",
                Updated = "updated",
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
        var model = new ListListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Created = "created",
                    Updated = "updated",
                },
            ],
            Paging = new() { More = true, Cursor = "cursor" },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ListListResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ListListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Created = "created",
                    Updated = "updated",
                },
            ],
            Paging = new() { More = true, Cursor = "cursor" },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ListListResponse>(element);
        Assert.NotNull(deserialized);

        List<SubscriptionList> expectedItems =
        [
            new()
            {
                ID = "id",
                Name = "name",
                Created = "created",
                Updated = "updated",
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
        var model = new ListListResponse
        {
            Items =
            [
                new()
                {
                    ID = "id",
                    Name = "name",
                    Created = "created",
                    Updated = "updated",
                },
            ],
            Paging = new() { More = true, Cursor = "cursor" },
        };

        model.Validate();
    }
}
