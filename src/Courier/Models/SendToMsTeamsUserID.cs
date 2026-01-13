using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<SendToMsTeamsUserID, SendToMsTeamsUserIDFromRaw>))]
public sealed record class SendToMsTeamsUserID : JsonModel
{
    public required string ServiceUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("service_url");
        }
        init { this._rawData.Set("service_url", value); }
    }

    public required string TenantID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("tenant_id");
        }
        init { this._rawData.Set("tenant_id", value); }
    }

    public required string UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("user_id");
        }
        init { this._rawData.Set("user_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ServiceUrl;
        _ = this.TenantID;
        _ = this.UserID;
    }

    public SendToMsTeamsUserID() { }

    public SendToMsTeamsUserID(SendToMsTeamsUserID sendToMsTeamsUserID)
        : base(sendToMsTeamsUserID) { }

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
}

class SendToMsTeamsUserIDFromRaw : IFromRawJson<SendToMsTeamsUserID>
{
    /// <inheritdoc/>
    public SendToMsTeamsUserID FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SendToMsTeamsUserID.FromRawUnchecked(rawData);
}
