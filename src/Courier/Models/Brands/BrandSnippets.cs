using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(ModelConverter<BrandSnippets, BrandSnippetsFromRaw>))]
public sealed record class BrandSnippets : ModelBase
{
    public IReadOnlyList<BrandSnippet>? Items
    {
        get
        {
            if (!this._rawData.TryGetValue("items", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<BrandSnippet>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["items"] = JsonSerializer.SerializeToElement(
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

    public BrandSnippets(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BrandSnippets(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BrandSnippets FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BrandSnippetsFromRaw : IFromRaw<BrandSnippets>
{
    public BrandSnippets FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BrandSnippets.FromRawUnchecked(rawData);
}
