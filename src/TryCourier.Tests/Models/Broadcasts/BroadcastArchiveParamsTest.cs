using System;
using TryCourier.Models.Broadcasts;

namespace TryCourier.Tests.Models.Broadcasts;

public class BroadcastArchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BroadcastArchiveParams { BroadcastID = "broadcastId" };

        string expectedBroadcastID = "broadcastId";

        Assert.Equal(expectedBroadcastID, parameters.BroadcastID);
    }

    [Fact]
    public void Url_Works()
    {
        BroadcastArchiveParams parameters = new() { BroadcastID = "broadcastId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.courier.com/broadcasts/broadcastId"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BroadcastArchiveParams { BroadcastID = "broadcastId" };

        BroadcastArchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
