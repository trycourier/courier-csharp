using System.Threading.Tasks;

namespace Courier.Tests.Services.Notifications.Draft;

public class DraftServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task RetrieveContent_Works()
    {
        var notificationContent = await this.client.Notifications.Draft.RetrieveContent(
            new() { ID = "id" }
        );
        notificationContent.Validate();
    }
}
