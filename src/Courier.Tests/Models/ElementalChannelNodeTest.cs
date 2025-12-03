using System.Collections.Generic;
using System.Text.Json;
using Courier.Models;

namespace Courier.Tests.Models;

public class ElementalChannelNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalChannelNode
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ElementalChannelNode
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ElementalChannelNode>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ElementalChannelNode
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ElementalChannelNode>(json);
        Assert.NotNull(deserialized);

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        string expectedChannel = "email";
        Dictionary<string, JsonElement> expectedRaw = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedChannels.Count, deserialized.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], deserialized.Channels[i]);
        }
        Assert.Equal(expectedIf, deserialized.If);
        Assert.Equal(expectedLoop, deserialized.Loop);
        Assert.Equal(expectedRef, deserialized.Ref);
        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedRaw.Count, deserialized.Raw.Count);
        foreach (var item in expectedRaw)
        {
            Assert.True(deserialized.Raw.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Raw[item.Key]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ElementalChannelNode
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalChannelNode { Channel = "email" };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.If);
        Assert.False(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.False(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.False(model.RawData.ContainsKey("ref"));
        Assert.Null(model.Raw);
        Assert.False(model.RawData.ContainsKey("raw"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ElementalChannelNode { Channel = "email" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ElementalChannelNode
        {
            Channel = "email",

            Channels = null,
            If = null,
            Loop = null,
            Ref = null,
            Raw = null,
        };

        Assert.Null(model.Channels);
        Assert.True(model.RawData.ContainsKey("channels"));
        Assert.Null(model.If);
        Assert.True(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.True(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.True(model.RawData.ContainsKey("ref"));
        Assert.Null(model.Raw);
        Assert.True(model.RawData.ContainsKey("raw"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ElementalChannelNode
        {
            Channel = "email",

            Channels = null,
            If = null,
            Loop = null,
            Ref = null,
            Raw = null,
        };

        model.Validate();
    }
}

public class ElementalChannelNodeIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalChannelNodeIntersectionMember1
        {
            Channel = "email",
            Raw = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string expectedChannel = "email";
        Dictionary<string, JsonElement> expectedRaw = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedChannel, model.Channel);
        Assert.Equal(expectedRaw.Count, model.Raw.Count);
        foreach (var item in expectedRaw)
        {
            Assert.True(model.Raw.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Raw[item.Key]));
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ElementalChannelNodeIntersectionMember1
        {
            Channel = "email",
            Raw = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ElementalChannelNodeIntersectionMember1>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ElementalChannelNodeIntersectionMember1
        {
            Channel = "email",
            Raw = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ElementalChannelNodeIntersectionMember1>(
            json
        );
        Assert.NotNull(deserialized);

        string expectedChannel = "email";
        Dictionary<string, JsonElement> expectedRaw = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };

        Assert.Equal(expectedChannel, deserialized.Channel);
        Assert.Equal(expectedRaw.Count, deserialized.Raw.Count);
        foreach (var item in expectedRaw)
        {
            Assert.True(deserialized.Raw.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Raw[item.Key]));
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ElementalChannelNodeIntersectionMember1
        {
            Channel = "email",
            Raw = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalChannelNodeIntersectionMember1 { Channel = "email" };

        Assert.Null(model.Raw);
        Assert.False(model.RawData.ContainsKey("raw"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ElementalChannelNodeIntersectionMember1 { Channel = "email" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ElementalChannelNodeIntersectionMember1
        {
            Channel = "email",

            Raw = null,
        };

        Assert.Null(model.Raw);
        Assert.True(model.RawData.ContainsKey("raw"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ElementalChannelNodeIntersectionMember1
        {
            Channel = "email",

            Raw = null,
        };

        model.Validate();
    }
}
