using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<SendToSlackUserID, SendToSlackUserIDFromRaw>))]
public sealed record class SendToSlackUserID : JsonModel
{
    public required string AccessToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("access_token");
        }
        init { this._rawData.Set("access_token", value); }
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
        _ = this.AccessToken;
        _ = this.UserID;
    }

    public SendToSlackUserID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SendToSlackUserID(SendToSlackUserID sendToSlackUserID)
        : base(sendToSlackUserID) { }
#pragma warning restore CS8618

    public SendToSlackUserID(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendToSlackUserID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SendToSlackUserIDFromRaw.FromRawUnchecked"/>
    public static SendToSlackUserID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SendToSlackUserIDFromRaw : IFromRawJson<SendToSlackUserID>
{
    /// <inheritdoc/>
    public SendToSlackUserID FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SendToSlackUserID.FromRawUnchecked(rawData);
}
