using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ChannelsProperties.ChannelsItemProperties;

[JsonConverter(typeof(ModelConverter<Timeouts>))]
public sealed record class Timeouts : ModelBase, IFromRaw<Timeouts>
{
    public long? Channel
    {
        get
        {
            if (!this.Properties.TryGetValue("channel", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["channel"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? Provider
    {
        get
        {
            if (!this.Properties.TryGetValue("provider", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["provider"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Channel;
        _ = this.Provider;
    }

    public Timeouts() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Timeouts(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Timeouts FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
