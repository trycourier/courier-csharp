using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<BrandColors>))]
public sealed record class BrandColors : ModelBase, IFromRaw<BrandColors>
{
    public string? Primary
    {
        get
        {
            if (!this.Properties.TryGetValue("primary", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["primary"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Secondary
    {
        get
        {
            if (!this.Properties.TryGetValue("secondary", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["secondary"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Primary;
        _ = this.Secondary;
    }

    public BrandColors() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandColors(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BrandColors FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
