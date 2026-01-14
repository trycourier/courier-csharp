using System.Text.Json;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class MessageRoutingChannelTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        MessageRoutingChannel value = "string";
        value.Validate();
    }

    [Fact]
    public void MessageRoutingValidationWorks()
    {
        MessageRoutingChannel value = new MessageRouting()
        {
            Channels = ["string"],
            Method = Method.All,
        };
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        MessageRoutingChannel value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageRoutingChannel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MessageRoutingSerializationRoundtripWorks()
    {
        MessageRoutingChannel value = new MessageRouting()
        {
            Channels = ["string"],
            Method = Method.All,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<MessageRoutingChannel>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
