using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;

namespace Courier.Models.Automations.Invoke;

[JsonConverter(typeof(MergeAlgorithmConverter))]
public enum MergeAlgorithm
{
    Replace,
    None,
    Overwrite,
    SoftMerge,
}

sealed class MergeAlgorithmConverter : JsonConverter<MergeAlgorithm>
{
    public override MergeAlgorithm Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "replace" => MergeAlgorithm.Replace,
            "none" => MergeAlgorithm.None,
            "overwrite" => MergeAlgorithm.Overwrite,
            "soft-merge" => MergeAlgorithm.SoftMerge,
            _ => (MergeAlgorithm)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MergeAlgorithm value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MergeAlgorithm.Replace => "replace",
                MergeAlgorithm.None => "none",
                MergeAlgorithm.Overwrite => "overwrite",
                MergeAlgorithm.SoftMerge => "soft-merge",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
