using System;
using Courier.Models.Messages;

namespace Courier.Tests.Models.Messages;

public class MessageContentParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MessageContentParams { MessageID = "message_id" };

        string expectedMessageID = "message_id";

        Assert.Equal(expectedMessageID, parameters.MessageID);
    }

    [Fact]
    public void Url_Works()
    {
        MessageContentParams parameters = new() { MessageID = "message_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/messages/message_id/output"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MessageContentParams { MessageID = "message_id" };

        MessageContentParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
