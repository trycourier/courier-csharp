using System;
using Courier.Models.Notifications;

namespace Courier.Tests.Models.Notifications;

public class NotificationRetrieveContentParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NotificationRetrieveContentParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        NotificationRetrieveContentParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/notifications/id/content"), url);
    }
}
