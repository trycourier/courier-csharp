using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using TryCourier.Models.Providers;

namespace TryCourier.Tests.Models.Providers;

public class ProviderCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProviderCreateParams
        {
            Provider = "sendgrid",
            Alias = "alias",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "api_key", JsonSerializer.SerializeToElement("bar") },
            },
            Title = "Production SendGrid",
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",
        };

        string expectedProvider = "sendgrid";
        string expectedAlias = "alias";
        Dictionary<string, JsonElement> expectedSettings = new()
        {
            { "api_key", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedTitle = "Production SendGrid";
        string expectedIdempotencyKey = "order-ORD-456-user-123";
        string expectedXIdempotencyExpiration = "1785312000";

        Assert.Equal(expectedProvider, parameters.Provider);
        Assert.Equal(expectedAlias, parameters.Alias);
        Assert.NotNull(parameters.Settings);
        Assert.Equal(expectedSettings.Count, parameters.Settings.Count);
        foreach (var item in expectedSettings)
        {
            Assert.True(parameters.Settings.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Settings[item.Key]));
        }
        Assert.Equal(expectedTitle, parameters.Title);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXIdempotencyExpiration, parameters.XIdempotencyExpiration);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProviderCreateParams { Provider = "sendgrid" };

        Assert.Null(parameters.Alias);
        Assert.False(parameters.RawBodyData.ContainsKey("alias"));
        Assert.Null(parameters.Settings);
        Assert.False(parameters.RawBodyData.ContainsKey("settings"));
        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XIdempotencyExpiration);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-idempotency-expiration"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProviderCreateParams
        {
            Provider = "sendgrid",

            // Null should be interpreted as omitted for these properties
            Alias = null,
            Settings = null,
            Title = null,
            IdempotencyKey = null,
            XIdempotencyExpiration = null,
        };

        Assert.Null(parameters.Alias);
        Assert.False(parameters.RawBodyData.ContainsKey("alias"));
        Assert.Null(parameters.Settings);
        Assert.False(parameters.RawBodyData.ContainsKey("settings"));
        Assert.Null(parameters.Title);
        Assert.False(parameters.RawBodyData.ContainsKey("title"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XIdempotencyExpiration);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-idempotency-expiration"));
    }

    [Fact]
    public void Url_Works()
    {
        ProviderCreateParams parameters = new() { Provider = "sendgrid" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.courier.com/providers"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ProviderCreateParams parameters = new()
        {
            Provider = "sendgrid",
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
        var parameters = new ProviderCreateParams
        {
            Provider = "sendgrid",
            Alias = "alias",
            Settings = new Dictionary<string, JsonElement>()
            {
                { "api_key", JsonSerializer.SerializeToElement("bar") },
            },
            Title = "Production SendGrid",
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",
        };

        ProviderCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
