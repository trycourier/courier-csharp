using System.Threading.Tasks;

namespace Courier.Tests.Services.Notifications;

public class NotificationServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var notifications = await this.client.Notifications.List();
        notifications.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task RetrieveContent_Works()
    {
        var notificationContent = await this.client.Notifications.RetrieveContent(
            new() { ID = "id" }
        );
        notificationContent.Validate();
    }
}
