using System;
using System.Collections.Generic;
using System.Text.Json;
using Courier.Models;
using Courier.Models.Bulk;

namespace Courier.Tests.Models.Bulk;

public class BulkCreateJobParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new BulkCreateJobParams
        {
            Message = new()
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
            },
        };

        InboundBulkMessage expectedMessage = new()
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

        Assert.Equal(expectedMessage, parameters.Message);
    }

    [Fact]
    public void Url_Works()
    {
        BulkCreateJobParams parameters = new()
        {
            Message = new()
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
            },
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.courier.com/bulk"), url);
    }
}
