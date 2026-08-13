using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using TryCourier.Models.Automations.Invoke;

namespace TryCourier.Tests.Models.Automations.Invoke;

public class InvokeInvokeByTemplateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvokeInvokeByTemplateParams
        {
            TemplateID = "templateId",
            Recipient = "user_abc",
            Brand = "brand",
            Data = new Dictionary<string, JsonElement>()
            {
                { "orderId", JsonSerializer.SerializeToElement("bar") },
            },
            Profile = new Dictionary<string, JsonElement>()
            {
                { "email", JsonSerializer.SerializeToElement("bar") },
            },
            Template = "template",
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",
        };

        string expectedTemplateID = "templateId";
        string expectedRecipient = "user_abc";
        string expectedBrand = "brand";
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "orderId", JsonSerializer.SerializeToElement("bar") },
        };
        Dictionary<string, JsonElement> expectedProfile = new()
        {
            { "email", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedTemplate = "template";
        string expectedIdempotencyKey = "order-ORD-456-user-123";
        string expectedXIdempotencyExpiration = "1785312000";

        Assert.Equal(expectedTemplateID, parameters.TemplateID);
        Assert.Equal(expectedRecipient, parameters.Recipient);
        Assert.Equal(expectedBrand, parameters.Brand);
        Assert.NotNull(parameters.Data);
        Assert.Equal(expectedData.Count, parameters.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(parameters.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Data[item.Key]));
        }
        Assert.NotNull(parameters.Profile);
        Assert.Equal(expectedProfile.Count, parameters.Profile.Count);
        foreach (var item in expectedProfile)
        {
            Assert.True(parameters.Profile.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Profile[item.Key]));
        }
        Assert.Equal(expectedTemplate, parameters.Template);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXIdempotencyExpiration, parameters.XIdempotencyExpiration);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InvokeInvokeByTemplateParams
        {
            TemplateID = "templateId",
            Recipient = "user_abc",
            Brand = "brand",
            Data = new Dictionary<string, JsonElement>()
            {
                { "orderId", JsonSerializer.SerializeToElement("bar") },
            },
            Profile = new Dictionary<string, JsonElement>()
            {
                { "email", JsonSerializer.SerializeToElement("bar") },
            },
            Template = "template",
        };

        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XIdempotencyExpiration);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-idempotency-expiration"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new InvokeInvokeByTemplateParams
        {
            TemplateID = "templateId",
            Recipient = "user_abc",
            Brand = "brand",
            Data = new Dictionary<string, JsonElement>()
            {
                { "orderId", JsonSerializer.SerializeToElement("bar") },
            },
            Profile = new Dictionary<string, JsonElement>()
            {
                { "email", JsonSerializer.SerializeToElement("bar") },
            },
            Template = "template",

            // Null should be interpreted as omitted for these properties
            IdempotencyKey = null,
            XIdempotencyExpiration = null,
        };

        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XIdempotencyExpiration);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-idempotency-expiration"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new InvokeInvokeByTemplateParams
        {
            TemplateID = "templateId",
            Recipient = "user_abc",
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",
        };

        Assert.Null(parameters.Brand);
        Assert.False(parameters.RawBodyData.ContainsKey("brand"));
        Assert.Null(parameters.Data);
        Assert.False(parameters.RawBodyData.ContainsKey("data"));
        Assert.Null(parameters.Profile);
        Assert.False(parameters.RawBodyData.ContainsKey("profile"));
        Assert.Null(parameters.Template);
        Assert.False(parameters.RawBodyData.ContainsKey("template"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new InvokeInvokeByTemplateParams
        {
            TemplateID = "templateId",
            Recipient = "user_abc",
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",

            Brand = null,
            Data = null,
            Profile = null,
            Template = null,
        };

        Assert.Null(parameters.Brand);
        Assert.True(parameters.RawBodyData.ContainsKey("brand"));
        Assert.Null(parameters.Data);
        Assert.True(parameters.RawBodyData.ContainsKey("data"));
        Assert.Null(parameters.Profile);
        Assert.True(parameters.RawBodyData.ContainsKey("profile"));
        Assert.Null(parameters.Template);
        Assert.True(parameters.RawBodyData.ContainsKey("template"));
    }

    [Fact]
    public void Url_Works()
    {
        InvokeInvokeByTemplateParams parameters = new()
        {
            TemplateID = "templateId",
            Recipient = "user_abc",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/automations/templateId/invoke"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        InvokeInvokeByTemplateParams parameters = new()
        {
            TemplateID = "templateId",
            Recipient = "user_abc",
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(
            ["order-ORD-456-user-123"],
            requestMessage.Headers.GetValues("Idempotency-Key")
        );
        Assert.Equal(["1785312000"], requestMessage.Headers.GetValues("x-idempotency-expiration"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InvokeInvokeByTemplateParams
        {
            TemplateID = "templateId",
            Recipient = "user_abc",
            Brand = "brand",
            Data = new Dictionary<string, JsonElement>()
            {
                { "orderId", JsonSerializer.SerializeToElement("bar") },
            },
            Profile = new Dictionary<string, JsonElement>()
            {
                { "email", JsonSerializer.SerializeToElement("bar") },
            },
            Template = "template",
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",
        };

        InvokeInvokeByTemplateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
