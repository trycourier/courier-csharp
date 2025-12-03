using System.Text.Json;
using Courier.Models.Tenants;

namespace Courier.Tests.Models.Tenants;

public class BaseTemplateTenantAssociationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BaseTemplateTenantAssociation
        {
            ID = "id",
            CreatedAt = "created_at",
            PublishedAt = "published_at",
            UpdatedAt = "updated_at",
            Version = "version",
        };

        string expectedID = "id";
        string expectedCreatedAt = "created_at";
        string expectedPublishedAt = "published_at";
        string expectedUpdatedAt = "updated_at";
        string expectedVersion = "version";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedPublishedAt, model.PublishedAt);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BaseTemplateTenantAssociation
        {
            ID = "id",
            CreatedAt = "created_at",
            PublishedAt = "published_at",
            UpdatedAt = "updated_at",
            Version = "version",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BaseTemplateTenantAssociation>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BaseTemplateTenantAssociation
        {
            ID = "id",
            CreatedAt = "created_at",
            PublishedAt = "published_at",
            UpdatedAt = "updated_at",
            Version = "version",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BaseTemplateTenantAssociation>(json);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCreatedAt = "created_at";
        string expectedPublishedAt = "published_at";
        string expectedUpdatedAt = "updated_at";
        string expectedVersion = "version";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedPublishedAt, deserialized.PublishedAt);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BaseTemplateTenantAssociation
        {
            ID = "id",
            CreatedAt = "created_at",
            PublishedAt = "published_at",
            UpdatedAt = "updated_at",
            Version = "version",
        };

        model.Validate();
    }
}
