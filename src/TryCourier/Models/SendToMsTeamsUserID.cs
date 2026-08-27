using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models;

/// <summary>
/// Provide at least one of `tenant_id` or `service_url`. If you provide both, they
/// must agree.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SendToMsTeamsUserID, SendToMsTeamsUserIDFromRaw>))]
public sealed record class SendToMsTeamsUserID : JsonModel
{
    public required string UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("user_id");
        }
        init { this._rawData.Set("user_id", value); }
    }

    public string? ServiceUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("service_url");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("service_url", value);
        }
    }

    public string? TenantID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("tenant_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("tenant_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UserID;
        _ = this.ServiceUrl;
        _ = this.TenantID;
    }

    public SendToMsTeamsUserID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SendToMsTeamsUserID(SendToMsTeamsUserID sendToMsTeamsUserID)
        : base(sendToMsTeamsUserID) { }
#pragma warning restore CS8618

    public SendToMsTeamsUserID(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendToMsTeamsUserID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SendToMsTeamsUserIDFromRaw.FromRawUnchecked"/>
    public static SendToMsTeamsUserID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SendToMsTeamsUserID(string userID)
        : this()
    {
        this.UserID = userID;
    }
}

class SendToMsTeamsUserIDFromRaw : IFromRawJson<SendToMsTeamsUserID>
{
    /// <inheritdoc/>
    public SendToMsTeamsUserID FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SendToMsTeamsUserID.FromRawUnchecked(rawData);
}
