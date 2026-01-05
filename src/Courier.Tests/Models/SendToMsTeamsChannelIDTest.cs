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
            ServiceURL = "service_url",
            TenantID = "tenant_id",
        };

        string expectedChannelID = "channel_id";
        string expectedServiceURL = "service_url";
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedChannelID, model.ChannelID);
        Assert.Equal(expectedServiceURL, model.ServiceURL);
        Assert.Equal(expectedTenantID, model.TenantID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SendToMsTeamsChannelID
        {
            ChannelID = "channel_id",
            ServiceURL = "service_url",
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
            ServiceURL = "service_url",
            TenantID = "tenant_id",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SendToMsTeamsChannelID>(element);
        Assert.NotNull(deserialized);

        string expectedChannelID = "channel_id";
        string expectedServiceURL = "service_url";
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedChannelID, deserialized.ChannelID);
        Assert.Equal(expectedServiceURL, deserialized.ServiceURL);
        Assert.Equal(expectedTenantID, deserialized.TenantID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SendToMsTeamsChannelID
        {
            ChannelID = "channel_id",
            ServiceURL = "service_url",
            TenantID = "tenant_id",
        };

        model.Validate();
    }
}
