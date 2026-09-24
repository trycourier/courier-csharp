using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.Notifications.Previews.Runs;

/// <summary>
/// Why one device's render failed, when its `status` is `FAILED` and the cause has
/// a public name. `DELIVERY_FAILED` means the rendering service could not deliver
/// the message to its own capture mailbox — infrastructure, not anything wrong with
/// the template.
/// </summary>
[JsonConverter(typeof(PreviewResultFailureReasonConverter))]
public enum PreviewResultFailureReason
{
    DeliveryFailed,
}

sealed class PreviewResultFailureReasonConverter : JsonConverter<PreviewResultFailureReason>
{
    public override PreviewResultFailureReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DELIVERY_FAILED" => PreviewResultFailureReason.DeliveryFailed,
            _ => (PreviewResultFailureReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PreviewResultFailureReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PreviewResultFailureReason.DeliveryFailed => "DELIVERY_FAILED",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
