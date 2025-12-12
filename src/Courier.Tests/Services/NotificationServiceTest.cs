using System.Threading.Tasks;

namespace Courier.Tests.Services;

public class NotificationServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var notifications = await this.client.Notifications.List(
            new(),
            TestContext.Current.CancellationToken
        );
        notifications.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task RetrieveContent_Works()
    {
        var notificationGetContent = await this.client.Notifications.RetrieveContent(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        notificationGetContent.Validate();
    }
}
