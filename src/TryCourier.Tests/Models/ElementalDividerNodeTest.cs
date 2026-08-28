using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;

namespace TryCourier.Tests.Models;

public class ElementalDividerNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalDividerNode
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Color = "color",
        };

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        string expectedColor = "color";

        Assert.NotNull(model.Channels);
        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], model.Channels[i]);
        }
        Assert.Equal(expectedIf, model.If);
        Assert.Equal(expectedLoop, model.Loop);
        Assert.Equal(expectedRef, model.Ref);
        Assert.Equal(expectedColor, model.Color);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ElementalDividerNode
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Color = "color",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalDividerNode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ElementalDividerNode
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Color = "color",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalDividerNode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        string expectedColor = "color";

        Assert.NotNull(deserialized.Channels);
        Assert.Equal(expectedChannels.Count, deserialized.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], deserialized.Channels[i]);
        }
        Assert.Equal(expectedIf, deserialized.If);
        Assert.Equal(expectedLoop, deserialized.Loop);
        Assert.Equal(expectedRef, deserialized.Ref);
        Assert.Equal(expectedColor, deserialized.Color);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ElementalDividerNode
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Color = "color",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalDividerNode { };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.If);
        Assert.False(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.False(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.False(model.RawData.ContainsKey("ref"));
        Assert.Null(model.Color);
        Assert.False(model.RawData.ContainsKey("color"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ElementalDividerNode { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ElementalDividerNode
        {
            Channels = null,
            If = null,
            Loop = null,
            Ref = null,
            Color = null,
        };

        Assert.Null(model.Channels);
        Assert.True(model.RawData.ContainsKey("channels"));
        Assert.Null(model.If);
        Assert.True(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.True(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.True(model.RawData.ContainsKey("ref"));
        Assert.Null(model.Color);
        Assert.True(model.RawData.ContainsKey("color"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ElementalDividerNode
        {
            Channels = null,
            If = null,
            Loop = null,
            Ref = null,
            Color = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ElementalDividerNode
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Color = "color",
        };

        ElementalDividerNode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ElementalDividerNodeIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalDividerNodeIntersectionMember1 { Color = "color" };

        string expectedColor = "color";

        Assert.Equal(expectedColor, model.Color);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ElementalDividerNodeIntersectionMember1 { Color = "color" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalDividerNodeIntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ElementalDividerNodeIntersectionMember1 { Color = "color" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalDividerNodeIntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedColor = "color";

        Assert.Equal(expectedColor, deserialized.Color);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ElementalDividerNodeIntersectionMember1 { Color = "color" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalDividerNodeIntersectionMember1 { };

        Assert.Null(model.Color);
        Assert.False(model.RawData.ContainsKey("color"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ElementalDividerNodeIntersectionMember1 { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ElementalDividerNodeIntersectionMember1 { Color = null };

        Assert.Null(model.Color);
        Assert.True(model.RawData.ContainsKey("color"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ElementalDividerNodeIntersectionMember1 { Color = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ElementalDividerNodeIntersectionMember1 { Color = "color" };

        ElementalDividerNodeIntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}
