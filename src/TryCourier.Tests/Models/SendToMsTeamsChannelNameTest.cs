using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;

namespace TryCourier.Tests.Models;

public class SendToMsTeamsChannelNameTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SendToMsTeamsChannelName
        {
            ChannelName = "channel_name",
            TeamID = "team_id",
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };

        string expectedChannelName = "channel_name";
        string expectedTeamID = "team_id";
        string expectedServiceUrl = "service_url";
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedChannelName, model.ChannelName);
        Assert.Equal(expectedTeamID, model.TeamID);
        Assert.Equal(expectedServiceUrl, model.ServiceUrl);
        Assert.Equal(expectedTenantID, model.TenantID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SendToMsTeamsChannelName
        {
            ChannelName = "channel_name",
            TeamID = "team_id",
            ServiceUrl = "service_url",
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
            TeamID = "team_id",
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SendToMsTeamsChannelName>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedChannelName = "channel_name";
        string expectedTeamID = "team_id";
        string expectedServiceUrl = "service_url";
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedChannelName, deserialized.ChannelName);
        Assert.Equal(expectedTeamID, deserialized.TeamID);
        Assert.Equal(expectedServiceUrl, deserialized.ServiceUrl);
        Assert.Equal(expectedTenantID, deserialized.TenantID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SendToMsTeamsChannelName
        {
            ChannelName = "channel_name",
            TeamID = "team_id",
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SendToMsTeamsChannelName
        {
            ChannelName = "channel_name",
            TeamID = "team_id",
        };

        Assert.Null(model.ServiceUrl);
        Assert.False(model.RawData.ContainsKey("service_url"));
        Assert.Null(model.TenantID);
        Assert.False(model.RawData.ContainsKey("tenant_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SendToMsTeamsChannelName
        {
            ChannelName = "channel_name",
            TeamID = "team_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SendToMsTeamsChannelName
        {
            ChannelName = "channel_name",
            TeamID = "team_id",

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
        var model = new SendToMsTeamsChannelName
        {
            ChannelName = "channel_name",
            TeamID = "team_id",

            // Null should be interpreted as omitted for these properties
            ServiceUrl = null,
            TenantID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SendToMsTeamsChannelName
        {
            ChannelName = "channel_name",
            TeamID = "team_id",
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };

        SendToMsTeamsChannelName copied = new(model);

        Assert.Equal(model, copied);
    }
}
