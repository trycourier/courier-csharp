using System;
using Courier.Models.Notifications;

namespace Courier.Tests.Models.Notifications;

public class NotificationPublishParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NotificationPublishParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        NotificationPublishParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/notifications/id/publish"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NotificationPublishParams { ID = "id" };

        NotificationPublishParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
