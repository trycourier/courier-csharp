using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class SendToSlackChannelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SendToSlackChannel { AccessToken = "access_token", Channel = "channel" };

        string expectedAccessToken = "access_token";
        string expectedChannel = "channel";

        Assert.Equal(expectedAccessToken, model.AccessToken);
        Assert.Equal(expectedChannel, model.Channel);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SendToSlackChannel { AccessToken = "access_token", Channel = "channel" };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SendToSlackChannel>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SendToSlackChannel { AccessToken = "access_token", Channel = "channel" };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<SendToSlackChannel>(element);
        Assert.NotNull(deserialized);

        string expectedAccessToken = "access_token";
        string expectedChannel = "channel";

        Assert.Equal(expectedAccessToken, deserialized.AccessToken);
        Assert.Equal(expectedChannel, deserialized.Channel);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SendToSlackChannel { AccessToken = "access_token", Channel = "channel" };

        model.Validate();
    }
}
