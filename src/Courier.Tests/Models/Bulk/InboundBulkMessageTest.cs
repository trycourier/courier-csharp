using System.Collections.Generic;
using System.Text.Json;
using Courier.Models;
using Courier.Models.Bulk;

namespace Courier.Tests.Models.Bulk;

public class InboundBulkTemplateMessageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundBulkTemplateMessage
        {
            Template = "template",
            Brand = "brand",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Event = "event",
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
        };

        string expectedTemplate = "template";
        string expectedBrand = "brand";
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedEvent = "event";
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

        Assert.Equal(expectedTemplate, model.Template);
        Assert.Equal(expectedBrand, model.Brand);
        Assert.Equal(expectedData.Count, model.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(model.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Data[item.Key]));
        }
        Assert.Equal(expectedEvent, model.Event);
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundBulkTemplateMessage
        {
            Template = "template",
            Brand = "brand",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Event = "event",
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<InboundBulkTemplateMessage>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundBulkTemplateMessage
        {
            Template = "template",
            Brand = "brand",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Event = "event",
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<InboundBulkTemplateMessage>(json);
        Assert.NotNull(deserialized);

        string expectedTemplate = "template";
        string expectedBrand = "brand";
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedEvent = "event";
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

        Assert.Equal(expectedTemplate, deserialized.Template);
        Assert.Equal(expectedBrand, deserialized.Brand);
        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(deserialized.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Data[item.Key]));
        }
        Assert.Equal(expectedEvent, deserialized.Event);
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundBulkTemplateMessage
        {
            Template = "template",
            Brand = "brand",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Event = "event",
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InboundBulkTemplateMessage { Template = "template" };

        Assert.Null(model.Brand);
        Assert.False(model.RawData.ContainsKey("brand"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Event);
        Assert.False(model.RawData.ContainsKey("event"));
        Assert.Null(model.Locale);
        Assert.False(model.RawData.ContainsKey("locale"));
        Assert.Null(model.Override);
        Assert.False(model.RawData.ContainsKey("override"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new InboundBulkTemplateMessage { Template = "template" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new InboundBulkTemplateMessage
        {
            Template = "template",

            Brand = null,
            Data = null,
            Event = null,
            Locale = null,
            Override = null,
        };

        Assert.Null(model.Brand);
        Assert.True(model.RawData.ContainsKey("brand"));
        Assert.Null(model.Data);
        Assert.True(model.RawData.ContainsKey("data"));
        Assert.Null(model.Event);
        Assert.True(model.RawData.ContainsKey("event"));
        Assert.Null(model.Locale);
        Assert.True(model.RawData.ContainsKey("locale"));
        Assert.Null(model.Override);
        Assert.True(model.RawData.ContainsKey("override"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InboundBulkTemplateMessage
        {
            Template = "template",

            Brand = null,
            Data = null,
            Event = null,
            Locale = null,
            Override = null,
        };

        model.Validate();
    }
}

public class InboundBulkContentMessageTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InboundBulkContentMessage
        {
            Content = new ElementalContentSugar() { Body = "body", Title = "title" },
            Brand = "brand",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Event = "event",
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
        };

        Content expectedContent = new ElementalContentSugar() { Body = "body", Title = "title" };
        string expectedBrand = "brand";
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedEvent = "event";
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

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedBrand, model.Brand);
        Assert.Equal(expectedData.Count, model.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(model.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Data[item.Key]));
        }
        Assert.Equal(expectedEvent, model.Event);
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InboundBulkContentMessage
        {
            Content = new ElementalContentSugar() { Body = "body", Title = "title" },
            Brand = "brand",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Event = "event",
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<InboundBulkContentMessage>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InboundBulkContentMessage
        {
            Content = new ElementalContentSugar() { Body = "body", Title = "title" },
            Brand = "brand",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Event = "event",
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
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<InboundBulkContentMessage>(json);
        Assert.NotNull(deserialized);

        Content expectedContent = new ElementalContentSugar() { Body = "body", Title = "title" };
        string expectedBrand = "brand";
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedEvent = "event";
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

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedBrand, deserialized.Brand);
        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(deserialized.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Data[item.Key]));
        }
        Assert.Equal(expectedEvent, deserialized.Event);
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InboundBulkContentMessage
        {
            Content = new ElementalContentSugar() { Body = "body", Title = "title" },
            Brand = "brand",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Event = "event",
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new InboundBulkContentMessage
        {
            Content = new ElementalContentSugar() { Body = "body", Title = "title" },
        };

        Assert.Null(model.Brand);
        Assert.False(model.RawData.ContainsKey("brand"));
        Assert.Null(model.Data);
        Assert.False(model.RawData.ContainsKey("data"));
        Assert.Null(model.Event);
        Assert.False(model.RawData.ContainsKey("event"));
        Assert.Null(model.Locale);
        Assert.False(model.RawData.ContainsKey("locale"));
        Assert.Null(model.Override);
        Assert.False(model.RawData.ContainsKey("override"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new InboundBulkContentMessage
        {
            Content = new ElementalContentSugar() { Body = "body", Title = "title" },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new InboundBulkContentMessage
        {
            Content = new ElementalContentSugar() { Body = "body", Title = "title" },

            Brand = null,
            Data = null,
            Event = null,
            Locale = null,
            Override = null,
        };

        Assert.Null(model.Brand);
        Assert.True(model.RawData.ContainsKey("brand"));
        Assert.Null(model.Data);
        Assert.True(model.RawData.ContainsKey("data"));
        Assert.Null(model.Event);
        Assert.True(model.RawData.ContainsKey("event"));
        Assert.Null(model.Locale);
        Assert.True(model.RawData.ContainsKey("locale"));
        Assert.Null(model.Override);
        Assert.True(model.RawData.ContainsKey("override"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new InboundBulkContentMessage
        {
            Content = new ElementalContentSugar() { Body = "body", Title = "title" },

            Brand = null,
            Data = null,
            Event = null,
            Locale = null,
            Override = null,
        };

        model.Validate();
    }
}
