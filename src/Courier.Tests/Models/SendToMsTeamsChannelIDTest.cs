using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class SendToMsTeamsChannelIDTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SendToMsTeamsChannelID
        {
            ChannelID = "channel_id",
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };

        string expectedChannelID = "channel_id";
        string expectedServiceUrl = "service_url";
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedChannelID, model.ChannelID);
        Assert.Equal(expectedServiceUrl, model.ServiceUrl);
        Assert.Equal(expectedTenantID, model.TenantID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SendToMsTeamsChannelID
        {
            ChannelID = "channel_id",
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SendToMsTeamsChannelID>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SendToMsTeamsChannelID
        {
            ChannelID = "channel_id",
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SendToMsTeamsChannelID>(element);
        Assert.NotNull(deserialized);

        string expectedChannelID = "channel_id";
        string expectedServiceUrl = "service_url";
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedChannelID, deserialized.ChannelID);
        Assert.Equal(expectedServiceUrl, deserialized.ServiceUrl);
        Assert.Equal(expectedTenantID, deserialized.TenantID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SendToMsTeamsChannelID
        {
            ChannelID = "channel_id",
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };

        model.Validate();
    }
}
