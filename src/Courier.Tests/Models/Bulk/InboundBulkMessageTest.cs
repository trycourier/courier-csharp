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
}
