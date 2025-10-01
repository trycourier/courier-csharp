using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;
using Courier.Exceptions;
using Courier.Models.Send.BaseMessageProperties.ExpiryProperties;

namespace Courier.Models.Send.BaseMessageProperties;

/// <summary>
/// "Expiry allows you to set an absolute or relative time in which a message expires.
///  Note: This is only valid for the Courier Inbox channel as of 12-08-2022."
/// </summary>
[JsonConverter(typeof(ModelConverter<Expiry>))]
public sealed record class Expiry : ModelBase, IFromRaw<Expiry>
{
    /// <summary>
    /// A duration in the form of milliseconds or an ISO8601 Duration format (i.e. P1DT4H).
    /// </summary>
    public required ExpiresIn ExpiresIn
    {
        get
        {
            if (!this.Properties.TryGetValue("expires_in", out JsonElement element))
                throw new CourierInvalidDataException(
                    "'expires_in' cannot be null",
                    new ArgumentOutOfRangeException("expires_in", "Missing required argument")
                );

            return JsonSerializer.Deserialize<ExpiresIn>(element, ModelBase.SerializerOptions)
                ?? throw new CourierInvalidDataException(
                    "'expires_in' cannot be null",
                    new ArgumentNullException("expires_in")
                );
        }
        set
        {
            this.Properties["expires_in"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// An epoch timestamp or ISO8601 timestamp with timezone `(YYYY-MM-DDThh:mm:ss.sTZD)`
    /// that describes the time in which a message expires.
    /// </summary>
    public string? ExpiresAt
    {
        get
        {
            if (!this.Properties.TryGetValue("expires_at", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        set
        {
            this.Properties["expires_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        this.ExpiresIn.Validate();
        _ = this.ExpiresAt;
    }

    public Expiry() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Expiry(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static Expiry FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }

    [SetsRequiredMembers]
    public Expiry(ExpiresIn expiresIn)
        : this()
    {
        this.ExpiresIn = expiresIn;
    }
}
