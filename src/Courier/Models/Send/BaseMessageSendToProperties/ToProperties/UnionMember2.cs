using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Send.BaseMessageSendToProperties.ToProperties;

[JsonConverter(typeof(ModelConverter<UnionMember2>))]
public sealed record class UnionMember2 : ModelBase, IFromRaw<UnionMember2>
{
    public Dictionary<string, JsonElement>? Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? ListPattern
    {
        get
        {
            if (!this.Properties.TryGetValue("list_pattern", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["list_pattern"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        if (this.Data != null)
        {
            foreach (var item in this.Data.Values)
            {
                _ = item;
            }
        }
        _ = this.ListPattern;
    }

    public UnionMember2() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember2(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static UnionMember2 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
