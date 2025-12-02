using Courier.Models.Inbound;

namespace Courier.Tests.Models.Inbound;

public class InboundTrackEventResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundTrackEventResponse
        {
            MessageID = "1-65f240a0-47a6a120c8374de9bcf9f22c",
        };

        string expectedMessageID = "1-65f240a0-47a6a120c8374de9bcf9f22c";

        Assert.Equal(expectedMessageID, model.MessageID);
    }
}
