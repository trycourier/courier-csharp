using System.Text.Json;
using Courier.Core;
using Courier.Models.Tenants;

namespace Courier.Tests.Models.Tenants;

public class PostTenantTemplatePublishResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PostTenantTemplatePublishResponse
        {
            ID = "id",
            PublishedAt = "published_at",
            Version = "version",
        };

        string expectedID = "id";
        string expectedPublishedAt = "published_at";
        string expectedVersion = "version";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedPublishedAt, model.PublishedAt);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PostTenantTemplatePublishResponse
        {
            ID = "id",
            PublishedAt = "published_at",
            Version = "version",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PostTenantTemplatePublishResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PostTenantTemplatePublishResponse
        {
            ID = "id",
            PublishedAt = "published_at",
            Version = "version",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PostTenantTemplatePublishResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedPublishedAt = "published_at";
        string expectedVersion = "version";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedPublishedAt, deserialized.PublishedAt);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PostTenantTemplatePublishResponse
        {
            ID = "id",
            PublishedAt = "published_at",
            Version = "version",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PostTenantTemplatePublishResponse
        {
            ID = "id",
            PublishedAt = "published_at",
            Version = "version",
        };

        PostTenantTemplatePublishResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
