using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Models.Send.BaseMessageSendToProperties;

namespace Courier.Models.Send;

[JsonConverter(typeof(ModelConverter<BaseMessageSendTo>))]
public sealed record class BaseMessageSendTo : ModelBase, IFromRaw<BaseMessageSendTo>
{
    /// <summary>
    /// The recipient or a list of recipients of the message
    /// </summary>
    public To? To
    {
        get
        {
            if (!this.Properties.TryGetValue("to", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<To?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["to"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.To?.Validate();
    }

    public BaseMessageSendTo() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BaseMessageSendTo(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BaseMessageSendTo FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
