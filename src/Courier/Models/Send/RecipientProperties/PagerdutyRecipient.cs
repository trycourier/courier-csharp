using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Send.RecipientProperties.PagerdutyRecipientProperties;

namespace Courier.Models.Send.RecipientProperties;

[JsonConverter(typeof(ModelConverter<PagerdutyRecipient>))]
public sealed record class PagerdutyRecipient : ModelBase, IFromRaw<PagerdutyRecipient>
{
    public required Pagerduty Pagerduty
    {
        get
        {
            if (!this.Properties.TryGetValue("pagerduty", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'pagerduty' cannot be null",
                    new ArgumentOutOfRangeException("pagerduty", "Missing required argument")
                );

            return JsonSerializer.Deserialize<Pagerduty>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'pagerduty' cannot be null",
                    new ArgumentNullException("pagerduty")
                );
        }
        set
        {
            this.Properties["pagerduty"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.Pagerduty.Validate();
    }

    public PagerdutyRecipient() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    PagerdutyRecipient(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static PagerdutyRecipient FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public PagerdutyRecipient(Pagerduty pagerduty)
        : this()
    {
        this.Pagerduty = pagerduty;
    }
}
