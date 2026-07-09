using System;
using TryCourier.Models.Messages;

namespace TryCourier.Tests.Models.Messages;

public class MessageResendParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MessageResendParams { MessageID = "message_id" };

        string expectedMessageID = "message_id";

        Assert.Equal(expectedMessageID, parameters.MessageID);
    }

    [Fact]
    public void Url_Works()
    {
        MessageResendParams parameters = new() { MessageID = "message_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.courier.com/messages/message_id/resend"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new MessageResendParams { MessageID = "message_id" };

        MessageResendParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
