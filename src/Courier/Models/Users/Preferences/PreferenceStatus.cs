using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;

namespace Courier.Models.Users.Preferences;

[JsonConverter(typeof(PreferenceStatusConverter))]
public enum PreferenceStatus
{
    OptedIn,
    OptedOut,
    Required,
}

sealed class PreferenceStatusConverter : JsonConverter<PreferenceStatus>
{
    public override PreferenceStatus Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "OPTED_IN" => PreferenceStatus.OptedIn,
            "OPTED_OUT" => PreferenceStatus.OptedOut,
            "REQUIRED" => PreferenceStatus.Required,
            _ => (PreferenceStatus)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        PreferenceStatus value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                PreferenceStatus.OptedIn => "OPTED_IN",
                PreferenceStatus.OptedOut => "OPTED_OUT",
                PreferenceStatus.Required => "REQUIRED",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
