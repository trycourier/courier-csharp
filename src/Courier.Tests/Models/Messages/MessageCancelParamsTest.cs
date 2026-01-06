using System;
using Courier.Models.Messages;

namespace Courier.Tests.Models.Messages;

public class MessageCancelParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MessageCancelParams { MessageID = "message_id" };

        string expectedMessageID = "message_id";

        Assert.Equal(expectedMessageID, parameters.MessageID);
    }

    [Fact]
    public void Url_Works()
    {
        MessageCancelParams parameters = new() { MessageID = "message_id" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/messages/message_id/cancel"), url);
    }
}
