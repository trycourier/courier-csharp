using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Send.RecipientProperties.MsTeamsRecipientProperties.MsTeamsProperties;

[JsonConverter(typeof(ModelConverter<SendToMsTeamsConversationID>))]
public sealed record class SendToMsTeamsConversationID
    : ModelBase,
        IFromRaw<SendToMsTeamsConversationID>
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

    public required string ConversationID
    {
        get
        {
            if (!this.Properties.TryGetValue("conversation_id", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'conversation_id' cannot be null",
                    new ArgumentOutOfRangeException("conversation_id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'conversation_id' cannot be null",
                    new ArgumentNullException("conversation_id")
                );
        }
        set
        {
            this.Properties["conversation_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public static implicit operator MsTeamsBaseProperties(
        SendToMsTeamsConversationID sendToMsTeamsConversationID
    ) =>
        new()
        {
            ServiceURL = sendToMsTeamsConversationID.ServiceURL,
            TenantID = sendToMsTeamsConversationID.TenantID,
        };

    public override void Validate()
    {
        _ = this.ServiceURL;
        _ = this.TenantID;
        _ = this.ConversationID;
    }

    public SendToMsTeamsConversationID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendToMsTeamsConversationID(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SendToMsTeamsConversationID FromRawUnchecked(
        Dictionary<string, JsonElement> properties
    )
    {
        return new(properties);
    }
}
