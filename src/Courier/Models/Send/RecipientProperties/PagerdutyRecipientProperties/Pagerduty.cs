using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Send.RecipientProperties.PagerdutyRecipientProperties;

[JsonConverter(typeof(ModelConverter<Pagerduty>))]
public sealed record class Pagerduty : ModelBase, IFromRaw<Pagerduty>
{
    public string? EventAction
    {
        get
        {
            if (!this.Properties.TryGetValue("event_action", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["event_action"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? RoutingKey
    {
        get
        {
            if (!this.Properties.TryGetValue("routing_key", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["routing_key"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Severity
    {
        get
        {
            if (!this.Properties.TryGetValue("severity", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["severity"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Source
    {
        get
        {
            if (!this.Properties.TryGetValue("source", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["source"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.EventAction;
        _ = this.RoutingKey;
        _ = this.Severity;
        _ = this.Source;
    }

    public Pagerduty() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Pagerduty(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Pagerduty FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
