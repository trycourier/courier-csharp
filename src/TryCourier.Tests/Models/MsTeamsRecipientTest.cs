using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;

namespace TryCourier.Tests.Models;

public class MsTeamsRecipientTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MsTeamsRecipient
        {
            MsTeams = new SendToMsTeamsUserID()
            {
                UserID = "user_id",
                ServiceUrl = "service_url",
                TenantID = "tenant_id",
            },
        };

        MsTeams expectedMsTeams = new SendToMsTeamsUserID()
        {
            UserID = "user_id",
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
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
                UserID = "user_id",
                ServiceUrl = "service_url",
                TenantID = "tenant_id",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MsTeamsRecipient>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MsTeamsRecipient
        {
            MsTeams = new SendToMsTeamsUserID()
            {
                UserID = "user_id",
                ServiceUrl = "service_url",
                TenantID = "tenant_id",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MsTeamsRecipient>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        MsTeams expectedMsTeams = new SendToMsTeamsUserID()
        {
            UserID = "user_id",
            ServiceUrl = "service_url",
            TenantID = "tenant_id",
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
                UserID = "user_id",
                ServiceUrl = "service_url",
                TenantID = "tenant_id",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MsTeamsRecipient
        {
            MsTeams = new SendToMsTeamsUserID()
            {
                UserID = "user_id",
                ServiceUrl = "service_url",
                TenantID = "tenant_id",
            },
        };

        MsTeamsRecipient copied = new(model);

        Assert.Equal(model, copied);
    }
}
