using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Generic = System.Collections.Generic;

namespace Courier.Models.Messages.MessageRetrieveResponseProperties;

[JsonConverter(typeof(ModelConverter<IntersectionMember1>))]
public sealed record class IntersectionMember1 : ModelBase, IFromRaw<IntersectionMember1>
{
    public Generic::List<Generic::Dictionary<string, JsonElement>>? Providers
    {
        get
        {
            if (!this.Properties.TryGetValue("providers", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Generic::List<Generic::Dictionary<
                string,
                JsonElement
            >>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["providers"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Providers ?? [])
        {
            foreach (var item1 in item.Values)
            {
                _ = item1;
            }
        }
    }

    public IntersectionMember1() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    IntersectionMember1(Generic::Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static IntersectionMember1 FromRawUnchecked(
        Generic::Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
