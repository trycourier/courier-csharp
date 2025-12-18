using System.Collections.Generic;
using System.Text.Json;
using Courier.Models;
using Courier.Models.Bulk;

namespace Courier.Tests.Models.Bulk;

public class InboundBulkMessageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundBulkMessage
        {
            Event = "event",
            Brand = "brand",
            Content = new ElementalContentSugar() { Body = "body", Title = "title" },
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Locale = new Dictionary<string, Dictionary<string, JsonElement>>()
            {
                {
                    "foo",
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                },
            },
            Override = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Template = "template",
        };

        string expectedEvent = "event";
        string expectedBrand = "brand";
        Content expectedContent = new ElementalContentSugar() { Body = "body", Title = "title" };
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Dictionary<string, Dictionary<string, JsonElement>> expectedLocale = new()
        {
            {
                "foo",
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            },
        };
        Dictionary<string, JsonElement> expectedOverride = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedTemplate = "template";

        Assert.Equal(expectedEvent, model.Event);
        Assert.Equal(expectedBrand, model.Brand);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedData.Count, model.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(model.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Data[item.Key]));
        }
        Assert.Equal(expectedLocale.Count, model.Locale.Count);
        foreach (var item in expectedLocale)
        {
            Assert.True(model.Locale.TryGetValue(item.Key, out var value));

            Assert.Equal(value.Count, model.Locale[item.Key].Count);
            foreach (var item1 in value)
            {
                Assert.True(model.Locale[item.Key].TryGetValue(item1.Key, out var value1));

                Assert.True(JsonElement.DeepEquals(value1, model.Locale[item.Key][item1.Key]));
            }
        }
        Assert.Equal(expectedOverride.Count, model.Override.Count);
        foreach (var item in expectedOverride)
        {
            Assert.True(model.Override.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Override[item.Key]));
        }
        Assert.Equal(expectedTemplate, model.Template);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundBulkMessage
        {
            Event = "event",
            Brand = "brand",
            Content = new ElementalContentSugar() { Body = "body", Title = "title" },
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Locale = new Dictionary<string, Dictionary<string, JsonElement>>()
            {
                {
                    "foo",
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                },
            },
            Override = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Template = "template",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<InboundBulkMessage>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundBulkMessage
        {
            Event = "event",
            Brand = "brand",
            Content = new ElementalContentSugar() { Body = "body", Title = "title" },
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Locale = new Dictionary<string, Dictionary<string, JsonElement>>()
            {
                {
                    "foo",
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                },
            },
            Override = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Template = "template",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<InboundBulkMessage>(element);
        Assert.NotNull(deserialized);

        string expectedEvent = "event";
        string expectedBrand = "brand";
        Content expectedContent = new ElementalContentSugar() { Body = "body", Title = "title" };
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        Dictionary<string, Dictionary<string, JsonElement>> expectedLocale = new()
        {
            {
                "foo",
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                }
            },
        };
        Dictionary<string, JsonElement> expectedOverride = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedTemplate = "template";

        Assert.Equal(expectedEvent, deserialized.Event);
        Assert.Equal(expectedBrand, deserialized.Brand);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(deserialized.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Data[item.Key]));
        }
        Assert.Equal(expectedLocale.Count, deserialized.Locale.Count);
        foreach (var item in expectedLocale)
        {
            Assert.True(deserialized.Locale.TryGetValue(item.Key, out var value));

            Assert.Equal(value.Count, deserialized.Locale[item.Key].Count);
            foreach (var item1 in value)
            {
                Assert.True(deserialized.Locale[item.Key].TryGetValue(item1.Key, out var value1));

                Assert.True(
                    JsonElement.DeepEquals(value1, deserialized.Locale[item.Key][item1.Key])
                );
            }
        }
        Assert.Equal(expectedOverride.Count, deserialized.Override.Count);
        foreach (var item in expectedOverride)
        {
            Assert.True(deserialized.Override.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Override[item.Key]));
        }
        Assert.Equal(expectedTemplate, deserialized.Template);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundBulkMessage
        {
            Event = "event",
            Brand = "brand",
            Content = new ElementalContentSugar() { Body = "body", Title = "title" },
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Locale = new Dictionary<string, Dictionary<string, JsonElement>>()
            {
                {
                    "foo",
                    new Dictionary<string, JsonElement>()
                    {
                        { "foo", JsonSerializer.SerializeToElement("bar") },
                    }
                },
            },
            Override = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Template = "template",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InboundBulkMessage { Event = "event" };

        Assert.Null(model.Brand);
        Assert.False(model.RawData.ContainsKey("brand"));
        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Locale);
        Assert.False(model.RawData.ContainsKey("locale"));
        Assert.Null(model.Override);
        Assert.False(model.RawData.ContainsKey("override"));
        Assert.Null(model.Template);
        Assert.False(model.RawData.ContainsKey("template"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new InboundBulkMessage { Event = "event" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new InboundBulkMessage
        {
            Event = "event",

            Brand = null,
            Content = null,
            Data = null,
            Locale = null,
            Override = null,
            Template = null,
        };

        Assert.Null(model.Brand);
        Assert.True(model.RawData.ContainsKey("brand"));
        Assert.Null(model.Content);
        Assert.True(model.RawData.ContainsKey("content"));
        Assert.Null(model.Data);
        Assert.True(model.RawData.ContainsKey("data"));
        Assert.Null(model.Locale);
        Assert.True(model.RawData.ContainsKey("locale"));
        Assert.Null(model.Override);
        Assert.True(model.RawData.ContainsKey("override"));
        Assert.Null(model.Template);
        Assert.True(model.RawData.ContainsKey("template"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InboundBulkMessage
        {
            Event = "event",

            Brand = null,
            Content = null,
            Data = null,
            Locale = null,
            Override = null,
            Template = null,
        };

        model.Validate();
    }
}

public class ContentTest : TestBase
{
    [Fact]
    public void ElementalContentSugarValidationWorks()
    {
        Content value = new(new ElementalContentSugar() { Body = "body", Title = "title" });
        value.Validate();
    }

    [Fact]
    public void ElementalValidationWorks()
    {
        Content value = new(
            new ElementalContent()
            {
                Elements =
                [
                    new ElementalTextNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "version",
                Brand = "brand",
            }
        );
        value.Validate();
    }

    [Fact]
    public void ElementalContentSugarSerializationRoundtripWorks()
    {
        Content value = new(new ElementalContentSugar() { Body = "body", Title = "title" });
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Content>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ElementalSerializationRoundtripWorks()
    {
        Content value = new(
            new ElementalContent()
            {
                Elements =
                [
                    new ElementalTextNodeWithType()
                    {
                        Channels = ["string"],
                        If = "if",
                        Loop = "loop",
                        Ref = "ref",
                        Type = ElementalTextNodeWithTypeIntersectionMember1Type.Text,
                    },
                ],
                Version = "version",
                Brand = "brand",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Content>(element);

        Assert.Equal(value, deserialized);
    }
}
