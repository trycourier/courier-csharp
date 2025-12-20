using Courier.Models.Messages;

namespace Courier.Tests.Models.Messages;

public class MessageRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new MessageRetrieveParams { MessageID = "message_id" };

        string expectedMessageID = "message_id";

        Assert.Equal(expectedMessageID, parameters.MessageID);
    }
}
