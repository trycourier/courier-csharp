using System;
using TryCourier.Models.Broadcasts;

namespace TryCourier.Tests.Models.Broadcasts;

public class BroadcastUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BroadcastUpdateParams
        {
            BroadcastID = "broadcastId",
            Name = "Spring Sale Announcement (v2)",
        };

        string expectedBroadcastID = "broadcastId";
        string expectedName = "Spring Sale Announcement (v2)";

        Assert.Equal(expectedBroadcastID, parameters.BroadcastID);
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void Url_Works()
    {
        BroadcastUpdateParams parameters = new()
        {
            BroadcastID = "broadcastId",
            Name = "Spring Sale Announcement (v2)",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.courier.com/broadcasts/broadcastId"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BroadcastUpdateParams
        {
            BroadcastID = "broadcastId",
            Name = "Spring Sale Announcement (v2)",
        };

        BroadcastUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
