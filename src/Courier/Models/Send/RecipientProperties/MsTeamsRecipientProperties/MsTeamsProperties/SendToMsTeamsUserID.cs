using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Send.RecipientProperties.MsTeamsRecipientProperties.MsTeamsProperties;

[JsonConverter(typeof(ModelConverter<SendToMsTeamsUserID>))]
public sealed record class SendToMsTeamsUserID : ModelBase, IFromRaw<SendToMsTeamsUserID>
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

    public static implicit operator MsTeamsBaseProperties(
        SendToMsTeamsUserID sendToMsTeamsUserID
    ) =>
        new()
        {
            ServiceURL = sendToMsTeamsUserID.ServiceURL,
            TenantID = sendToMsTeamsUserID.TenantID,
        };

    public override void Validate()
    {
        _ = this.ServiceURL;
        _ = this.TenantID;
        _ = this.UserID;
    }

    public SendToMsTeamsUserID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendToMsTeamsUserID(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SendToMsTeamsUserID FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
