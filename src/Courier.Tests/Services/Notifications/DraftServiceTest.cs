using System.Threading.Tasks;

namespace Courier.Tests.Services.Notifications;

public class DraftServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveContent_Works()
    {
        var notificationGetContent = await this.client.Notifications.Draft.RetrieveContent(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        notificationGetContent.Validate();
    }
}
