using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Exceptions;
using System = System;

namespace Courier.Models.Automations.AutomationInvokeAdHocParamsProperties.AutomationProperties.StepProperties.AutomationAddToBatchStepProperties.IntersectionMember1Properties;

/// <summary>
/// Determine the scope of the batching. If user, chosen in this order: recipient,
/// profile.user_id, data.user_id, data.userId. If dynamic, then specify where the
/// batch_key or a reference to the batch_key
/// </summary>
[JsonConverter(typeof(ScopeConverter))]
public enum Scope
{
    User,
    Global,
    Dynamic,
}

sealed class ScopeConverter : JsonConverter<Scope>
{
    public override Scope Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "user" => Scope.User,
            "global" => Scope.Global,
            "dynamic" => Scope.Dynamic,
            _ => (Scope)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Scope value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Scope.User => "user",
                Scope.Global => "global",
                Scope.Dynamic => "dynamic",
                _ => throw new CourierInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
