using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using TryCourier.Models.Notifications.Previews.Runs;

namespace TryCourier.Tests.Models.Notifications.Previews.Runs;

public class RunCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new RunCreateParams
        {
            ID = "id",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            DeviceIds = ["pvd_1w6dgafr3aaycvv9a8bm996pkc", "pvd_34qvmj6p4dbqaa5mpys1ekt9jx"],
            DeviceSetID = "device_set_id",
            Locale = "locale",
            TemplateVersion = "draft",
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",
        };

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedData = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        List<string> expectedDeviceIds =
        [
            "pvd_1w6dgafr3aaycvv9a8bm996pkc",
            "pvd_34qvmj6p4dbqaa5mpys1ekt9jx",
        ];
        string expectedDeviceSetID = "device_set_id";
        string expectedLocale = "locale";
        string expectedTemplateVersion = "draft";
        string expectedIdempotencyKey = "order-ORD-456-user-123";
        string expectedXIdempotencyExpiration = "1785312000";

        Assert.Equal(expectedID, parameters.ID);
        Assert.NotNull(parameters.Data);
        Assert.Equal(expectedData.Count, parameters.Data.Count);
        foreach (var item in expectedData)
        {
            Assert.True(parameters.Data.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, parameters.Data[item.Key]));
        }
        Assert.NotNull(parameters.DeviceIds);
        Assert.Equal(expectedDeviceIds.Count, parameters.DeviceIds.Count);
        for (int i = 0; i < expectedDeviceIds.Count; i++)
        {
            Assert.Equal(expectedDeviceIds[i], parameters.DeviceIds[i]);
        }
        Assert.Equal(expectedDeviceSetID, parameters.DeviceSetID);
        Assert.Equal(expectedLocale, parameters.Locale);
        Assert.Equal(expectedTemplateVersion, parameters.TemplateVersion);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedXIdempotencyExpiration, parameters.XIdempotencyExpiration);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new RunCreateParams { ID = "id" };

        Assert.Null(parameters.Data);
        Assert.False(parameters.RawBodyData.ContainsKey("data"));
        Assert.Null(parameters.DeviceIds);
        Assert.False(parameters.RawBodyData.ContainsKey("device_ids"));
        Assert.Null(parameters.DeviceSetID);
        Assert.False(parameters.RawBodyData.ContainsKey("device_set_id"));
        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawBodyData.ContainsKey("locale"));
        Assert.Null(parameters.TemplateVersion);
        Assert.False(parameters.RawBodyData.ContainsKey("template_version"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XIdempotencyExpiration);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-idempotency-expiration"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new RunCreateParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            Data = null,
            DeviceIds = null,
            DeviceSetID = null,
            Locale = null,
            TemplateVersion = null,
            IdempotencyKey = null,
            XIdempotencyExpiration = null,
        };

        Assert.Null(parameters.Data);
        Assert.False(parameters.RawBodyData.ContainsKey("data"));
        Assert.Null(parameters.DeviceIds);
        Assert.False(parameters.RawBodyData.ContainsKey("device_ids"));
        Assert.Null(parameters.DeviceSetID);
        Assert.False(parameters.RawBodyData.ContainsKey("device_set_id"));
        Assert.Null(parameters.Locale);
        Assert.False(parameters.RawBodyData.ContainsKey("locale"));
        Assert.Null(parameters.TemplateVersion);
        Assert.False(parameters.RawBodyData.ContainsKey("template_version"));
        Assert.Null(parameters.IdempotencyKey);
        Assert.False(parameters.RawHeaderData.ContainsKey("Idempotency-Key"));
        Assert.Null(parameters.XIdempotencyExpiration);
        Assert.False(parameters.RawHeaderData.ContainsKey("x-idempotency-expiration"));
    }

    [Fact]
    public void Url_Works()
    {
        RunCreateParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.courier.com/notifications/id/previews/runs"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        RunCreateParams parameters = new()
        {
            ID = "id",
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
        var parameters = new RunCreateParams
        {
            ID = "id",
            Data = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            DeviceIds = ["pvd_1w6dgafr3aaycvv9a8bm996pkc", "pvd_34qvmj6p4dbqaa5mpys1ekt9jx"],
            DeviceSetID = "device_set_id",
            Locale = "locale",
            TemplateVersion = "draft",
            IdempotencyKey = "order-ORD-456-user-123",
            XIdempotencyExpiration = "1785312000",
        };

        RunCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
