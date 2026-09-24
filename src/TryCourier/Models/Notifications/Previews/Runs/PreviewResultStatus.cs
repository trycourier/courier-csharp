using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.Notifications.Previews.Runs;

/// <summary>
/// One device's outcome. `COMPLETED` means the screenshot exists and its URLs are
/// populated. `UNSUPPORTED`, `TIMED_OUT` and `FAILED` are all terminal, and none
/// stands in for another — `UNSUPPORTED` means the device was retired at the vendor,
/// `TIMED_OUT` means it did not report in time.
/// </summary>
[JsonConverter(typeof(PreviewResultStatusConverter))]
public enum PreviewResultStatus
{
    Pending,
    Processing,
    Completed,
    Unsupported,
    TimedOut,
    Failed,
}

sealed class PreviewResultStatusConverter : JsonConverter<PreviewResultStatus>
{
    public override PreviewResultStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PENDING" => PreviewResultStatus.Pending,
            "PROCESSING" => PreviewResultStatus.Processing,
            "COMPLETED" => PreviewResultStatus.Completed,
            "UNSUPPORTED" => PreviewResultStatus.Unsupported,
            "TIMED_OUT" => PreviewResultStatus.TimedOut,
            "FAILED" => PreviewResultStatus.Failed,
            _ => (PreviewResultStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PreviewResultStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PreviewResultStatus.Pending => "PENDING",
                PreviewResultStatus.Processing => "PROCESSING",
                PreviewResultStatus.Completed => "COMPLETED",
                PreviewResultStatus.Unsupported => "UNSUPPORTED",
                PreviewResultStatus.TimedOut => "TIMED_OUT",
                PreviewResultStatus.Failed => "FAILED",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
