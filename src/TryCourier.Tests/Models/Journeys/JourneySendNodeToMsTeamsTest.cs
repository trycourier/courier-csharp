using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Journeys;

namespace TryCourier.Tests.Models.Journeys;

public class JourneySendNodeToMsTeamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneySendNodeToMsTeams
        {
            ChannelID = "x",
            ChannelName = "x",
            Email = "x",
            ServiceUrl = "x",
            TeamID = "x",
            TenantID = "x",
            UserID = "x",
        };

        string expectedChannelID = "x";
        string expectedChannelName = "x";
        string expectedEmail = "x";
        string expectedServiceUrl = "x";
        string expectedTeamID = "x";
        string expectedTenantID = "x";
        string expectedUserID = "x";

        Assert.Equal(expectedChannelID, model.ChannelID);
        Assert.Equal(expectedChannelName, model.ChannelName);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedServiceUrl, model.ServiceUrl);
        Assert.Equal(expectedTeamID, model.TeamID);
        Assert.Equal(expectedTenantID, model.TenantID);
        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneySendNodeToMsTeams
        {
            ChannelID = "x",
            ChannelName = "x",
            Email = "x",
            ServiceUrl = "x",
            TeamID = "x",
            TenantID = "x",
            UserID = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneySendNodeToMsTeams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneySendNodeToMsTeams
        {
            ChannelID = "x",
            ChannelName = "x",
            Email = "x",
            ServiceUrl = "x",
            TeamID = "x",
            TenantID = "x",
            UserID = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneySendNodeToMsTeams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedChannelID = "x";
        string expectedChannelName = "x";
        string expectedEmail = "x";
        string expectedServiceUrl = "x";
        string expectedTeamID = "x";
        string expectedTenantID = "x";
        string expectedUserID = "x";

        Assert.Equal(expectedChannelID, deserialized.ChannelID);
        Assert.Equal(expectedChannelName, deserialized.ChannelName);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedServiceUrl, deserialized.ServiceUrl);
        Assert.Equal(expectedTeamID, deserialized.TeamID);
        Assert.Equal(expectedTenantID, deserialized.TenantID);
        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneySendNodeToMsTeams
        {
            ChannelID = "x",
            ChannelName = "x",
            Email = "x",
            ServiceUrl = "x",
            TeamID = "x",
            TenantID = "x",
            UserID = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new JourneySendNodeToMsTeams { };

        Assert.Null(model.ChannelID);
        Assert.False(model.RawData.ContainsKey("channel_id"));
        Assert.Null(model.ChannelName);
        Assert.False(model.RawData.ContainsKey("channel_name"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.ServiceUrl);
        Assert.False(model.RawData.ContainsKey("service_url"));
        Assert.Null(model.TeamID);
        Assert.False(model.RawData.ContainsKey("team_id"));
        Assert.Null(model.TenantID);
        Assert.False(model.RawData.ContainsKey("tenant_id"));
        Assert.Null(model.UserID);
        Assert.False(model.RawData.ContainsKey("user_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new JourneySendNodeToMsTeams { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new JourneySendNodeToMsTeams
        {
            // Null should be interpreted as omitted for these properties
            ChannelID = null,
            ChannelName = null,
            Email = null,
            ServiceUrl = null,
            TeamID = null,
            TenantID = null,
            UserID = null,
        };

        Assert.Null(model.ChannelID);
        Assert.False(model.RawData.ContainsKey("channel_id"));
        Assert.Null(model.ChannelName);
        Assert.False(model.RawData.ContainsKey("channel_name"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.ServiceUrl);
        Assert.False(model.RawData.ContainsKey("service_url"));
        Assert.Null(model.TeamID);
        Assert.False(model.RawData.ContainsKey("team_id"));
        Assert.Null(model.TenantID);
        Assert.False(model.RawData.ContainsKey("tenant_id"));
        Assert.Null(model.UserID);
        Assert.False(model.RawData.ContainsKey("user_id"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new JourneySendNodeToMsTeams
        {
            // Null should be interpreted as omitted for these properties
            ChannelID = null,
            ChannelName = null,
            Email = null,
            ServiceUrl = null,
            TeamID = null,
            TenantID = null,
            UserID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneySendNodeToMsTeams
        {
            ChannelID = "x",
            ChannelName = "x",
            Email = "x",
            ServiceUrl = "x",
            TeamID = "x",
            TenantID = "x",
            UserID = "x",
        };

        JourneySendNodeToMsTeams copied = new(model);

        Assert.Equal(model, copied);
    }
}
