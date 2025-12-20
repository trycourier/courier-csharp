using Courier.Models.Requests;

namespace Courier.Tests.Models.Requests;

public class RequestArchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RequestArchiveParams { RequestID = "request_id" };

        string expectedRequestID = "request_id";

        Assert.Equal(expectedRequestID, parameters.RequestID);
    }
}
