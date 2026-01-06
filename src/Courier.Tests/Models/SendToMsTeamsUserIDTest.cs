using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class SendToMsTeamsUserIDTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SendToMsTeamsUserID
        {
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
            UserID = "user_id",
        };

        string expectedServiceUrl = "service_url";
        string expectedTenantID = "tenant_id";
        string expectedUserID = "user_id";

        Assert.Equal(expectedServiceUrl, model.ServiceUrl);
        Assert.Equal(expectedTenantID, model.TenantID);
        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SendToMsTeamsUserID
        {
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
            UserID = "user_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SendToMsTeamsUserID>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SendToMsTeamsUserID
        {
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
            UserID = "user_id",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SendToMsTeamsUserID>(element);
        Assert.NotNull(deserialized);

        string expectedServiceUrl = "service_url";
        string expectedTenantID = "tenant_id";
        string expectedUserID = "user_id";

        Assert.Equal(expectedServiceUrl, deserialized.ServiceUrl);
        Assert.Equal(expectedTenantID, deserialized.TenantID);
        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SendToMsTeamsUserID
        {
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
            UserID = "user_id",
        };

        model.Validate();
    }
}
