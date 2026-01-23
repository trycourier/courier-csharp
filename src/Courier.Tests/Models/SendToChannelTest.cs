using System.Text.Json;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class SendToChannelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SendToChannel { ChannelID = "channel_id" };

        string expectedChannelID = "channel_id";

        Assert.Equal(expectedChannelID, model.ChannelID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SendToChannel { ChannelID = "channel_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SendToChannel>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SendToChannel { ChannelID = "channel_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SendToChannel>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedChannelID = "channel_id";

        Assert.Equal(expectedChannelID, deserialized.ChannelID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SendToChannel { ChannelID = "channel_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SendToChannel { ChannelID = "channel_id" };

        SendToChannel copied = new(model);

        Assert.Equal(model, copied);
    }
}
