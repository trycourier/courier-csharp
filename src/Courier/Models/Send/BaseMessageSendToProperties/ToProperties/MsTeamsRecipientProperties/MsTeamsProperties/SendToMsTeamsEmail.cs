using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;

namespace Courier.Models.Send.BaseMessageSendToProperties.ToProperties.MsTeamsRecipientProperties.MsTeamsProperties;

[JsonConverter(typeof(ModelConverter<SendToMsTeamsEmail>))]
public sealed record class SendToMsTeamsEmail : ModelBase, IFromRaw<SendToMsTeamsEmail>
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

    public static implicit operator MsTeamsBaseProperties(SendToMsTeamsEmail sendToMsTeamsEmail) =>
        new()
        {
            ServiceURL = sendToMsTeamsEmail.ServiceURL,
            TenantID = sendToMsTeamsEmail.TenantID,
        };

    public override void Validate()
    {
        _ = this.ServiceURL;
        _ = this.TenantID;
        _ = this.Email;
    }

    public SendToMsTeamsEmail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendToMsTeamsEmail(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static SendToMsTeamsEmail FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
