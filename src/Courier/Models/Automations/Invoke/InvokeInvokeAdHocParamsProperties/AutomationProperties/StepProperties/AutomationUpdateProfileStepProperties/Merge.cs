using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Automations.Invoke.InvokeInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationUpdateProfileStepProperties;

[JsonConverter(typeof(MergeConverter))]
public enum Merge
{
    None,
    Overwrite,
    SoftMerge,
    Replace,
}

sealed class MergeConverter : JsonConverter<Merge>
{
    public override Merge Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "none" => Merge.None,
            "overwrite" => Merge.Overwrite,
            "soft-merge" => Merge.SoftMerge,
            "replace" => Merge.Replace,
            _ => (Merge)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Merge value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Merge.None => "none",
                Merge.Overwrite => "overwrite",
                Merge.SoftMerge => "soft-merge",
                Merge.Replace => "replace",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
