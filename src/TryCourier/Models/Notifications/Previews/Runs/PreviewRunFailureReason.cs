using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.Notifications.Previews.Runs;

/// <summary>
/// Why the run failed, when `status` is `FAILED`. `NO_EMAIL_CHANNEL` and `TEMPLATE_NOT_SUPPORTED`
/// mean there was nothing to render; `ALL_DEVICES_UNSUPPORTED` means every requested
/// device has been retired and the request can be fixed by choosing others.
/// </summary>
[JsonConverter(typeof(PreviewRunFailureReasonConverter))]
public enum PreviewRunFailureReason
{
    TemplateNotSupported,
    NoEmailChannel,
    RenderFailed,
    AllDevicesUnsupported,
    VendorError,
}

sealed class PreviewRunFailureReasonConverter : JsonConverter<PreviewRunFailureReason>
{
    public override PreviewRunFailureReason Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "TEMPLATE_NOT_SUPPORTED" => PreviewRunFailureReason.TemplateNotSupported,
            "NO_EMAIL_CHANNEL" => PreviewRunFailureReason.NoEmailChannel,
            "RENDER_FAILED" => PreviewRunFailureReason.RenderFailed,
            "ALL_DEVICES_UNSUPPORTED" => PreviewRunFailureReason.AllDevicesUnsupported,
            "VENDOR_ERROR" => PreviewRunFailureReason.VendorError,
            _ => (PreviewRunFailureReason)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PreviewRunFailureReason value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PreviewRunFailureReason.TemplateNotSupported => "TEMPLATE_NOT_SUPPORTED",
                PreviewRunFailureReason.NoEmailChannel => "NO_EMAIL_CHANNEL",
                PreviewRunFailureReason.RenderFailed => "RENDER_FAILED",
                PreviewRunFailureReason.AllDevicesUnsupported => "ALL_DEVICES_UNSUPPORTED",
                PreviewRunFailureReason.VendorError => "VENDOR_ERROR",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
