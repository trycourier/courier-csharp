using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using ProvidersItemProperties = Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ProvidersProperties.ProvidersItemProperties;

namespace Courier.Models.Send.SendMessageParamsProperties.MessageProperties.ProvidersProperties;

[JsonConverter(typeof(ModelConverter<ProvidersItem>))]
public sealed record class ProvidersItem : ModelBase, IFromRaw<ProvidersItem>
{
    /// <summary>
    /// JS conditional with access to data/profile.
    /// </summary>
    public string? If
    {
        get
        {
            if (!this.Properties.TryGetValue("if", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["if"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public ProvidersItemProperties::Metadata? Metadata
    {
        get
        {
            if (!this.Properties.TryGetValue("metadata", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<ProvidersItemProperties::Metadata?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["metadata"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Provider-specific overrides.
    /// </summary>
    public Dictionary<string, JsonElement>? Override
    {
        get
        {
            if (!this.Properties.TryGetValue("override", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["override"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public long? Timeouts
    {
        get
        {
            if (!this.Properties.TryGetValue("timeouts", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<long?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["timeouts"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.If;
        this.Metadata?.Validate();
        if (this.Override != null)
        {
            foreach (var item in this.Override.Values)
            {
                _ = item;
            }
        }
        _ = this.Timeouts;
    }

    public ProvidersItem() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ProvidersItem(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static ProvidersItem FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
