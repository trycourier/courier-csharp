using System.Text.Json;
using Courier.Core;
using Courier.Models.Send;

namespace Courier.Tests.Models.Send;

public class SendMessageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SendMessageResponse { RequestID = "1-69f561d3-7ad9d453fb6a7012efc2c5ad" };

        string expectedRequestID = "1-69f561d3-7ad9d453fb6a7012efc2c5ad";

        Assert.Equal(expectedRequestID, model.RequestID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SendMessageResponse { RequestID = "1-69f561d3-7ad9d453fb6a7012efc2c5ad" };

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
        var model = new SendMessageResponse { RequestID = "1-69f561d3-7ad9d453fb6a7012efc2c5ad" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SendMessageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedRequestID = "1-69f561d3-7ad9d453fb6a7012efc2c5ad";

        Assert.Equal(expectedRequestID, deserialized.RequestID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SendMessageResponse { RequestID = "1-69f561d3-7ad9d453fb6a7012efc2c5ad" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SendMessageResponse { RequestID = "1-69f561d3-7ad9d453fb6a7012efc2c5ad" };

        SendMessageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
