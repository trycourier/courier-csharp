using Courier.Models.Bulk;

namespace Courier.Tests.Models.Bulk;

public class BulkRunJobParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BulkRunJobParams { JobID = "job_id" };

        string expectedJobID = "job_id";

        Assert.Equal(expectedJobID, parameters.JobID);
    }
}
