using Courier.Models.Bulk;

namespace Courier.Tests.Models.Bulk;

public class BulkListUsersParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BulkListUsersParams { JobID = "job_id", Cursor = "cursor" };

        string expectedJobID = "job_id";
        string expectedCursor = "cursor";

        Assert.Equal(expectedJobID, parameters.JobID);
        Assert.Equal(expectedCursor, parameters.Cursor);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new BulkListUsersParams { JobID = "job_id" };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new BulkListUsersParams
        {
            JobID = "job_id",

            Cursor = null,
        };

        Assert.Null(parameters.Cursor);
        Assert.False(parameters.RawQueryData.ContainsKey("cursor"));
    }
}
