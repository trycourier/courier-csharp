using System.Collections.Generic;
using Courier.Models.Notifications;
using Courier.Models.Notifications.Checks;

namespace Courier.Tests.Models.Notifications.Checks;

public class CheckUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CheckUpdateParams
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
        };

        string expectedID = "id";
        string expectedSubmissionID = "submissionId";
        List<BaseCheck> expectedChecks =
        [
            new()
            {
                ID = "id",
                Status = Status.Resolved,
                Type = Type.Custom,
            },
        ];

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedSubmissionID, parameters.SubmissionID);
        Assert.Equal(expectedChecks.Count, parameters.Checks.Count);
        for (int i = 0; i < expectedChecks.Count; i++)
        {
            Assert.Equal(expectedChecks[i], parameters.Checks[i]);
        }
    }
}
