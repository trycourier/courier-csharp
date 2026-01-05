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
}
