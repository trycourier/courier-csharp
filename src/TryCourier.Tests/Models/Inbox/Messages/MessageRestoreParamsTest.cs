using System;
using TryCourier.Models.Inbox.Messages;

namespace TryCourier.Tests.Models.Inbox.Messages;

public class MessageRestoreParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MessageRestoreParams { MessageID = "message_id" };

        string expectedMessageID = "message_id";

        Assert.Equal(expectedMessageID, parameters.MessageID);
    }

    [Fact]
    public void Url_Works()
    {
        MessageRestoreParams parameters = new() { MessageID = "message_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/inbox/messages/message_id/restore"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MessageRestoreParams { MessageID = "message_id" };

        MessageRestoreParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
