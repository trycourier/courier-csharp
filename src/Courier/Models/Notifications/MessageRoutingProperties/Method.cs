using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;

namespace Courier.Models.Notifications.MessageRoutingProperties;

[JsonConverter(typeof(MethodConverter))]
public enum Method
{
    All,
    Single,
}

sealed class MethodConverter : JsonConverter<Method>
{
    public override Method Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "all" => Method.All,
            "single" => Method.Single,
            _ => (Method)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Method value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Method.All => "all",
                Method.Single => "single",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
