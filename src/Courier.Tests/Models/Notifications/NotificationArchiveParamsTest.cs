using System;
using Courier.Models.Notifications;

namespace Courier.Tests.Models.Notifications;

public class NotificationArchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NotificationArchiveParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        NotificationArchiveParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/notifications/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NotificationArchiveParams { ID = "id" };

        NotificationArchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
