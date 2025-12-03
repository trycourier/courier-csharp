using System.Text.Json;
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

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BulkCreateJobResponse { JobID = "jobId" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BulkCreateJobResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BulkCreateJobResponse { JobID = "jobId" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BulkCreateJobResponse>(json);
        Assert.NotNull(deserialized);

        string expectedJobID = "jobId";

        Assert.Equal(expectedJobID, deserialized.JobID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BulkCreateJobResponse { JobID = "jobId" };

        model.Validate();
    }
}
