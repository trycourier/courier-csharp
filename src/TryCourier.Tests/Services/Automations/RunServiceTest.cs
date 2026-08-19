using System.Threading.Tasks;

namespace TryCourier.Tests.Services.Automations;

public class RunServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var automationRunListResponse = await this.client.Automations.Runs.List(
            new(),
            TestContext.Current.CancellationToken
        );
        automationRunListResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListSteps_Works()
    {
        var automationRunStepsResponse = await this.client.Automations.Runs.ListSteps(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        automationRunStepsResponse.Validate();
    }
}
