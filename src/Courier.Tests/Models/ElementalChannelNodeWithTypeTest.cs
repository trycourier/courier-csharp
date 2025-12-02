using System.Collections.Generic;
using System.Text.Json;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class ElementalChannelNodeWithTypeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalChannelNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Channel = "email",
            Raw = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Type = ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
        };

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        string expectedChannel = "email";
        Dictionary<string, JsonElement> expectedRaw = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, ElementalChannelNodeWithTypeIntersectionMember1Type> expectedType =
            ElementalChannelNodeWithTypeIntersectionMember1Type.Channel;

        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], model.Channels[i]);
        }
        Assert.Equal(expectedIf, model.If);
        Assert.Equal(expectedLoop, model.Loop);
        Assert.Equal(expectedRef, model.Ref);
        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedRaw.Count, model.Raw.Count);
        foreach (var item in expectedRaw)
        {
            Assert.True(model.Raw.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Raw[item.Key]));
        }
        Assert.Equal(expectedType, model.Type);
    }
}

public class ElementalChannelNodeWithTypeIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalChannelNodeWithTypeIntersectionMember1
        {
            Type = ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
        };

        ApiEnum<string, ElementalChannelNodeWithTypeIntersectionMember1Type> expectedType =
            ElementalChannelNodeWithTypeIntersectionMember1Type.Channel;

        Assert.Equal(expectedType, model.Type);
    }
}
