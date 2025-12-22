using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using System = System;

namespace Courier.Models;

[JsonConverter(typeof(WebhookAuthModeConverter))]
public enum WebhookAuthMode
{
    None,
    Basic,
    Bearer,
}

sealed class WebhookAuthModeConverter : JsonConverter<WebhookAuthMode>
{
    public override WebhookAuthMode Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => WebhookAuthMode.None,
            "basic" => WebhookAuthMode.Basic,
            "bearer" => WebhookAuthMode.Bearer,
            _ => (WebhookAuthMode)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookAuthMode value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebhookAuthMode.None => "none",
                WebhookAuthMode.Basic => "basic",
                WebhookAuthMode.Bearer => "bearer",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
