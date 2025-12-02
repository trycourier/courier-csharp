using System.Collections.Generic;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class MessageRoutingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new MessageRouting { Channels = ["string"], Method = Method.All };

        List<MessageRoutingChannel> expectedChannels = ["string"];
        ApiEnum<string, Method> expectedMethod = Method.All;

        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], model.Channels[i]);
        }
        Assert.Equal(expectedMethod, model.Method);
    }
}
