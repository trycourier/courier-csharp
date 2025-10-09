using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Models.DefaultPreferencesProperties;

namespace Courier.Models;

[JsonConverter(typeof(ModelConverter<DefaultPreferences>))]
public sealed record class DefaultPreferences : ModelBase, IFromRaw<DefaultPreferences>
{
    public List<Item>? Items
    {
        get
        {
            if (!this.Properties.TryGetValue("items", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Item>?>(element, ModelBase.SerializerOptions);
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

    public DefaultPreferences() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    DefaultPreferences(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static DefaultPreferences FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
