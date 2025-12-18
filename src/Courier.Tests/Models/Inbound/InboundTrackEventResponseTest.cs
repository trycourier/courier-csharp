using System.Text.Json;
using Courier.Models.Inbound;

namespace Courier.Tests.Models.Inbound;

public class InboundTrackEventResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundTrackEventResponse
        {
            MessageID = "1-65f240a0-47a6a120c8374de9bcf9f22c",
        };

        string expectedMessageID = "1-65f240a0-47a6a120c8374de9bcf9f22c";

        Assert.Equal(expectedMessageID, model.MessageID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundTrackEventResponse
        {
            MessageID = "1-65f240a0-47a6a120c8374de9bcf9f22c",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<InboundTrackEventResponse>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundTrackEventResponse
        {
            MessageID = "1-65f240a0-47a6a120c8374de9bcf9f22c",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<InboundTrackEventResponse>(element);
        Assert.NotNull(deserialized);

        string expectedMessageID = "1-65f240a0-47a6a120c8374de9bcf9f22c";

        Assert.Equal(expectedMessageID, deserialized.MessageID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundTrackEventResponse
        {
            MessageID = "1-65f240a0-47a6a120c8374de9bcf9f22c",
        };

        model.Validate();
    }
}
