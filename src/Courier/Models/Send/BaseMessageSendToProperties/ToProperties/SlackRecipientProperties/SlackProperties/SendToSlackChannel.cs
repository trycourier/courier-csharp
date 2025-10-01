using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Send.BaseMessageSendToProperties.ToProperties.SlackRecipientProperties.SlackProperties;

[JsonConverter(typeof(ModelConverter<SendToSlackChannel>))]
public sealed record class SendToSlackChannel : ModelBase, IFromRaw<SendToSlackChannel>
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

    public required string Channel
    {
        get
        {
            if (!this.Properties.TryGetValue("channel", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'channel' cannot be null",
                    new ArgumentOutOfRangeException("channel", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'channel' cannot be null",
                    new ArgumentNullException("channel")
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

    public static implicit operator SlackBaseProperties(SendToSlackChannel sendToSlackChannel) =>
        new() { AccessToken = sendToSlackChannel.AccessToken };

    public override void Validate()
    {
        _ = this.AccessToken;
        _ = this.Channel;
    }

    public SendToSlackChannel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendToSlackChannel(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SendToSlackChannel FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
