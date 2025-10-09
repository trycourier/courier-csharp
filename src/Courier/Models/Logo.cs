using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<Logo>))]
public sealed record class Logo : ModelBase, IFromRaw<Logo>
{
    public string? Href
    {
        get
        {
            if (!this.Properties.TryGetValue("href", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["href"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Image
    {
        get
        {
            if (!this.Properties.TryGetValue("image", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["image"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Href;
        _ = this.Image;
    }

    public Logo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Logo(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Logo FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
