using System;
using Courier.Models.Notifications.Checks;

namespace Courier.Tests.Models.Notifications.Checks;

public class CheckListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CheckListParams { ID = "id", SubmissionID = "submissionId" };

        string expectedID = "id";
        string expectedSubmissionID = "submissionId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedSubmissionID, parameters.SubmissionID);
    }

    [Fact]
    public void Url_Works()
    {
        CheckListParams parameters = new() { ID = "id", SubmissionID = "submissionId" };

        var url = parameters.Url(new() { APIKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/notifications/id/submissionId/checks"), url);
    }
}
