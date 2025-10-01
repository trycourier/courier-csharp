using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Send.BaseMessageSendToProperties.ToProperties.MsTeamsRecipientProperties.MsTeamsProperties;

[JsonConverter(typeof(ModelConverter<SendToMsTeamsChannelName>))]
public sealed record class SendToMsTeamsChannelName : ModelBase, IFromRaw<SendToMsTeamsChannelName>
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

    public required string ChannelName
    {
        get
        {
            if (!this.Properties.TryGetValue("channel_name", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'channel_name' cannot be null",
                    new ArgumentOutOfRangeException("channel_name", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'channel_name' cannot be null",
                    new ArgumentNullException("channel_name")
                );
        }
        set
        {
            this.Properties["channel_name"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public required string TeamID
    {
        get
        {
            if (!this.Properties.TryGetValue("team_id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'team_id' cannot be null",
                    new ArgumentOutOfRangeException("team_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'team_id' cannot be null",
                    new ArgumentNullException("team_id")
                );
        }
        set
        {
            this.Properties["team_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public static implicit operator MsTeamsBaseProperties(
        SendToMsTeamsChannelName sendToMsTeamsChannelName
    ) =>
        new()
        {
            ServiceURL = sendToMsTeamsChannelName.ServiceURL,
            TenantID = sendToMsTeamsChannelName.TenantID,
        };

    public override void Validate()
    {
        _ = this.ServiceURL;
        _ = this.TenantID;
        _ = this.ChannelName;
        _ = this.TeamID;
    }

    public SendToMsTeamsChannelName() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendToMsTeamsChannelName(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SendToMsTeamsChannelName FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
