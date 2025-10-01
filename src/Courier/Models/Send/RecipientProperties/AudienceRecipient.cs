using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Send.RecipientProperties.AudienceRecipientProperties;

namespace Courier.Models.Send.RecipientProperties;

[JsonConverter(typeof(ModelConverter<AudienceRecipient>))]
public sealed record class AudienceRecipient : ModelBase, IFromRaw<AudienceRecipient>
{
    /// <summary>
    /// A unique identifier associated with an Audience. A message will be sent to
    /// each user in the audience.
    /// </summary>
    public required string AudienceID
    {
        get
        {
            if (!this.Properties.TryGetValue("audience_id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'audience_id' cannot be null",
                    new ArgumentOutOfRangeException("audience_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'audience_id' cannot be null",
                    new ArgumentNullException("audience_id")
                );
        }
        set
        {
            this.Properties["audience_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public Dictionary<string, JsonElement>? Data
    {
        get
        {
            if (!this.Properties.TryGetValue("data", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<Dictionary<string, JsonElement>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["data"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public List<Filter>? Filters
    {
        get
        {
            if (!this.Properties.TryGetValue("filters", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<Filter>?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["filters"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.AudienceID;
        if (this.Data != null)
        {
            foreach (var item in this.Data.Values)
            {
                _ = item;
            }
        }
        foreach (var item in this.Filters ?? [])
        {
            item.Validate();
        }
    }

    public AudienceRecipient() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    AudienceRecipient(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static AudienceRecipient FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public AudienceRecipient(string audienceID)
        : this()
    {
        this.AudienceID = audienceID;
    }
}
