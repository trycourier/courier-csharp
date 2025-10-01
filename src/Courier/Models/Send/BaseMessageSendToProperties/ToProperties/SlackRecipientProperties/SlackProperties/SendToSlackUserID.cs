using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Send.BaseMessageSendToProperties.ToProperties.SlackRecipientProperties.SlackProperties;

[JsonConverter(typeof(ModelConverter<SendToSlackUserID>))]
public sealed record class SendToSlackUserID : ModelBase, IFromRaw<SendToSlackUserID>
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

    public required string UserID
    {
        get
        {
            if (!this.Properties.TryGetValue("user_id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'user_id' cannot be null",
                    new ArgumentOutOfRangeException("user_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'user_id' cannot be null",
                    new ArgumentNullException("user_id")
                );
        }
        set
        {
            this.Properties["user_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public static implicit operator SlackBaseProperties(SendToSlackUserID sendToSlackUserID) =>
        new() { AccessToken = sendToSlackUserID.AccessToken };

    public override void Validate()
    {
        _ = this.AccessToken;
        _ = this.UserID;
    }

    public SendToSlackUserID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendToSlackUserID(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SendToSlackUserID FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
