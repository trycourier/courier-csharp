using System.Threading.Tasks;

namespace Courier.Tests.Services;

public class RequestServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Archive_Works()
    {
        await this.client.Requests.Archive(
            "request_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
