using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models.Tenants.Templates;
using Models = Courier.Models;

namespace Courier.Tests.Models.Tenants.Templates;

public class TemplateListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TemplateListResponse
        {
            HasMore = true,
            Type = Type.List,
            URL = "url",
            Cursor = "cursor",
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    PublishedAt = "published_at",
                    UpdatedAt = "updated_at",
                    Version = "version",
                    Data = new(
                        new Models::MessageRouting()
                        {
                            Channels = ["string"],
                            Method = Models::Method.All,
                        }
                    ),
                },
            ],
            NextURL = "next_url",
        };

        bool expectedHasMore = true;
        ApiEnum<string, Type> expectedType = Type.List;
        string expectedURL = "url";
        string expectedCursor = "cursor";
        List<Item> expectedItems =
        [
            new()
            {
                ID = "id",
                CreatedAt = "created_at",
                PublishedAt = "published_at",
                UpdatedAt = "updated_at",
                Version = "version",
                Data = new(
                    new Models::MessageRouting()
                    {
                        Channels = ["string"],
                        Method = Models::Method.All,
                    }
                ),
            },
        ];
        string expectedNextURL = "next_url";

        Assert.Equal(expectedHasMore, model.HasMore);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedURL, model.URL);
        Assert.Equal(expectedCursor, model.Cursor);
        Assert.Equal(expectedItems.Count, model.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], model.Items[i]);
        }
        Assert.Equal(expectedNextURL, model.NextURL);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TemplateListResponse
        {
            HasMore = true,
            Type = Type.List,
            URL = "url",
            Cursor = "cursor",
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    PublishedAt = "published_at",
                    UpdatedAt = "updated_at",
                    Version = "version",
                    Data = new(
                        new Models::MessageRouting()
                        {
                            Channels = ["string"],
                            Method = Models::Method.All,
                        }
                    ),
                },
            ],
            NextURL = "next_url",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TemplateListResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TemplateListResponse
        {
            HasMore = true,
            Type = Type.List,
            URL = "url",
            Cursor = "cursor",
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    PublishedAt = "published_at",
                    UpdatedAt = "updated_at",
                    Version = "version",
                    Data = new(
                        new Models::MessageRouting()
                        {
                            Channels = ["string"],
                            Method = Models::Method.All,
                        }
                    ),
                },
            ],
            NextURL = "next_url",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<TemplateListResponse>(json);
        Assert.NotNull(deserialized);

        bool expectedHasMore = true;
        ApiEnum<string, Type> expectedType = Type.List;
        string expectedURL = "url";
        string expectedCursor = "cursor";
        List<Item> expectedItems =
        [
            new()
            {
                ID = "id",
                CreatedAt = "created_at",
                PublishedAt = "published_at",
                UpdatedAt = "updated_at",
                Version = "version",
                Data = new(
                    new Models::MessageRouting()
                    {
                        Channels = ["string"],
                        Method = Models::Method.All,
                    }
                ),
            },
        ];
        string expectedNextURL = "next_url";

        Assert.Equal(expectedHasMore, deserialized.HasMore);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedURL, deserialized.URL);
        Assert.Equal(expectedCursor, deserialized.Cursor);
        Assert.Equal(expectedItems.Count, deserialized.Items.Count);
        for (int i = 0; i < expectedItems.Count; i++)
        {
            Assert.Equal(expectedItems[i], deserialized.Items[i]);
        }
        Assert.Equal(expectedNextURL, deserialized.NextURL);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TemplateListResponse
        {
            HasMore = true,
            Type = Type.List,
            URL = "url",
            Cursor = "cursor",
            Items =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "created_at",
                    PublishedAt = "published_at",
                    UpdatedAt = "updated_at",
                    Version = "version",
                    Data = new(
                        new Models::MessageRouting()
                        {
                            Channels = ["string"],
                            Method = Models::Method.All,
                        }
                    ),
                },
            ],
            NextURL = "next_url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TemplateListResponse
        {
            HasMore = true,
            Type = Type.List,
            URL = "url",
        };

        Assert.Null(model.Cursor);
        Assert.False(model.RawData.ContainsKey("cursor"));
        Assert.Null(model.Items);
        Assert.False(model.RawData.ContainsKey("items"));
        Assert.Null(model.NextURL);
        Assert.False(model.RawData.ContainsKey("next_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new TemplateListResponse
        {
            HasMore = true,
            Type = Type.List,
            URL = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TemplateListResponse
        {
            HasMore = true,
            Type = Type.List,
            URL = "url",

            Cursor = null,
            Items = null,
            NextURL = null,
        };

        Assert.Null(model.Cursor);
        Assert.True(model.RawData.ContainsKey("cursor"));
        Assert.Null(model.Items);
        Assert.True(model.RawData.ContainsKey("items"));
        Assert.Null(model.NextURL);
        Assert.True(model.RawData.ContainsKey("next_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TemplateListResponse
        {
            HasMore = true,
            Type = Type.List,
            URL = "url",

            Cursor = null,
            Items = null,
            NextURL = null,
        };

        model.Validate();
    }
}

public class ItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = "created_at",
            PublishedAt = "published_at",
            UpdatedAt = "updated_at",
            Version = "version",
            Data = new(
                new Models::MessageRouting() { Channels = ["string"], Method = Models::Method.All }
            ),
        };

        string expectedID = "id";
        string expectedCreatedAt = "created_at";
        string expectedPublishedAt = "published_at";
        string expectedUpdatedAt = "updated_at";
        string expectedVersion = "version";
        Data expectedData = new(
            new Models::MessageRouting() { Channels = ["string"], Method = Models::Method.All }
        );

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedPublishedAt, model.PublishedAt);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedVersion, model.Version);
        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = "created_at",
            PublishedAt = "published_at",
            UpdatedAt = "updated_at",
            Version = "version",
            Data = new(
                new Models::MessageRouting() { Channels = ["string"], Method = Models::Method.All }
            ),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Item>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = "created_at",
            PublishedAt = "published_at",
            UpdatedAt = "updated_at",
            Version = "version",
            Data = new(
                new Models::MessageRouting() { Channels = ["string"], Method = Models::Method.All }
            ),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Item>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCreatedAt = "created_at";
        string expectedPublishedAt = "published_at";
        string expectedUpdatedAt = "updated_at";
        string expectedVersion = "version";
        Data expectedData = new(
            new Models::MessageRouting() { Channels = ["string"], Method = Models::Method.All }
        );

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedPublishedAt, deserialized.PublishedAt);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedVersion, deserialized.Version);
        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Item
        {
            ID = "id",
            CreatedAt = "created_at",
            PublishedAt = "published_at",
            UpdatedAt = "updated_at",
            Version = "version",
            Data = new(
                new Models::MessageRouting() { Channels = ["string"], Method = Models::Method.All }
            ),
        };

        model.Validate();
    }
}

