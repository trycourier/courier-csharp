using System.Collections.Generic;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class ElementalImageNodeWithTypeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalImageNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalImageNodeWithTypeIntersectionMember1Type.Image,
        };

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        ApiEnum<string, ElementalImageNodeWithTypeIntersectionMember1Type> expectedType =
            ElementalImageNodeWithTypeIntersectionMember1Type.Image;

        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], model.Channels[i]);
        }
        Assert.Equal(expectedIf, model.If);
        Assert.Equal(expectedLoop, model.Loop);
        Assert.Equal(expectedRef, model.Ref);
        Assert.Equal(expectedType, model.Type);
    }
}

public class ElementalImageNodeWithTypeIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalImageNodeWithTypeIntersectionMember1
        {
            Type = ElementalImageNodeWithTypeIntersectionMember1Type.Image,
        };

        ApiEnum<string, ElementalImageNodeWithTypeIntersectionMember1Type> expectedType =
            ElementalImageNodeWithTypeIntersectionMember1Type.Image;

        Assert.Equal(expectedType, model.Type);
    }
}
