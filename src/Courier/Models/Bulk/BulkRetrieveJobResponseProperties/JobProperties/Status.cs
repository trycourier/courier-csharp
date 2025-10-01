using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;

namespace Courier.Models.Bulk.BulkRetrieveJobResponseProperties.JobProperties;

[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Created,
    Processing,
    Completed,
    Error,
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
            "CREATED" => Status.Created,
            "PROCESSING" => Status.Processing,
            "COMPLETED" => Status.Completed,
            "ERROR" => Status.Error,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Created => "CREATED",
                Status.Processing => "PROCESSING",
                Status.Completed => "COMPLETED",
                Status.Error => "ERROR",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
