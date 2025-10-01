using System.Threading.Tasks;

namespace Courier.Tests.Services.Requests;

public class RequestServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Archive_Works()
    {
        await this.client.Requests.Archive(new() { RequestID = "request_id" });
    }
}
