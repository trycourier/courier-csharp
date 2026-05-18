using System.Text.Json;
using Courier.Core;
using Courier.Models.Send;

namespace Courier.Tests.Models.Send;

public class SendMessageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SendMessageResponse { RequestID = "1-67f340b1-58b7b231d9485ef0cda0a38b" };

        string expectedRequestID = "1-67f340b1-58b7b231d9485ef0cda0a38b";

        Assert.Equal(expectedRequestID, model.RequestID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SendMessageResponse { RequestID = "1-67f340b1-58b7b231d9485ef0cda0a38b" };

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
        var model = new SendMessageResponse { RequestID = "1-67f340b1-58b7b231d9485ef0cda0a38b" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SendMessageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRequestID = "1-67f340b1-58b7b231d9485ef0cda0a38b";

        Assert.Equal(expectedRequestID, deserialized.RequestID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SendMessageResponse { RequestID = "1-67f340b1-58b7b231d9485ef0cda0a38b" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SendMessageResponse { RequestID = "1-67f340b1-58b7b231d9485ef0cda0a38b" };

        SendMessageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
