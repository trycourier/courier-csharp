using System.Text.Json;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class ChannelPreferenceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChannelPreference { Channel = ChannelClassification.DirectMessage };

        ApiEnum<string, ChannelClassification> expectedChannel =
            ChannelClassification.DirectMessage;

        Assert.Equal(expectedChannel, model.Channel);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChannelPreference { Channel = ChannelClassification.DirectMessage };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ChannelPreference>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChannelPreference { Channel = ChannelClassification.DirectMessage };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ChannelPreference>(element);
        Assert.NotNull(deserialized);

        ApiEnum<string, ChannelClassification> expectedChannel =
            ChannelClassification.DirectMessage;

        Assert.Equal(expectedChannel, deserialized.Channel);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChannelPreference { Channel = ChannelClassification.DirectMessage };

        model.Validate();
    }
}
