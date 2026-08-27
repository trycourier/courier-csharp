using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;

namespace TryCourier.Tests.Models;

public class SendToMsTeamsEmailTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SendToMsTeamsEmail
        {
            Email = "email",
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };

        string expectedEmail = "email";
        string expectedServiceUrl = "service_url";
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedServiceUrl, model.ServiceUrl);
        Assert.Equal(expectedTenantID, model.TenantID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SendToMsTeamsEmail
        {
            Email = "email",
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SendToMsTeamsEmail>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SendToMsTeamsEmail
        {
            Email = "email",
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SendToMsTeamsEmail>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedEmail = "email";
        string expectedServiceUrl = "service_url";
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedServiceUrl, deserialized.ServiceUrl);
        Assert.Equal(expectedTenantID, deserialized.TenantID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SendToMsTeamsEmail
        {
            Email = "email",
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SendToMsTeamsEmail { Email = "email" };

        Assert.Null(model.ServiceUrl);
        Assert.False(model.RawData.ContainsKey("service_url"));
        Assert.Null(model.TenantID);
        Assert.False(model.RawData.ContainsKey("tenant_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SendToMsTeamsEmail { Email = "email" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SendToMsTeamsEmail
        {
            Email = "email",

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
        var model = new SendToMsTeamsEmail
        {
            Email = "email",

            // Null should be interpreted as omitted for these properties
            ServiceUrl = null,
            TenantID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SendToMsTeamsEmail
        {
            Email = "email",
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };

        SendToMsTeamsEmail copied = new(model);

        Assert.Equal(model, copied);
    }
}
