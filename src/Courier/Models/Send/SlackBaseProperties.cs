using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Send;

[JsonConverter(typeof(ModelConverter<SlackBaseProperties>))]
public sealed record class SlackBaseProperties : ModelBase, IFromRaw<SlackBaseProperties>
{
    public required string AccessToken
    {
        get
        {
            if (!this.Properties.TryGetValue("access_token", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'access_token' cannot be null",
                    new ArgumentOutOfRangeException("access_token", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'access_token' cannot be null",
                    new ArgumentNullException("access_token")
                );
        }
        set
        {
            this.Properties["access_token"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.AccessToken;
    }

    public SlackBaseProperties() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SlackBaseProperties(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SlackBaseProperties FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public SlackBaseProperties(string accessToken)
        : this()
    {
        this.AccessToken = accessToken;
    }
}
