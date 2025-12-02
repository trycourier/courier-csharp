using System.Collections.Generic;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class ElementalTextNodeWithTypeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalTextNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
        };

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        ApiEnum<string, ElementalTextNodeWithTypeIntersectionMember1Type> expectedType =
            ElementalTextNodeWithTypeIntersectionMember1Type.Text;

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

public class ElementalTextNodeWithTypeIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalTextNodeWithTypeIntersectionMember1
        {
            Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
        };

        ApiEnum<string, ElementalTextNodeWithTypeIntersectionMember1Type> expectedType =
            ElementalTextNodeWithTypeIntersectionMember1Type.Text;

        Assert.Equal(expectedType, model.Type);
    }
}
