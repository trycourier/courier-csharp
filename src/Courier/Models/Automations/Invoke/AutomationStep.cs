using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Automations.Invoke;

[JsonConverter(typeof(ModelConverter<AutomationStep>))]
public sealed record class AutomationStep : ModelBase, IFromRaw<AutomationStep>
{
    public string? If
    {
        get
        {
            if (!this.Properties.TryGetValue("if", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["if"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Ref
    {
        get
        {
            if (!this.Properties.TryGetValue("ref", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["ref"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.If;
        _ = this.Ref;
    }

    public AutomationStep() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AutomationStep(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AutomationStep FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