public class IntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntersectionMember1
        {
            Data = new(
                new Models::MessageRouting() { Channels = ["string"], Method = Models::Method.All }
            ),
        };

        Data expectedData = new(
            new Models::MessageRouting() { Channels = ["string"], Method = Models::Method.All }
        );

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntersectionMember1
        {
            Data = new(
                new Models::MessageRouting() { Channels = ["string"], Method = Models::Method.All }
            ),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntersectionMember1
        {
            Data = new(
                new Models::MessageRouting() { Channels = ["string"], Method = Models::Method.All }
            ),
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<IntersectionMember1>(json);
        Assert.NotNull(deserialized);

        Data expectedData = new(
            new Models::MessageRouting() { Channels = ["string"], Method = Models::Method.All }
        );

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IntersectionMember1
        {
            Data = new(
                new Models::MessageRouting() { Channels = ["string"], Method = Models::Method.All }
            ),
        };

        model.Validate();
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            Routing = new() { Channels = ["string"], Method = Models::Method.All },
        };

        Models::MessageRouting expectedRouting = new()
        {
            Channels = ["string"],
            Method = Models::Method.All,
        };

        Assert.Equal(expectedRouting, model.Routing);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            Routing = new() { Channels = ["string"], Method = Models::Method.All },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Data>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            Routing = new() { Channels = ["string"], Method = Models::Method.All },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<Data>(json);
        Assert.NotNull(deserialized);

        Models::MessageRouting expectedRouting = new()
        {
            Channels = ["string"],
            Method = Models::Method.All,
        };

        Assert.Equal(expectedRouting, deserialized.Routing);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            Routing = new() { Channels = ["string"], Method = Models::Method.All },
        };

        model.Validate();
    }
}
