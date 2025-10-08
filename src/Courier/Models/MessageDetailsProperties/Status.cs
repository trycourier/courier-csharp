using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;

namespace Courier.Models.MessageDetailsProperties;

/// <summary>
/// The current status of the message.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Canceled,
    Clicked,
    Delayed,
    Delivered,
    Digested,
    Enqueued,
    Filtered,
    Opened,
    Routed,
    Sent,
    Simulated,
    Throttled,
    Undeliverable,
    Unmapped,
    Unroutable,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "CANCELED" => Status.Canceled,
            "CLICKED" => Status.Clicked,
            "DELAYED" => Status.Delayed,
            "DELIVERED" => Status.Delivered,
            "DIGESTED" => Status.Digested,
            "ENQUEUED" => Status.Enqueued,
            "FILTERED" => Status.Filtered,
            "OPENED" => Status.Opened,
            "ROUTED" => Status.Routed,
            "SENT" => Status.Sent,
            "SIMULATED" => Status.Simulated,
            "THROTTLED" => Status.Throttled,
            "UNDELIVERABLE" => Status.Undeliverable,
            "UNMAPPED" => Status.Unmapped,
            "UNROUTABLE" => Status.Unroutable,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Canceled => "CANCELED",
                Status.Clicked => "CLICKED",
                Status.Delayed => "DELAYED",
                Status.Delivered => "DELIVERED",
                Status.Digested => "DIGESTED",
                Status.Enqueued => "ENQUEUED",
                Status.Filtered => "FILTERED",
                Status.Opened => "OPENED",
                Status.Routed => "ROUTED",
                Status.Sent => "SENT",
                Status.Simulated => "SIMULATED",
                Status.Throttled => "THROTTLED",
                Status.Undeliverable => "UNDELIVERABLE",
                Status.Unmapped => "UNMAPPED",
                Status.Unroutable => "UNROUTABLE",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
