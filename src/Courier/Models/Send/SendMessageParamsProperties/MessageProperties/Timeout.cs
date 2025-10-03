using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Models.Send.SendMessageParamsProperties.MessageProperties.TimeoutProperties;

namespace Courier.Models.Send.SendMessageParamsProperties.MessageProperties;

[JsonConverter(typeof(ModelConverter<Timeout>))]
public sealed record class Timeout : ModelBase, IFromRaw<Timeout>
{
    public Dictionary<string, long>? Channel
    {
        get
        {
            if (!this.Properties.TryGetValue("channel", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, long>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["channel"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ApiEnum<string, Criteria>? Criteria
    {
        get
        {
            if (!this.Properties.TryGetValue("criteria", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ApiEnum<string, Criteria>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["criteria"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? Escalation
    {
        get
        {
            if (!this.Properties.TryGetValue("escalation", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["escalation"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? Message
    {
        get
        {
            if (!this.Properties.TryGetValue("message", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["message"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, long>? Provider
    {
        get
        {
            if (!this.Properties.TryGetValue("provider", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, long>?>(
                element,
                ModelBase.SerializerOptions
            );
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
        if (this.Channel != null)
        {
            foreach (var item in this.Channel.Values)
            {
                _ = item;
            }
        }
        this.Criteria?.Validate();
        _ = this.Escalation;
        _ = this.Message;
        if (this.Provider != null)
        {
            foreach (var item in this.Provider.Values)
            {
                _ = item;
            }
        }
    }

    public Timeout() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Timeout(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Timeout FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
