using System.Collections.Generic;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class ElementalDividerNodeWithTypeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalDividerNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalDividerNodeWithTypeIntersectionMember1Type.Divider,
        };

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        ApiEnum<string, ElementalDividerNodeWithTypeIntersectionMember1Type> expectedType =
            ElementalDividerNodeWithTypeIntersectionMember1Type.Divider;

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

public class ElementalDividerNodeWithTypeIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalDividerNodeWithTypeIntersectionMember1
        {
            Type = ElementalDividerNodeWithTypeIntersectionMember1Type.Divider,
        };

        ApiEnum<string, ElementalDividerNodeWithTypeIntersectionMember1Type> expectedType =
            ElementalDividerNodeWithTypeIntersectionMember1Type.Divider;

        Assert.Equal(expectedType, model.Type);
    }
}
