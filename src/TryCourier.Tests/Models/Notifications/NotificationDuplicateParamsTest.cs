using System;
using TryCourier.Models.Notifications;

namespace TryCourier.Tests.Models.Notifications;

public class NotificationDuplicateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new NotificationDuplicateParams { ID = "id" };

        string expectedID = "id";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        NotificationDuplicateParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.courier.com/notifications/id/duplicate"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new NotificationDuplicateParams { ID = "id" };

        NotificationDuplicateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
