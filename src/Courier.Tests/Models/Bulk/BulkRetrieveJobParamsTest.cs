using Courier.Models.Bulk;

namespace Courier.Tests.Models.Bulk;

public class BulkRetrieveJobParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BulkRetrieveJobParams { JobID = "job_id" };

        string expectedJobID = "job_id";

        Assert.Equal(expectedJobID, parameters.JobID);
    }
}
