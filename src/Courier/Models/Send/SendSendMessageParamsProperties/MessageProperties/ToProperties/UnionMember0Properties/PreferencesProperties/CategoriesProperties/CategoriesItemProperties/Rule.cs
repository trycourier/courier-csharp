using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Send.SendSendMessageParamsProperties.MessageProperties.ToProperties.UnionMember0Properties.PreferencesProperties.CategoriesProperties.CategoriesItemProperties;

[JsonConverter(typeof(ModelConverter<Rule>))]
public sealed record class Rule : ModelBase, IFromRaw<Rule>
{
    public required string Until
    {
        get
        {
            if (!this.Properties.TryGetValue("until", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'until' cannot be null",
                    new ArgumentOutOfRangeException("until", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'until' cannot be null",
                    new ArgumentNullException("until")
                );
        }
        set
        {
            this.Properties["until"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public string? Start
    {
        get
        {
            if (!this.Properties.TryGetValue("start", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["start"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.Until;
        _ = this.Start;
    }

    public Rule() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Rule(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Rule FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Rule(string until)
        : this()
    {
        this.Until = until;
    }
}
