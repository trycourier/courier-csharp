using System.Text.Json;
using Courier.Models.Automations;

namespace Courier.Tests.Models.Automations;

public class AutomationInvokeResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutomationInvokeResponse { RunID = "runId" };

        string expectedRunID = "runId";

        Assert.Equal(expectedRunID, model.RunID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AutomationInvokeResponse { RunID = "runId" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AutomationInvokeResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AutomationInvokeResponse { RunID = "runId" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<AutomationInvokeResponse>(json);
        Assert.NotNull(deserialized);

        string expectedRunID = "runId";

        Assert.Equal(expectedRunID, deserialized.RunID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AutomationInvokeResponse { RunID = "runId" };

        model.Validate();
    }
}
