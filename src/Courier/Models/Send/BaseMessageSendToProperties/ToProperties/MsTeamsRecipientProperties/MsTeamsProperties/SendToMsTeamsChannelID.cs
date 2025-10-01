using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Send.BaseMessageSendToProperties.ToProperties.MsTeamsRecipientProperties.MsTeamsProperties;

[JsonConverter(typeof(ModelConverter<SendToMsTeamsChannelID>))]
public sealed record class SendToMsTeamsChannelID : ModelBase, IFromRaw<SendToMsTeamsChannelID>
{
    public required string ServiceURL
    {
        get
        {
            if (!this.Properties.TryGetValue("service_url", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'service_url' cannot be null",
                    new ArgumentOutOfRangeException("service_url", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'service_url' cannot be null",
                    new ArgumentNullException("service_url")
                );
        }
        set
        {
            this.Properties["service_url"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string TenantID
    {
        get
        {
            if (!this.Properties.TryGetValue("tenant_id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'tenant_id' cannot be null",
                    new ArgumentOutOfRangeException("tenant_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'tenant_id' cannot be null",
                    new ArgumentNullException("tenant_id")
                );
        }
        set
        {
            this.Properties["tenant_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string ChannelID
    {
        get
        {
            if (!this.Properties.TryGetValue("channel_id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'channel_id' cannot be null",
                    new ArgumentOutOfRangeException("channel_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'channel_id' cannot be null",
                    new ArgumentNullException("channel_id")
                );
        }
        set
        {
            this.Properties["channel_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public static implicit operator MsTeamsBaseProperties(
        SendToMsTeamsChannelID sendToMsTeamsChannelID
    ) =>
        new()
        {
            ServiceURL = sendToMsTeamsChannelID.ServiceURL,
            TenantID = sendToMsTeamsChannelID.TenantID,
        };

    public override void Validate()
    {
        _ = this.ServiceURL;
        _ = this.TenantID;
        _ = this.ChannelID;
    }

    public SendToMsTeamsChannelID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendToMsTeamsChannelID(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SendToMsTeamsChannelID FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
