using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Send.RecipientProperties.SlackRecipientProperties.SlackProperties;

[JsonConverter(typeof(ModelConverter<SendToSlackEmail>))]
public sealed record class SendToSlackEmail : ModelBase, IFromRaw<SendToSlackEmail>
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

    public required string Email
    {
        get
        {
            if (!this.Properties.TryGetValue("email", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'email' cannot be null",
                    new ArgumentOutOfRangeException("email", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'email' cannot be null",
                    new ArgumentNullException("email")
                );
        }
        set
        {
            this.Properties["email"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public static implicit operator SlackBaseProperties(SendToSlackEmail sendToSlackEmail) =>
        new() { AccessToken = sendToSlackEmail.AccessToken };

    public override void Validate()
    {
        _ = this.AccessToken;
        _ = this.Email;
    }

    public SendToSlackEmail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendToSlackEmail(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SendToSlackEmail FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
