using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class MsTeamsRecipientTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MsTeamsRecipient
        {
            MsTeams = new SendToMsTeamsUserID()
            {
                ServiceUrl = "service_url",
                TenantID = "tenant_id",
                UserID = "user_id",
            },
        };

        MsTeams expectedMsTeams = new SendToMsTeamsUserID()
        {
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
            UserID = "user_id",
        };

        Assert.Equal(expectedMsTeams, model.MsTeams);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MsTeamsRecipient
        {
            MsTeams = new SendToMsTeamsUserID()
            {
                ServiceUrl = "service_url",
                TenantID = "tenant_id",
                UserID = "user_id",
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MsTeamsRecipient>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MsTeamsRecipient
        {
            MsTeams = new SendToMsTeamsUserID()
            {
                ServiceUrl = "service_url",
                TenantID = "tenant_id",
                UserID = "user_id",
            },
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<MsTeamsRecipient>(element);
        Assert.NotNull(deserialized);

        MsTeams expectedMsTeams = new SendToMsTeamsUserID()
        {
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
            UserID = "user_id",
        };

        Assert.Equal(expectedMsTeams, deserialized.MsTeams);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MsTeamsRecipient
        {
            MsTeams = new SendToMsTeamsUserID()
            {
                ServiceUrl = "service_url",
                TenantID = "tenant_id",
                UserID = "user_id",
            },
        };

        model.Validate();
    }
}
