using System.Text.Json;
using Courier.Core;
using Courier.Models.Journeys;

namespace Courier.Tests.Models.Journeys;

public class JourneysInvokeResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JourneysInvokeResponse { RunID = "runId" };

        string expectedRunID = "runId";

        Assert.Equal(expectedRunID, model.RunID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JourneysInvokeResponse { RunID = "runId" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneysInvokeResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JourneysInvokeResponse { RunID = "runId" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JourneysInvokeResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRunID = "runId";

        Assert.Equal(expectedRunID, deserialized.RunID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JourneysInvokeResponse { RunID = "runId" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JourneysInvokeResponse { RunID = "runId" };

        JourneysInvokeResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
