using System.Text.Json;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class SendToMsTeamsChannelNameTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SendToMsTeamsChannelName
        {
            ChannelName = "channel_name",
            ServiceUrl = "service_url",
            TeamID = "team_id",
            TenantID = "tenant_id",
        };

        string expectedChannelName = "channel_name";
        string expectedServiceUrl = "service_url";
        string expectedTeamID = "team_id";
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedChannelName, model.ChannelName);
        Assert.Equal(expectedServiceUrl, model.ServiceUrl);
        Assert.Equal(expectedTeamID, model.TeamID);
        Assert.Equal(expectedTenantID, model.TenantID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SendToMsTeamsChannelName
        {
            ChannelName = "channel_name",
            ServiceUrl = "service_url",
            TeamID = "team_id",
            TenantID = "tenant_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SendToMsTeamsChannelName>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SendToMsTeamsChannelName
        {
            ChannelName = "channel_name",
            ServiceUrl = "service_url",
            TeamID = "team_id",
            TenantID = "tenant_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SendToMsTeamsChannelName>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedChannelName = "channel_name";
        string expectedServiceUrl = "service_url";
        string expectedTeamID = "team_id";
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedChannelName, deserialized.ChannelName);
        Assert.Equal(expectedServiceUrl, deserialized.ServiceUrl);
        Assert.Equal(expectedTeamID, deserialized.TeamID);
        Assert.Equal(expectedTenantID, deserialized.TenantID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SendToMsTeamsChannelName
        {
            ChannelName = "channel_name",
            ServiceUrl = "service_url",
            TeamID = "team_id",
            TenantID = "tenant_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SendToMsTeamsChannelName
        {
            ChannelName = "channel_name",
            ServiceUrl = "service_url",
            TeamID = "team_id",
            TenantID = "tenant_id",
        };

        SendToMsTeamsChannelName copied = new(model);

        Assert.Equal(model, copied);
    }
}
