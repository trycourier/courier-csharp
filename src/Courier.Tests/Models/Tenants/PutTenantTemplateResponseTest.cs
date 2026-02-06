using System.Text.Json;
using Courier.Core;
using Courier.Models.Tenants;

namespace Courier.Tests.Models.Tenants;

public class PutTenantTemplateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PutTenantTemplateResponse
        {
            ID = "id",
            Version = "version",
            PublishedAt = "published_at",
        };

        string expectedID = "id";
        string expectedVersion = "version";
        string expectedPublishedAt = "published_at";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedVersion, model.Version);
        Assert.Equal(expectedPublishedAt, model.PublishedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PutTenantTemplateResponse
        {
            ID = "id",
            Version = "version",
            PublishedAt = "published_at",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PutTenantTemplateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PutTenantTemplateResponse
        {
            ID = "id",
            Version = "version",
            PublishedAt = "published_at",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PutTenantTemplateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedVersion = "version";
        string expectedPublishedAt = "published_at";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedVersion, deserialized.Version);
        Assert.Equal(expectedPublishedAt, deserialized.PublishedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PutTenantTemplateResponse
        {
            ID = "id",
            Version = "version",
            PublishedAt = "published_at",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PutTenantTemplateResponse { ID = "id", Version = "version" };

        Assert.Null(model.PublishedAt);
        Assert.False(model.RawData.ContainsKey("published_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PutTenantTemplateResponse { ID = "id", Version = "version" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PutTenantTemplateResponse
        {
            ID = "id",
            Version = "version",

            PublishedAt = null,
        };

        Assert.Null(model.PublishedAt);
        Assert.True(model.RawData.ContainsKey("published_at"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PutTenantTemplateResponse
        {
            ID = "id",
            Version = "version",

            PublishedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PutTenantTemplateResponse
        {
            ID = "id",
            Version = "version",
            PublishedAt = "published_at",
        };

        PutTenantTemplateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
