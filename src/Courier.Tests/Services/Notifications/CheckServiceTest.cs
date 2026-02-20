using System.Threading.Tasks;
using Courier.Models.Notifications;

namespace Courier.Tests.Services.Notifications;

public class CheckServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var check = await this.client.Notifications.Checks.Update(
            "submissionId",
            new()
            {
                ID = "id",
                Checks =
                [
                    new()
                    {
                        ID = "id",
                        Status = Status.Resolved,
                        Type = Type.Custom,
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        check.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var checks = await this.client.Notifications.Checks.List(
            "submissionId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
        checks.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Notifications.Checks.Delete(
            "submissionId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
    }
}
