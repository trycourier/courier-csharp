using System.Threading.Tasks;

namespace TryCourier.Tests.Services.Journeys;

public class RunServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var journeyRunResponse = await this.client.Journeys.Runs.Retrieve(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        journeyRunResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var journeyRunListResponse = await this.client.Journeys.Runs.List(
            new(),
            TestContext.Current.CancellationToken
        );
        journeyRunListResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListSteps_Works()
    {
        var journeyRunStepsResponse = await this.client.Journeys.Runs.ListSteps(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        journeyRunStepsResponse.Validate();
    }
}
