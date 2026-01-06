using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(typeof(JsonModelConverter<SendToMsTeamsChannelID, SendToMsTeamsChannelIDFromRaw>))]
public sealed record class SendToMsTeamsChannelID : JsonModel
{
    public required string ChannelID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "channel_id"); }
        init { JsonModel.Set(this._rawData, "channel_id", value); }
    }

    public required string ServiceUrl
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "service_url"); }
        init { JsonModel.Set(this._rawData, "service_url", value); }
    }

    public required string TenantID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "tenant_id"); }
        init { JsonModel.Set(this._rawData, "tenant_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChannelID;
        _ = this.ServiceUrl;
        _ = this.TenantID;
    }

    public SendToMsTeamsChannelID() { }

    public SendToMsTeamsChannelID(SendToMsTeamsChannelID sendToMsTeamsChannelID)
        : base(sendToMsTeamsChannelID) { }

    public SendToMsTeamsChannelID(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendToMsTeamsChannelID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SendToMsTeamsChannelIDFromRaw.FromRawUnchecked"/>
    public static SendToMsTeamsChannelID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SendToMsTeamsChannelIDFromRaw : IFromRawJson<SendToMsTeamsChannelID>
{
    /// <inheritdoc/>
    public SendToMsTeamsChannelID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SendToMsTeamsChannelID.FromRawUnchecked(rawData);
}
