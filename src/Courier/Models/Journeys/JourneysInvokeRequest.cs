using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models.Journeys;

/// <summary>
/// Request body for invoking a journey. Requires either a user identifier or a profile
/// with contact information. User identifiers can be provided via user_id field,
/// or resolved from profile/data objects (user_id, userId, or anonymousId fields).
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JourneysInvokeRequest, JourneysInvokeRequestFromRaw>))]
public sealed record class JourneysInvokeRequest : JsonModel
{
    /// <summary>
    /// Data payload passed to the journey. The expected shape can be predefined
    /// using the schema builder in the journey editor. This data is available in
    /// journey steps for condition evaluation and template variable interpolation.
    /// Can also contain user identifiers (user_id, userId, anonymousId) if not provided elsewhere.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Data
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("data");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "data",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Profile data for the user. Can contain contact information (email, phone_number),
    /// user identifiers (user_id, userId, anonymousId), or any custom profile fields.
    /// Profile fields are merged with any existing stored profile for the user. Include
    /// context.tenant_id to load a tenant-scoped profile for multi-tenant scenarios.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement>? Profile
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<FrozenDictionary<string, JsonElement>>("profile");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set<FrozenDictionary<string, JsonElement>?>(
                "profile",
                value == null ? null : FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// A unique identifier for the user. If not provided, the system will attempt
    /// to resolve the user identifier from profile or data objects.
    /// </summary>
    public string? UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("user_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Data;
        _ = this.Profile;
        _ = this.UserID;
    }

    public JourneysInvokeRequest() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneysInvokeRequest(JourneysInvokeRequest journeysInvokeRequest)
        : base(journeysInvokeRequest) { }
#pragma warning restore CS8618

    public JourneysInvokeRequest(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneysInvokeRequest(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneysInvokeRequestFromRaw.FromRawUnchecked"/>
    public static JourneysInvokeRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneysInvokeRequestFromRaw : IFromRawJson<JourneysInvokeRequest>
{
    /// <inheritdoc/>
    public JourneysInvokeRequest FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneysInvokeRequest.FromRawUnchecked(rawData);
}
