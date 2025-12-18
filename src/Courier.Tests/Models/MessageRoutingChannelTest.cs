using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class MessageRoutingChannelTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        MessageRoutingChannel value = new("string");
        value.Validate();
    }

    [Fact]
    public void MessageRoutingValidationWorks()
    {
        MessageRoutingChannel value = new(
            new MessageRouting() { Channels = ["string"], Method = Method.All }
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        MessageRoutingChannel value = new("string");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MessageRoutingChannel>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MessageRoutingSerializationRoundtripWorks()
    {
        MessageRoutingChannel value = new(
            new MessageRouting() { Channels = ["string"], Method = Method.All }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MessageRoutingChannel>(element);

        Assert.Equal(value, deserialized);
    }
}
