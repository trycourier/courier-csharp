using Courier.Models.Bulk;

namespace Courier.Tests.Models.Bulk;

public class BulkCreateJobResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BulkCreateJobResponse { JobID = "jobId" };

        string expectedJobID = "jobId";

        Assert.Equal(expectedJobID, model.JobID);
    }
}
