using System;
using Courier.Models.Notifications;

namespace Courier.Tests.Models.Notifications;

public class NotificationPublishParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NotificationPublishParams { ID = "id", Version = "v321669910225" };

        string expectedID = "id";
        string expectedVersion = "v321669910225";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedVersion, parameters.Version);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new NotificationPublishParams { ID = "id" };

        Assert.Null(parameters.Version);
        Assert.False(parameters.RawBodyData.ContainsKey("version"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new NotificationPublishParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Version = null,
        };

        Assert.Null(parameters.Version);
        Assert.False(parameters.RawBodyData.ContainsKey("version"));
    }

    [Fact]
    public void Url_Works()
    {
        NotificationPublishParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.courier.com/notifications/id/publish"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NotificationPublishParams { ID = "id", Version = "v321669910225" };

        NotificationPublishParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
