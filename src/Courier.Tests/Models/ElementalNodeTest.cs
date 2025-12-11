using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class ElementalNodeTest : TestBase
{
    [Fact]
    public void text_node_with_typeValidation_Works()
    {
        ElementalNode value = new(
            new()
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
    public void meta_node_with_typeValidation_Works()
    {
        ElementalNode value = new(
            new()
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
    public void channel_node_with_typeValidation_Works()
    {
        ElementalNode value = new(
            new() { Type = ElementalChannelNodeWithTypeIntersectionMember1Type.Channel }
        );
        value.Validate();
    }

    [Fact]
    public void image_node_with_typeValidation_Works()
    {
        ElementalNode value = new(
            new()
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
    public void action_node_with_typeValidation_Works()
    {
        ElementalNode value = new(
            new()
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
    public void divider_node_with_typeValidation_Works()
    {
        ElementalNode value = new(
            new()
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
    public void quote_node_with_typeValidation_Works()
    {
        ElementalNode value = new(
            new()
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
    public void text_node_with_typeSerializationRoundtrip_Works()
    {
        ElementalNode value = new(
            new()
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
    public void meta_node_with_typeSerializationRoundtrip_Works()
    {
        ElementalNode value = new(
            new()
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
    public void channel_node_with_typeSerializationRoundtrip_Works()
    {
        ElementalNode value = new(
            new() { Type = ElementalChannelNodeWithTypeIntersectionMember1Type.Channel }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ElementalNode>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void image_node_with_typeSerializationRoundtrip_Works()
    {
        ElementalNode value = new(
            new()
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
    public void action_node_with_typeSerializationRoundtrip_Works()
    {
        ElementalNode value = new(
            new()
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
    public void divider_node_with_typeSerializationRoundtrip_Works()
    {
        ElementalNode value = new(
            new()
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
    public void quote_node_with_typeSerializationRoundtrip_Works()
    {
        ElementalNode value = new(
            new()
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
