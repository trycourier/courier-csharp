using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.Notifications.Previews.Runs;

/// <summary>
/// Where the run itself has got to. `PENDING` and `RENDERED` mean Courier is still
/// preparing the email, `SUBMITTED` means it is with the rendering service, and
/// `COMPLETED` means every device has reported. `FAILED` is the run as a whole failing
/// — an individual device failing never fails the run.
/// </summary>
[JsonConverter(typeof(PreviewRunStatusConverter))]
public enum PreviewRunStatus
{
    Pending,
    Rendered,
    Submitted,
    Completed,
    Failed,
}

sealed class PreviewRunStatusConverter : JsonConverter<PreviewRunStatus>
{
    public override PreviewRunStatus Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "PENDING" => PreviewRunStatus.Pending,
            "RENDERED" => PreviewRunStatus.Rendered,
            "SUBMITTED" => PreviewRunStatus.Submitted,
            "COMPLETED" => PreviewRunStatus.Completed,
            "FAILED" => PreviewRunStatus.Failed,
            _ => (PreviewRunStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PreviewRunStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PreviewRunStatus.Pending => "PENDING",
                PreviewRunStatus.Rendered => "RENDERED",
                PreviewRunStatus.Submitted => "SUBMITTED",
                PreviewRunStatus.Completed => "COMPLETED",
                PreviewRunStatus.Failed => "FAILED",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
