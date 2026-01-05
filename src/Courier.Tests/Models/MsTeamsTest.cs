using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class MsTeamsTest : TestBase
{
    [Fact]
    public void SendToMsTeamsUserIDValidationWorks()
    {
        MsTeams value = new(
            new SendToMsTeamsUserID()
            {
                ServiceURL = "service_url",
                TenantID = "tenant_id",
                UserID = "user_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void SendToMsTeamsEmailValidationWorks()
    {
        MsTeams value = new(
            new SendToMsTeamsEmail()
            {
                Email = "email",
                ServiceURL = "service_url",
                TenantID = "tenant_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void SendToMsTeamsChannelIDValidationWorks()
    {
        MsTeams value = new(
            new SendToMsTeamsChannelID()
            {
                ChannelID = "channel_id",
                ServiceURL = "service_url",
                TenantID = "tenant_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void SendToMsTeamsConversationIDValidationWorks()
    {
        MsTeams value = new(
            new SendToMsTeamsConversationID()
            {
                ConversationID = "conversation_id",
                ServiceURL = "service_url",
                TenantID = "tenant_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void SendToMsTeamsChannelNameValidationWorks()
    {
        MsTeams value = new(
            new SendToMsTeamsChannelName()
            {
                ChannelName = "channel_name",
                ServiceURL = "service_url",
                TeamID = "team_id",
                TenantID = "tenant_id",
            }
        );
        value.Validate();
    }

    [Fact]
    public void SendToMsTeamsUserIDSerializationRoundtripWorks()
    {
        MsTeams value = new(
            new SendToMsTeamsUserID()
            {
                ServiceURL = "service_url",
                TenantID = "tenant_id",
                UserID = "user_id",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MsTeams>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SendToMsTeamsEmailSerializationRoundtripWorks()
    {
        MsTeams value = new(
            new SendToMsTeamsEmail()
            {
                Email = "email",
                ServiceURL = "service_url",
                TenantID = "tenant_id",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MsTeams>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SendToMsTeamsChannelIDSerializationRoundtripWorks()
    {
        MsTeams value = new(
            new SendToMsTeamsChannelID()
            {
                ChannelID = "channel_id",
                ServiceURL = "service_url",
                TenantID = "tenant_id",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MsTeams>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SendToMsTeamsConversationIDSerializationRoundtripWorks()
    {
        MsTeams value = new(
            new SendToMsTeamsConversationID()
            {
                ConversationID = "conversation_id",
                ServiceURL = "service_url",
                TenantID = "tenant_id",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MsTeams>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SendToMsTeamsChannelNameSerializationRoundtripWorks()
    {
        MsTeams value = new(
            new SendToMsTeamsChannelName()
            {
                ChannelName = "channel_name",
                ServiceURL = "service_url",
                TeamID = "team_id",
                TenantID = "tenant_id",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MsTeams>(element);

        Assert.Equal(value, deserialized);
    }
}
