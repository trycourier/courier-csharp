using System.Threading.Tasks;

namespace TryCourier.Tests.Services.Digests;

public class ScheduleServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListInstances_Works()
    {
        var digestInstanceListResponse = await this.client.Digests.Schedules.ListInstances(
            "schedule_id",
            new(),
            TestContext.Current.CancellationToken
        );
        digestInstanceListResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Release_Works()
    {
        await this.client.Digests.Schedules.Release(
            "schedule_id",
            new(),
            TestContext.Current.CancellationToken
        );
    }
}
