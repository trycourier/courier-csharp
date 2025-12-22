using System.Text.Json;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models;

namespace Courier.Tests.Models;

public class WebhookAuthModeTest : TestBase
{
    [Theory]
    [InlineData(WebhookAuthMode.None)]
    [InlineData(WebhookAuthMode.Basic)]
    [InlineData(WebhookAuthMode.Bearer)]
    public void Validation_Works(WebhookAuthMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookAuthMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookAuthMode>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<CourierInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(WebhookAuthMode.None)]
    [InlineData(WebhookAuthMode.Basic)]
    [InlineData(WebhookAuthMode.Bearer)]
    public void SerializationRoundtrip_Works(WebhookAuthMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, WebhookAuthMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookAuthMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, WebhookAuthMode>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, WebhookAuthMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
