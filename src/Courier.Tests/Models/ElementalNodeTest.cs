using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class ElementalNodeTest : TestBase
{
    [Fact]
    public void TextNodeWithTypeValidationWorks()
    {
        ElementalNode value = new ElementalTextNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
        };
        value.Validate();
    }

    [Fact]
    public void MetaNodeWithTypeValidationWorks()
    {
        ElementalNode value = new ElementalMetaNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalMetaNodeWithTypeIntersectionMember1Type.Meta,
        };
        value.Validate();
    }

    [Fact]
    public void ChannelNodeWithTypeValidationWorks()
    {
        ElementalNode value = new ElementalChannelNodeWithType()
        {
            Type = ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
        };
        value.Validate();
    }

    [Fact]
    public void ImageNodeWithTypeValidationWorks()
    {
        ElementalNode value = new ElementalImageNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalImageNodeWithTypeIntersectionMember1Type.Image,
        };
        value.Validate();
    }

    [Fact]
    public void ActionNodeWithTypeValidationWorks()
    {
        ElementalNode value = new ElementalActionNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = Type.Action,
        };
        value.Validate();
    }

    [Fact]
    public void DividerNodeWithTypeValidationWorks()
    {
        ElementalNode value = new ElementalDividerNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalDividerNodeWithTypeIntersectionMember1Type.Divider,
        };
        value.Validate();
    }

    [Fact]
    public void QuoteNodeWithTypeValidationWorks()
    {
        ElementalNode value = new ElementalQuoteNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalQuoteNodeWithTypeIntersectionMember1Type.Quote,
        };
        value.Validate();
    }

    [Fact]
    public void TextNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new ElementalTextNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MetaNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new ElementalMetaNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalMetaNodeWithTypeIntersectionMember1Type.Meta,
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ChannelNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new ElementalChannelNodeWithType()
        {
            Type = ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImageNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new ElementalImageNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalImageNodeWithTypeIntersectionMember1Type.Image,
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ActionNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new ElementalActionNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = Type.Action,
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DividerNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new ElementalDividerNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalDividerNodeWithTypeIntersectionMember1Type.Divider,
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void QuoteNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new ElementalQuoteNodeWithType()
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Type = ElementalQuoteNodeWithTypeIntersectionMember1Type.Quote,
        };
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(element);

        Assert.Equal(value, deserialized);
    }
}
