using Courier.Models.Send;

namespace Courier.Tests.Models.Send;

public class SendMessageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SendMessageResponse { RequestID = "1-65f240a0-47a6a120c8374de9bcf9f22c" };

        string expectedRequestID = "1-65f240a0-47a6a120c8374de9bcf9f22c";

        Assert.Equal(expectedRequestID, model.RequestID);
    }
}
