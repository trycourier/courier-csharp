using System;
using TryCourier.Models.Broadcasts;

namespace TryCourier.Tests.Models.Broadcasts;

public class BroadcastCancelParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BroadcastCancelParams { BroadcastID = "broadcastId" };

        string expectedBroadcastID = "broadcastId";

        Assert.Equal(expectedBroadcastID, parameters.BroadcastID);
    }

    [Fact]
    public void Url_Works()
    {
        BroadcastCancelParams parameters = new() { BroadcastID = "broadcastId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/broadcasts/broadcastId/cancel"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BroadcastCancelParams { BroadcastID = "broadcastId" };

        BroadcastCancelParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
