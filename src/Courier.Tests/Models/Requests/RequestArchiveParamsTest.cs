using System;
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

    [Fact]
    public void Url_Works()
    {
        RequestArchiveParams parameters = new() { RequestID = "request_id" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/requests/request_id/archive"), url);
    }
}
