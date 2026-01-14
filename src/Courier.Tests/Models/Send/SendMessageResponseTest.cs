using System.Text.Json;
using Courier.Core;
using Courier.Models.Send;

namespace Courier.Tests.Models.Send;

public class SendMessageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SendMessageResponse { RequestID = "1-65f240a0-47a6a120c8374de9bcf9f22c" };

        string expectedRequestID = "1-65f240a0-47a6a120c8374de9bcf9f22c";

        Assert.Equal(expectedRequestID, model.RequestID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SendMessageResponse { RequestID = "1-65f240a0-47a6a120c8374de9bcf9f22c" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SendMessageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SendMessageResponse { RequestID = "1-65f240a0-47a6a120c8374de9bcf9f22c" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SendMessageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRequestID = "1-65f240a0-47a6a120c8374de9bcf9f22c";

        Assert.Equal(expectedRequestID, deserialized.RequestID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SendMessageResponse { RequestID = "1-65f240a0-47a6a120c8374de9bcf9f22c" };

        model.Validate();
    }
}
