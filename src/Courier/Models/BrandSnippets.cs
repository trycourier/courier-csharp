using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<BrandSnippets>))]
public sealed record class BrandSnippets : ModelBase, IFromRaw<BrandSnippets>
{
    public List<BrandSnippet>? Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<BrandSnippet>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["items"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        foreach (var item in this.Items ?? [])
        {
            item.Validate();
        }
    }

    public BrandSnippets() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandSnippets(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BrandSnippets FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
