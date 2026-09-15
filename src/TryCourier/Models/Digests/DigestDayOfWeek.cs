using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.Digests;

/// <summary>
/// A day of the week. Accepted case-insensitively, returned lowercase.
/// </summary>
[JsonConverter(typeof(DigestDayOfWeekConverter))]
public enum DigestDayOfWeek
{
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
}

sealed class DigestDayOfWeekConverter : JsonConverter<DigestDayOfWeek>
{
    public override DigestDayOfWeek Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "sunday" => DigestDayOfWeek.Sunday,
            "monday" => DigestDayOfWeek.Monday,
            "tuesday" => DigestDayOfWeek.Tuesday,
            "wednesday" => DigestDayOfWeek.Wednesday,
            "thursday" => DigestDayOfWeek.Thursday,
            "friday" => DigestDayOfWeek.Friday,
            "saturday" => DigestDayOfWeek.Saturday,
            _ => (DigestDayOfWeek)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        DigestDayOfWeek value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                DigestDayOfWeek.Sunday => "sunday",
                DigestDayOfWeek.Monday => "monday",
                DigestDayOfWeek.Tuesday => "tuesday",
                DigestDayOfWeek.Wednesday => "wednesday",
                DigestDayOfWeek.Thursday => "thursday",
                DigestDayOfWeek.Friday => "friday",
                DigestDayOfWeek.Saturday => "saturday",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
