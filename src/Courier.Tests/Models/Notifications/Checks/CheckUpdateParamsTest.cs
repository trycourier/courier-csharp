using System;
using System.Collections.Generic;
using Courier.Models.Notifications.Checks;
using Notifications = Courier.Models.Notifications;

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
                    Status = Notifications::Status.Resolved,
                    Type = Notifications::Type.Custom,
                },
            ],
        };

        string expectedID = "id";
        string expectedSubmissionID = "submissionId";
        List<Notifications::BaseCheck> expectedChecks =
        [
            new()
            {
                ID = "id",
                Status = Notifications::Status.Resolved,
                Type = Notifications::Type.Custom,
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

    [Fact]
    public void Url_Works()
    {
        CheckUpdateParams parameters = new()
        {
            ID = "id",
            SubmissionID = "submissionId",
            Checks =
            [
                new()
                {
                    ID = "id",
                    Status = Notifications::Status.Resolved,
                    Type = Notifications::Type.Custom,
                },
            ],
        };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/notifications/id/submissionId/checks"), url);
    }
}
