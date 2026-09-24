using System.Threading.Tasks;

namespace TryCourier.Tests.Services.Notifications.Previews;

public class RunServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var previewRun = await this.client.Notifications.Previews.Runs.Create(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        previewRun.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var previewRunDetail = await this.client.Notifications.Previews.Runs.Retrieve(
            "previewRunId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
        previewRunDetail.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var previewRunListResponse = await this.client.Notifications.Previews.Runs.List(
            "id",
            new(),
            TestContext.Current.CancellationToken
        );
        previewRunListResponse.Validate();
    }
}
