using System.Text.Json;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class MsTeamsTest : TestBase
{
    [Fact]
    public void SendToMsTeamsUserIDValidationWorks()
    {
        MsTeams value = new SendToMsTeamsUserID()
        {
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
            UserID = "user_id",
        };
        value.Validate();
    }

    [Fact]
    public void SendToMsTeamsEmailValidationWorks()
    {
        MsTeams value = new SendToMsTeamsEmail()
        {
            Email = "email",
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };
        value.Validate();
    }

    [Fact]
    public void SendToMsTeamsChannelIDValidationWorks()
    {
        MsTeams value = new SendToMsTeamsChannelID()
        {
            ChannelID = "channel_id",
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };
        value.Validate();
    }

    [Fact]
    public void SendToMsTeamsConversationIDValidationWorks()
    {
        MsTeams value = new SendToMsTeamsConversationID()
        {
            ConversationID = "conversation_id",
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };
        value.Validate();
    }

    [Fact]
    public void SendToMsTeamsChannelNameValidationWorks()
    {
        MsTeams value = new SendToMsTeamsChannelName()
        {
            ChannelName = "channel_name",
            ServiceUrl = "service_url",
            TeamID = "team_id",
            TenantID = "tenant_id",
        };
        value.Validate();
    }

    [Fact]
    public void SendToMsTeamsUserIDSerializationRoundtripWorks()
    {
        MsTeams value = new SendToMsTeamsUserID()
        {
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
            UserID = "user_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MsTeams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SendToMsTeamsEmailSerializationRoundtripWorks()
    {
        MsTeams value = new SendToMsTeamsEmail()
        {
            Email = "email",
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MsTeams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SendToMsTeamsChannelIDSerializationRoundtripWorks()
    {
        MsTeams value = new SendToMsTeamsChannelID()
        {
            ChannelID = "channel_id",
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MsTeams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SendToMsTeamsConversationIDSerializationRoundtripWorks()
    {
        MsTeams value = new SendToMsTeamsConversationID()
        {
            ConversationID = "conversation_id",
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MsTeams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SendToMsTeamsChannelNameSerializationRoundtripWorks()
    {
        MsTeams value = new SendToMsTeamsChannelName()
        {
            ChannelName = "channel_name",
            ServiceUrl = "service_url",
            TeamID = "team_id",
            TenantID = "tenant_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MsTeams>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
