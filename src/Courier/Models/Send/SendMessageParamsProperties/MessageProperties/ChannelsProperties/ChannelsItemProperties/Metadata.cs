using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ChannelsProperties.ChannelsItemProperties;

[JsonConverter(typeof(ModelConverter<Metadata>))]
public sealed record class Metadata : ModelBase, IFromRaw<Metadata>
{
    public Utm? Utm
    {
        get
        {
            if (!this.Properties.TryGetValue("utm", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Utm?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["utm"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Utm?.Validate();
    }

    public Metadata() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Metadata(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Metadata FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
