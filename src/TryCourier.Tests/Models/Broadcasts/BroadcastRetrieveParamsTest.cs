using System;
using TryCourier.Models.Broadcasts;

namespace TryCourier.Tests.Models.Broadcasts;

public class BroadcastRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BroadcastRetrieveParams { BroadcastID = "broadcastId" };

        string expectedBroadcastID = "broadcastId";

        Assert.Equal(expectedBroadcastID, parameters.BroadcastID);
    }

    [Fact]
    public void Url_Works()
    {
        BroadcastRetrieveParams parameters = new() { BroadcastID = "broadcastId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.courier.com/broadcasts/broadcastId"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BroadcastRetrieveParams { BroadcastID = "broadcastId" };

        BroadcastRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
