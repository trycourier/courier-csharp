using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using System = System;

namespace Courier.Models;

[JsonConverter(typeof(WebhookMethodConverter))]
public enum WebhookMethod
{
    Post,
    Put,
}

sealed class WebhookMethodConverter : JsonConverter<WebhookMethod>
{
    public override WebhookMethod Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "POST" => WebhookMethod.Post,
            "PUT" => WebhookMethod.Put,
            _ => (WebhookMethod)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        WebhookMethod value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                WebhookMethod.Post => "POST",
                WebhookMethod.Put => "PUT",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
