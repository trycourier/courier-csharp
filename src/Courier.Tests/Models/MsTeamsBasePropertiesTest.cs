using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class MsTeamsBasePropertiesTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MsTeamsBaseProperties
        {
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };

        string expectedServiceUrl = "service_url";
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedServiceUrl, model.ServiceUrl);
        Assert.Equal(expectedTenantID, model.TenantID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MsTeamsBaseProperties
        {
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MsTeamsBaseProperties>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MsTeamsBaseProperties
        {
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MsTeamsBaseProperties>(element);
        Assert.NotNull(deserialized);

        string expectedServiceUrl = "service_url";
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedServiceUrl, deserialized.ServiceUrl);
        Assert.Equal(expectedTenantID, deserialized.TenantID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MsTeamsBaseProperties
        {
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };

        model.Validate();
    }
}
