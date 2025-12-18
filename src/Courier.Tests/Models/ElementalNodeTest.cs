using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class ElementalNodeTest : TestBase
{
    [Fact]
    public void TextNodeWithTypeValidationWorks()
    {
        ElementalNode value = new(
            new ElementalTextNodeWithType()
            {
                Channels = ["string"],
                If = "if",
                Loop = "loop",
                Ref = "ref",
                Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
            }
        );
        value.Validate();
    }

    [Fact]
    public void MetaNodeWithTypeValidationWorks()
    {
        ElementalNode value = new(
            new ElementalMetaNodeWithType()
            {
                Channels = ["string"],
                If = "if",
                Loop = "loop",
                Ref = "ref",
                Type = ElementalMetaNodeWithTypeIntersectionMember1Type.Meta,
            }
        );
        value.Validate();
    }

    [Fact]
    public void ChannelNodeWithTypeValidationWorks()
    {
        ElementalNode value = new(
            new ElementalChannelNodeWithType()
            {
                Type = ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
            }
        );
        value.Validate();
    }

    [Fact]
    public void ImageNodeWithTypeValidationWorks()
    {
        ElementalNode value = new(
            new ElementalImageNodeWithType()
            {
                Channels = ["string"],
                If = "if",
                Loop = "loop",
                Ref = "ref",
                Type = ElementalImageNodeWithTypeIntersectionMember1Type.Image,
            }
        );
        value.Validate();
    }

    [Fact]
    public void ActionNodeWithTypeValidationWorks()
    {
        ElementalNode value = new(
            new ElementalActionNodeWithType()
            {
                Channels = ["string"],
                If = "if",
                Loop = "loop",
                Ref = "ref",
                Type = Type.Action,
            }
        );
        value.Validate();
    }

    [Fact]
    public void DividerNodeWithTypeValidationWorks()
    {
        ElementalNode value = new(
            new ElementalDividerNodeWithType()
            {
                Channels = ["string"],
                If = "if",
                Loop = "loop",
                Ref = "ref",
                Type = ElementalDividerNodeWithTypeIntersectionMember1Type.Divider,
            }
        );
        value.Validate();
    }

    [Fact]
    public void QuoteNodeWithTypeValidationWorks()
    {
        ElementalNode value = new(
            new ElementalQuoteNodeWithType()
            {
                Channels = ["string"],
                If = "if",
                Loop = "loop",
                Ref = "ref",
                Type = ElementalQuoteNodeWithTypeIntersectionMember1Type.Quote,
            }
        );
        value.Validate();
    }

    [Fact]
    public void TextNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new(
            new ElementalTextNodeWithType()
            {
                Channels = ["string"],
                If = "if",
                Loop = "loop",
                Ref = "ref",
                Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void MetaNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new(
            new ElementalMetaNodeWithType()
            {
                Channels = ["string"],
                If = "if",
                Loop = "loop",
                Ref = "ref",
                Type = ElementalMetaNodeWithTypeIntersectionMember1Type.Meta,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ChannelNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new(
            new ElementalChannelNodeWithType()
            {
                Type = ElementalChannelNodeWithTypeIntersectionMember1Type.Channel,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ImageNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new(
            new ElementalImageNodeWithType()
            {
                Channels = ["string"],
                If = "if",
                Loop = "loop",
                Ref = "ref",
                Type = ElementalImageNodeWithTypeIntersectionMember1Type.Image,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ActionNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new(
            new ElementalActionNodeWithType()
            {
                Channels = ["string"],
                If = "if",
                Loop = "loop",
                Ref = "ref",
                Type = Type.Action,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DividerNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new(
            new ElementalDividerNodeWithType()
            {
                Channels = ["string"],
                If = "if",
                Loop = "loop",
                Ref = "ref",
                Type = ElementalDividerNodeWithTypeIntersectionMember1Type.Divider,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void QuoteNodeWithTypeSerializationRoundtripWorks()
    {
        ElementalNode value = new(
            new ElementalQuoteNodeWithType()
            {
                Channels = ["string"],
                If = "if",
                Loop = "loop",
                Ref = "ref",
                Type = ElementalQuoteNodeWithTypeIntersectionMember1Type.Quote,
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(json);

        Assert.Equal(value, deserialized);
    }
}
