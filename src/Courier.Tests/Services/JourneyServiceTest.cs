using System.Threading.Tasks;

namespace Courier.Tests.Services;

public class JourneyServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var journeysListResponse = await this.client.Journeys.List(
            new(),
            TestContext.Current.CancellationToken
        );
        journeysListResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Invoke_Works()
    {
        var journeysInvokeResponse = await this.client.Journeys.Invoke(
            "templateId",
            new(),
            TestContext.Current.CancellationToken
        );
        journeysInvokeResponse.Validate();
    }
}
