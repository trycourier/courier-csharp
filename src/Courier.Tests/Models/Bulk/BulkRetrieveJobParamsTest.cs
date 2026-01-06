using System;
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

    [Fact]
    public void Url_Works()
    {
        BulkRetrieveJobParams parameters = new() { JobID = "job_id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/bulk/job_id"), url);
    }
}
