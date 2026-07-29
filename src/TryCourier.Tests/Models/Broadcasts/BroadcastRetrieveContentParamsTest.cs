using System;
using TryCourier.Models.Broadcasts;

namespace TryCourier.Tests.Models.Broadcasts;

public class BroadcastRetrieveContentParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BroadcastRetrieveContentParams
        {
            BroadcastID = "broadcastId",
            Version = "version",
        };

        string expectedBroadcastID = "broadcastId";
        string expectedVersion = "version";

        Assert.Equal(expectedBroadcastID, parameters.BroadcastID);
        Assert.Equal(expectedVersion, parameters.Version);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BroadcastRetrieveContentParams { BroadcastID = "broadcastId" };

        Assert.Null(parameters.Version);
        Assert.False(parameters.RawQueryData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new BroadcastRetrieveContentParams
        {
            BroadcastID = "broadcastId",

            // Null should be interpreted as omitted for these properties
            Version = null,
        };

        Assert.Null(parameters.Version);
        Assert.False(parameters.RawQueryData.ContainsKey("version"));
    }

    [Fact]
    public void Url_Works()
    {
        BroadcastRetrieveContentParams parameters = new()
        {
            BroadcastID = "broadcastId",
            Version = "version",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/broadcasts/broadcastId/content?version=version"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new BroadcastRetrieveContentParams
        {
            BroadcastID = "broadcastId",
            Version = "version",
        };

        BroadcastRetrieveContentParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
