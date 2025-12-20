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
}
