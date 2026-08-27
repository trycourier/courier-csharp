using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;

namespace TryCourier.Tests.Models;

public class SendToMsTeamsUserIDTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SendToMsTeamsUserID
        {
            UserID = "user_id",
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };

        string expectedUserID = "user_id";
        string expectedServiceUrl = "service_url";
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedUserID, model.UserID);
        Assert.Equal(expectedServiceUrl, model.ServiceUrl);
        Assert.Equal(expectedTenantID, model.TenantID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SendToMsTeamsUserID
        {
            UserID = "user_id",
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SendToMsTeamsUserID>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SendToMsTeamsUserID
        {
            UserID = "user_id",
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SendToMsTeamsUserID>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedUserID = "user_id";
        string expectedServiceUrl = "service_url";
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedUserID, deserialized.UserID);
        Assert.Equal(expectedServiceUrl, deserialized.ServiceUrl);
        Assert.Equal(expectedTenantID, deserialized.TenantID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SendToMsTeamsUserID
        {
            UserID = "user_id",
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SendToMsTeamsUserID { UserID = "user_id" };

        Assert.Null(model.ServiceUrl);
        Assert.False(model.RawData.ContainsKey("service_url"));
        Assert.Null(model.TenantID);
        Assert.False(model.RawData.ContainsKey("tenant_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SendToMsTeamsUserID { UserID = "user_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SendToMsTeamsUserID
        {
            UserID = "user_id",

            // Null should be interpreted as omitted for these properties
            ServiceUrl = null,
            TenantID = null,
        };

        Assert.Null(model.ServiceUrl);
        Assert.False(model.RawData.ContainsKey("service_url"));
        Assert.Null(model.TenantID);
        Assert.False(model.RawData.ContainsKey("tenant_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SendToMsTeamsUserID
        {
            UserID = "user_id",

            // Null should be interpreted as omitted for these properties
            ServiceUrl = null,
            TenantID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SendToMsTeamsUserID
        {
            UserID = "user_id",
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };

        SendToMsTeamsUserID copied = new(model);

        Assert.Equal(model, copied);
    }
}
