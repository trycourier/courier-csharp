using System.Threading.Tasks;

namespace TryCourier.Tests.Services.Inbox;

public class MessageServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Inbox.Messages.Delete(
            "message_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Restore_Works()
    {
        await this.client.Inbox.Messages.Restore(
            "message_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
