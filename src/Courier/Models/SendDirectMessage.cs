using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<SendDirectMessage, SendDirectMessageFromRaw>))]
public sealed record class SendDirectMessage : JsonModel
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

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.UserID;
    }

    public SendDirectMessage() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SendDirectMessage(SendDirectMessage sendDirectMessage)
        : base(sendDirectMessage) { }
#pragma warning restore CS8618

    public SendDirectMessage(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendDirectMessage(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SendDirectMessageFromRaw.FromRawUnchecked"/>
    public static SendDirectMessage FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SendDirectMessage(string userID)
        : this()
    {
        this.UserID = userID;
    }
}

class SendDirectMessageFromRaw : IFromRawJson<SendDirectMessage>
{
    /// <inheritdoc/>
    public SendDirectMessage FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SendDirectMessage.FromRawUnchecked(rawData);
}
