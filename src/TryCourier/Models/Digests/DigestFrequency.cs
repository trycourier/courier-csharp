using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.Digests;

/// <summary>
/// How often a digest is delivered. `instant` delivers immediately without batching,
/// and is the one value that takes no `time`.
/// </summary>
[JsonConverter(typeof(DigestFrequencyConverter))]
public enum DigestFrequency
{
    Instant,
    Daily,
    Weekdays,
    Weekly,
    CustomDays,
    Monthly,
}

sealed class DigestFrequencyConverter : JsonConverter<DigestFrequency>
{
    public override DigestFrequency Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "instant" => DigestFrequency.Instant,
            "daily" => DigestFrequency.Daily,
            "weekdays" => DigestFrequency.Weekdays,
            "weekly" => DigestFrequency.Weekly,
            "custom_days" => DigestFrequency.CustomDays,
            "monthly" => DigestFrequency.Monthly,
            _ => (DigestFrequency)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DigestFrequency value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DigestFrequency.Instant => "instant",
                DigestFrequency.Daily => "daily",
                DigestFrequency.Weekdays => "weekdays",
                DigestFrequency.Weekly => "weekly",
                DigestFrequency.CustomDays => "custom_days",
                DigestFrequency.Monthly => "monthly",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
