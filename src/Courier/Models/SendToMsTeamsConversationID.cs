using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(
    typeof(JsonModelConverter<SendToMsTeamsConversationID, SendToMsTeamsConversationIDFromRaw>)
)]
public sealed record class SendToMsTeamsConversationID : JsonModel
{
    public required string ConversationID
    {
        get { return this._rawData.GetNotNullClass<string>("conversation_id"); }
        init { this._rawData.Set("conversation_id", value); }
    }

    public required string ServiceUrl
    {
        get { return this._rawData.GetNotNullClass<string>("service_url"); }
        init { this._rawData.Set("service_url", value); }
    }

    public required string TenantID
    {
        get { return this._rawData.GetNotNullClass<string>("tenant_id"); }
        init { this._rawData.Set("tenant_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ConversationID;
        _ = this.ServiceUrl;
        _ = this.TenantID;
    }

    public SendToMsTeamsConversationID() { }

    public SendToMsTeamsConversationID(SendToMsTeamsConversationID sendToMsTeamsConversationID)
        : base(sendToMsTeamsConversationID) { }

    public SendToMsTeamsConversationID(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendToMsTeamsConversationID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SendToMsTeamsConversationIDFromRaw.FromRawUnchecked"/>
    public static SendToMsTeamsConversationID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SendToMsTeamsConversationIDFromRaw : IFromRawJson<SendToMsTeamsConversationID>
{
    /// <inheritdoc/>
    public SendToMsTeamsConversationID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SendToMsTeamsConversationID.FromRawUnchecked(rawData);
}
