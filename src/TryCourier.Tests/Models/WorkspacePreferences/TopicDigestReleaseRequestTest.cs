using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.WorkspacePreferences;

namespace TryCourier.Tests.Models.WorkspacePreferences;

public class TopicDigestReleaseRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TopicDigestReleaseRequest { UserID = "x", TenantID = "x" };

        string expectedUserID = "x";
        string expectedTenantID = "x";

        Assert.Equal(expectedUserID, model.UserID);
        Assert.Equal(expectedTenantID, model.TenantID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TopicDigestReleaseRequest { UserID = "x", TenantID = "x" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopicDigestReleaseRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TopicDigestReleaseRequest { UserID = "x", TenantID = "x" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TopicDigestReleaseRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedUserID = "x";
        string expectedTenantID = "x";

        Assert.Equal(expectedUserID, deserialized.UserID);
        Assert.Equal(expectedTenantID, deserialized.TenantID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TopicDigestReleaseRequest { UserID = "x", TenantID = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TopicDigestReleaseRequest { UserID = "x" };

        Assert.Null(model.TenantID);
        Assert.False(model.RawData.ContainsKey("tenant_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TopicDigestReleaseRequest { UserID = "x" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TopicDigestReleaseRequest
        {
            UserID = "x",

            // Null should be interpreted as omitted for these properties
            TenantID = null,
        };

        Assert.Null(model.TenantID);
        Assert.False(model.RawData.ContainsKey("tenant_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new TopicDigestReleaseRequest
        {
            UserID = "x",

            // Null should be interpreted as omitted for these properties
            TenantID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TopicDigestReleaseRequest { UserID = "x", TenantID = "x" };

        TopicDigestReleaseRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
