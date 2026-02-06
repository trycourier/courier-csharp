using System.Text.Json;
using Courier.Core;
using Courier.Models.Tenants;

namespace Courier.Tests.Models.Tenants;

public class PostTenantTemplatePublishRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PostTenantTemplatePublishRequest { Version = "version" };

        string expectedVersion = "version";

        Assert.Equal(expectedVersion, model.Version);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PostTenantTemplatePublishRequest { Version = "version" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PostTenantTemplatePublishRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PostTenantTemplatePublishRequest { Version = "version" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PostTenantTemplatePublishRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedVersion = "version";

        Assert.Equal(expectedVersion, deserialized.Version);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PostTenantTemplatePublishRequest { Version = "version" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PostTenantTemplatePublishRequest { };

        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new PostTenantTemplatePublishRequest { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new PostTenantTemplatePublishRequest
        {
            // Null should be interpreted as omitted for these properties
            Version = null,
        };

        Assert.Null(model.Version);
        Assert.False(model.RawData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new PostTenantTemplatePublishRequest
        {
            // Null should be interpreted as omitted for these properties
            Version = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PostTenantTemplatePublishRequest { Version = "version" };

        PostTenantTemplatePublishRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
