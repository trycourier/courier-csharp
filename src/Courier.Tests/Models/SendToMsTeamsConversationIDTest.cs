using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class SendToMsTeamsConversationIDTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SendToMsTeamsConversationID
        {
            ConversationID = "conversation_id",
            ServiceURL = "service_url",
            TenantID = "tenant_id",
        };

        string expectedConversationID = "conversation_id";
        string expectedServiceURL = "service_url";
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedConversationID, model.ConversationID);
        Assert.Equal(expectedServiceURL, model.ServiceURL);
        Assert.Equal(expectedTenantID, model.TenantID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SendToMsTeamsConversationID
        {
            ConversationID = "conversation_id",
            ServiceURL = "service_url",
            TenantID = "tenant_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SendToMsTeamsConversationID>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SendToMsTeamsConversationID
        {
            ConversationID = "conversation_id",
            ServiceURL = "service_url",
            TenantID = "tenant_id",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SendToMsTeamsConversationID>(element);
        Assert.NotNull(deserialized);

        string expectedConversationID = "conversation_id";
        string expectedServiceURL = "service_url";
        string expectedTenantID = "tenant_id";

        Assert.Equal(expectedConversationID, deserialized.ConversationID);
        Assert.Equal(expectedServiceURL, deserialized.ServiceURL);
        Assert.Equal(expectedTenantID, deserialized.TenantID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SendToMsTeamsConversationID
        {
            ConversationID = "conversation_id",
            ServiceURL = "service_url",
            TenantID = "tenant_id",
        };

        model.Validate();
    }
}
