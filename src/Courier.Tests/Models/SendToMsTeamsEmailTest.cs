using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class SendToMsTeamsEmailTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SendToMsTeamsEmail
        {
            Email = "email",
            ServiceURL = "service_url",
            TenantID = "tenant_id",
        };

        string expectedEmail = "email";
        string expectedServiceURL = "service_url";
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedServiceURL, model.ServiceURL);
        Assert.Equal(expectedTenantID, model.TenantID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SendToMsTeamsEmail
        {
            Email = "email",
            ServiceURL = "service_url",
            TenantID = "tenant_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SendToMsTeamsEmail>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SendToMsTeamsEmail
        {
            Email = "email",
            ServiceURL = "service_url",
            TenantID = "tenant_id",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SendToMsTeamsEmail>(element);
        Assert.NotNull(deserialized);

        string expectedEmail = "email";
        string expectedServiceURL = "service_url";
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedServiceURL, deserialized.ServiceURL);
        Assert.Equal(expectedTenantID, deserialized.TenantID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SendToMsTeamsEmail
        {
            Email = "email",
            ServiceURL = "service_url",
            TenantID = "tenant_id",
        };

        model.Validate();
    }
}
