using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Models.Send.BaseMessageSendToProperties.ToProperties.UnionMember1Properties;

namespace Courier.Models.Send.BaseMessageSendToProperties.ToProperties;

[JsonConverter(typeof(ModelConverter<UnionMember1>))]
public sealed record class UnionMember1 : ModelBase, IFromRaw<UnionMember1>
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

    public List<Filter>? Filters
    {
        get
        {
            if (!this.Properties.TryGetValue("filters", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Filter>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["filters"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? ListID
    {
        get
        {
            if (!this.Properties.TryGetValue("list_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["list_id"] = JsonSerializer.SerializeToElement(
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
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
        _ = this.ListID;
    }

    public UnionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UnionMember1(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static UnionMember1 FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
