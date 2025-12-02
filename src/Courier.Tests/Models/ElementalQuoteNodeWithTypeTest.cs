using System.Collections.Generic;
using Courier.Core;
using Courier.Models;

namespace Courier.Tests.Models;

public class ElementalQuoteNodeWithTypeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalQuoteNodeWithType
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalQuoteNodeWithTypeIntersectionMember1Type.Quote,
        };

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        ApiEnum<string, ElementalQuoteNodeWithTypeIntersectionMember1Type> expectedType =
            ElementalQuoteNodeWithTypeIntersectionMember1Type.Quote;

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

public class ElementalQuoteNodeWithTypeIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalQuoteNodeWithTypeIntersectionMember1
        {
            Type = ElementalQuoteNodeWithTypeIntersectionMember1Type.Quote,
        };

        ApiEnum<string, ElementalQuoteNodeWithTypeIntersectionMember1Type> expectedType =
            ElementalQuoteNodeWithTypeIntersectionMember1Type.Quote;

        Assert.Equal(expectedType, model.Type);
    }
}
