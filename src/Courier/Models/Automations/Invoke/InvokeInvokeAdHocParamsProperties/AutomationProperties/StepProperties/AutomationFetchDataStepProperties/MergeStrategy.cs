using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationFetchDataStepProperties;

[JsonConverter(typeof(MergeStrategyConverter))]
public enum MergeStrategy
{
    Replace,
    Overwrite,
    SoftMerge,
}

sealed class MergeStrategyConverter : JsonConverter<MergeStrategy>
{
    public override MergeStrategy Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "replace" => MergeStrategy.Replace,
            "overwrite" => MergeStrategy.Overwrite,
            "soft-merge" => MergeStrategy.SoftMerge,
            _ => (MergeStrategy)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        MergeStrategy value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                MergeStrategy.Replace => "replace",
                MergeStrategy.Overwrite => "overwrite",
                MergeStrategy.SoftMerge => "soft-merge",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
