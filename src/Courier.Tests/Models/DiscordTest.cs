using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class DiscordTest : TestBase
{
    [Fact]
    public void SendToChannelValidationWorks()
    {
        Discord value = new(new SendToChannel("channel_id"));
        value.Validate();
    }

    [Fact]
    public void SendDirectMessageValidationWorks()
    {
        Discord value = new(new SendDirectMessage("user_id"));
        value.Validate();
    }

    [Fact]
    public void SendToChannelSerializationRoundtripWorks()
    {
        Discord value = new(new SendToChannel("channel_id"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Discord>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SendDirectMessageSerializationRoundtripWorks()
    {
        Discord value = new(new SendDirectMessage("user_id"));
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Discord>(element);

        Assert.Equal(value, deserialized);
    }
}
