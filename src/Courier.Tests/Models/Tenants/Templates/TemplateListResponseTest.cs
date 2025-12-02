using System.Collections.Generic;
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
}
