using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands.BrandSettingsProperties.EmailProperties;

[JsonConverter(typeof(ModelConverter<Footer>))]
public sealed record class Footer : ModelBase, IFromRaw<Footer>
{
    public string? Content
    {
        get
        {
            if (!this.Properties.TryGetValue("content", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["content"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public bool? InheritDefault
    {
        get
        {
            if (!this.Properties.TryGetValue("inheritDefault", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<bool?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["inheritDefault"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Content;
        _ = this.InheritDefault;
    }

    public Footer() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Footer(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Footer FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
