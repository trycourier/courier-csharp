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
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "access_token"); }
        init { JsonModel.Set(this._rawData, "access_token", value); }
    }

    public required string UserID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "user_id"); }
        init { JsonModel.Set(this._rawData, "user_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AccessToken;
        _ = this.UserID;
    }

    public SendToSlackUserID() { }

    public SendToSlackUserID(SendToSlackUserID sendToSlackUserID)
        : base(sendToSlackUserID) { }

    public SendToSlackUserID(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendToSlackUserID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
