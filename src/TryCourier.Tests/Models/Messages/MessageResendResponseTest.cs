using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models.Messages;

namespace TryCourier.Tests.Models.Messages;

public class MessageResendResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageResendResponse { MessageID = "1-5e2b2615-05efbb3acab9172f88dd3f6f" };

        string expectedMessageID = "1-5e2b2615-05efbb3acab9172f88dd3f6f";

        Assert.Equal(expectedMessageID, model.MessageID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new MessageResendResponse { MessageID = "1-5e2b2615-05efbb3acab9172f88dd3f6f" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageResendResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new MessageResendResponse { MessageID = "1-5e2b2615-05efbb3acab9172f88dd3f6f" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageResendResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedMessageID = "1-5e2b2615-05efbb3acab9172f88dd3f6f";

        Assert.Equal(expectedMessageID, deserialized.MessageID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new MessageResendResponse { MessageID = "1-5e2b2615-05efbb3acab9172f88dd3f6f" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new MessageResendResponse { MessageID = "1-5e2b2615-05efbb3acab9172f88dd3f6f" };

        MessageResendResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}
