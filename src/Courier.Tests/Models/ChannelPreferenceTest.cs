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
}
