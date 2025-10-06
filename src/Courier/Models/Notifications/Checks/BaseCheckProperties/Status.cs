using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Notifications.Checks.BaseCheckProperties;

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Resolved,
    Failed,
    Pending,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "RESOLVED" => Status.Resolved,
            "FAILED" => Status.Failed,
            "PENDING" => Status.Pending,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Resolved => "RESOLVED",
                Status.Failed => "FAILED",
                Status.Pending => "PENDING",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
