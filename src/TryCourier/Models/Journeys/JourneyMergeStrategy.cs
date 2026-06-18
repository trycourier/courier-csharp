using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Exceptions;
using System = System;

namespace TryCourier.Models.Journeys;

/// <summary>
/// Strategy for merging a fetch response into the journey run state.
/// </summary>
[JsonConverter(typeof(JourneyMergeStrategyConverter))]
public enum JourneyMergeStrategy
{
    Overwrite,
    SoftMerge,
    Replace,
    None,
}

sealed class JourneyMergeStrategyConverter : JsonConverter<JourneyMergeStrategy>
{
    public override JourneyMergeStrategy Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "overwrite" => JourneyMergeStrategy.Overwrite,
            "soft-merge" => JourneyMergeStrategy.SoftMerge,
            "replace" => JourneyMergeStrategy.Replace,
            "none" => JourneyMergeStrategy.None,
            _ => (JourneyMergeStrategy)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        JourneyMergeStrategy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                JourneyMergeStrategy.Overwrite => "overwrite",
                JourneyMergeStrategy.SoftMerge => "soft-merge",
                JourneyMergeStrategy.Replace => "replace",
                JourneyMergeStrategy.None => "none",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
