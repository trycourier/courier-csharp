using System.Threading.Tasks;
using Courier.Models.Notifications.BaseCheckProperties;

namespace Courier.Tests.Services.Notifications.Checks;

public class CheckServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var check = await this.client.Notifications.Checks.Update(
            new()
            {
                ID = "id",
                SubmissionID = "submissionId",
                Checks =
                [
                    new()
                    {
                        ID = "id",
                        Status = Status.Resolved,
                        Type = Type.Custom,
                    },
                ],
            }
        );
        check.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var checks = await this.client.Notifications.Checks.List(
            new() { ID = "id", SubmissionID = "submissionId" }
        );
        checks.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delete_Works()
    {
        await this.client.Notifications.Checks.Delete(
            new() { ID = "id", SubmissionID = "submissionId" }
        );
    }
}
