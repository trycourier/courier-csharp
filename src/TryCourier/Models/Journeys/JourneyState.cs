using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.Journeys;

/// <summary>
/// Lifecycle state of a journey.
/// </summary>
[JsonConverter(typeof(JourneyStateConverter))]
public enum JourneyState
{
    Draft,
    Published,
}

sealed class JourneyStateConverter : JsonConverter<JourneyState>
{
    public override JourneyState Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "DRAFT" => JourneyState.Draft,
            "PUBLISHED" => JourneyState.Published,
            _ => (JourneyState)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneyState value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneyState.Draft => "DRAFT",
                JourneyState.Published => "PUBLISHED",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
