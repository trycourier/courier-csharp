using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;

namespace Courier.Models.Send.BaseMessageSendToProperties.ToProperties.WebhookRecipientProperties.WebhookProperties.AuthenticationProperties;

/// <summary>
/// The authentication mode to use. Defaults to 'none' if not specified.
/// </summary>
[JsonConverter(typeof(ModeConverter))]
public enum Mode
{
    None,
    Basic,
    Bearer,
}

sealed class ModeConverter : JsonConverter<Mode>
{
    public override Mode Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => Mode.None,
            "basic" => Mode.Basic,
            "bearer" => Mode.Bearer,
            _ => (Mode)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Mode value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Mode.None => "none",
                Mode.Basic => "basic",
                Mode.Bearer => "bearer",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
