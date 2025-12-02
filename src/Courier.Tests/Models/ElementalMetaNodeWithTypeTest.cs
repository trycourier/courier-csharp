using System.Collections.Generic;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class ElementalMetaNodeWithTypeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalMetaNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalMetaNodeWithTypeIntersectionMember1Type.Meta,
        };

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        ApiEnum<string, ElementalMetaNodeWithTypeIntersectionMember1Type> expectedType =
            ElementalMetaNodeWithTypeIntersectionMember1Type.Meta;

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

public class ElementalMetaNodeWithTypeIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalMetaNodeWithTypeIntersectionMember1
        {
            Type = ElementalMetaNodeWithTypeIntersectionMember1Type.Meta,
        };

        ApiEnum<string, ElementalMetaNodeWithTypeIntersectionMember1Type> expectedType =
            ElementalMetaNodeWithTypeIntersectionMember1Type.Meta;

        Assert.Equal(expectedType, model.Type);
    }
}
