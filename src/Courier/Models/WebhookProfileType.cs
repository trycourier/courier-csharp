using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using System = System;

namespace Courier.Models;

[JsonConverter(typeof(WebhookProfileTypeConverter))]
public enum WebhookProfileType
{
    Limited,
    Expanded,
}

sealed class WebhookProfileTypeConverter : JsonConverter<WebhookProfileType>
{
    public override WebhookProfileType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "limited" => WebhookProfileType.Limited,
            "expanded" => WebhookProfileType.Expanded,
            _ => (WebhookProfileType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookProfileType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebhookProfileType.Limited => "limited",
                WebhookProfileType.Expanded => "expanded",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
