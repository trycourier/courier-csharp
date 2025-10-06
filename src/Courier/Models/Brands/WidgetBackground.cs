using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Brands;

[JsonConverter(typeof(ModelConverter<WidgetBackground>))]
public sealed record class WidgetBackground : ModelBase, IFromRaw<WidgetBackground>
{
    public string? BottomColor
    {
        get
        {
            if (!this.Properties.TryGetValue("bottomColor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["bottomColor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? TopColor
    {
        get
        {
            if (!this.Properties.TryGetValue("topColor", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["topColor"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.BottomColor;
        _ = this.TopColor;
    }

    public WidgetBackground() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WidgetBackground(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static WidgetBackground FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
