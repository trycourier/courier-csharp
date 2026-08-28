using System.Collections.Generic;
using System.Text.Json;
using TryCourier.Core;
using TryCourier.Models;

namespace TryCourier.Tests.Models;

public class ElementalHtmlNodeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalHtmlNode
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
        };

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        string expectedContent = "content";
        Dictionary<string, LocalesItem> expectedLocales = new() { { "foo", new("content") } };

        Assert.NotNull(model.Channels);
        Assert.Equal(expectedChannels.Count, model.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], model.Channels[i]);
        }
        Assert.Equal(expectedIf, model.If);
        Assert.Equal(expectedLoop, model.Loop);
        Assert.Equal(expectedRef, model.Ref);
        Assert.Equal(expectedContent, model.Content);
        Assert.NotNull(model.Locales);
        Assert.Equal(expectedLocales.Count, model.Locales.Count);
        foreach (var item in expectedLocales)
        {
            Assert.True(model.Locales.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Locales[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ElementalHtmlNode
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalHtmlNode>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ElementalHtmlNode
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalHtmlNode>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedChannels = ["string"];
        string expectedIf = "if";
        string expectedLoop = "loop";
        string expectedRef = "ref";
        string expectedContent = "content";
        Dictionary<string, LocalesItem> expectedLocales = new() { { "foo", new("content") } };

        Assert.NotNull(deserialized.Channels);
        Assert.Equal(expectedChannels.Count, deserialized.Channels.Count);
        for (int i = 0; i < expectedChannels.Count; i++)
        {
            Assert.Equal(expectedChannels[i], deserialized.Channels[i]);
        }
        Assert.Equal(expectedIf, deserialized.If);
        Assert.Equal(expectedLoop, deserialized.Loop);
        Assert.Equal(expectedRef, deserialized.Ref);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.NotNull(deserialized.Locales);
        Assert.Equal(expectedLocales.Count, deserialized.Locales.Count);
        foreach (var item in expectedLocales)
        {
            Assert.True(deserialized.Locales.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Locales[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ElementalHtmlNode
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalHtmlNode { Content = "content" };

        Assert.Null(model.Channels);
        Assert.False(model.RawData.ContainsKey("channels"));
        Assert.Null(model.If);
        Assert.False(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.False(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.False(model.RawData.ContainsKey("ref"));
        Assert.Null(model.Locales);
        Assert.False(model.RawData.ContainsKey("locales"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ElementalHtmlNode { Content = "content" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ElementalHtmlNode
        {
            Content = "content",

            Channels = null,
            If = null,
            Loop = null,
            Ref = null,
            Locales = null,
        };

        Assert.Null(model.Channels);
        Assert.True(model.RawData.ContainsKey("channels"));
        Assert.Null(model.If);
        Assert.True(model.RawData.ContainsKey("if"));
        Assert.Null(model.Loop);
        Assert.True(model.RawData.ContainsKey("loop"));
        Assert.Null(model.Ref);
        Assert.True(model.RawData.ContainsKey("ref"));
        Assert.Null(model.Locales);
        Assert.True(model.RawData.ContainsKey("locales"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ElementalHtmlNode
        {
            Content = "content",

            Channels = null,
            If = null,
            Loop = null,
            Ref = null,
            Locales = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ElementalHtmlNode
        {
            Channels = ["string"],
            If = "if",
            Loop = "loop",
            Ref = "ref",
            Content = "content",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
        };

        ElementalHtmlNode copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ElementalHtmlNodeIntersectionMember1Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ElementalHtmlNodeIntersectionMember1
        {
            Content = "content",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
        };

        string expectedContent = "content";
        Dictionary<string, LocalesItem> expectedLocales = new() { { "foo", new("content") } };

        Assert.Equal(expectedContent, model.Content);
        Assert.NotNull(model.Locales);
        Assert.Equal(expectedLocales.Count, model.Locales.Count);
        foreach (var item in expectedLocales)
        {
            Assert.True(model.Locales.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Locales[item.Key]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ElementalHtmlNodeIntersectionMember1
        {
            Content = "content",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalHtmlNodeIntersectionMember1>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ElementalHtmlNodeIntersectionMember1
        {
            Content = "content",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ElementalHtmlNodeIntersectionMember1>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        Dictionary<string, LocalesItem> expectedLocales = new() { { "foo", new("content") } };

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.NotNull(deserialized.Locales);
        Assert.Equal(expectedLocales.Count, deserialized.Locales.Count);
        foreach (var item in expectedLocales)
        {
            Assert.True(deserialized.Locales.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Locales[item.Key]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ElementalHtmlNodeIntersectionMember1
        {
            Content = "content",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ElementalHtmlNodeIntersectionMember1 { Content = "content" };

        Assert.Null(model.Locales);
        Assert.False(model.RawData.ContainsKey("locales"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ElementalHtmlNodeIntersectionMember1 { Content = "content" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ElementalHtmlNodeIntersectionMember1
        {
            Content = "content",

            Locales = null,
        };

        Assert.Null(model.Locales);
        Assert.True(model.RawData.ContainsKey("locales"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ElementalHtmlNodeIntersectionMember1
        {
            Content = "content",

            Locales = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ElementalHtmlNodeIntersectionMember1
        {
            Content = "content",
            Locales = new Dictionary<string, LocalesItem>() { { "foo", new("content") } },
        };

        ElementalHtmlNodeIntersectionMember1 copied = new(model);

        Assert.Equal(model, copied);
    }
}
