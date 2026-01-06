using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

[JsonConverter(
    typeof(JsonModelConverter<SendToMsTeamsChannelName, SendToMsTeamsChannelNameFromRaw>)
)]
public sealed record class SendToMsTeamsChannelName : JsonModel
{
    public required string ChannelName
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "channel_name"); }
        init { JsonModel.Set(this._rawData, "channel_name", value); }
    }

    public required string ServiceUrl
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "service_url"); }
        init { JsonModel.Set(this._rawData, "service_url", value); }
    }

    public required string TeamID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "team_id"); }
        init { JsonModel.Set(this._rawData, "team_id", value); }
    }

    public required string TenantID
    {
        get { return JsonModel.GetNotNullClass<string>(this.RawData, "tenant_id"); }
        init { JsonModel.Set(this._rawData, "tenant_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChannelName;
        _ = this.ServiceUrl;
        _ = this.TeamID;
        _ = this.TenantID;
    }

    public SendToMsTeamsChannelName() { }

    public SendToMsTeamsChannelName(SendToMsTeamsChannelName sendToMsTeamsChannelName)
        : base(sendToMsTeamsChannelName) { }

    public SendToMsTeamsChannelName(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendToMsTeamsChannelName(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SendToMsTeamsChannelNameFromRaw.FromRawUnchecked"/>
    public static SendToMsTeamsChannelName FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class SendToMsTeamsChannelNameFromRaw : IFromRawJson<SendToMsTeamsChannelName>
{
    /// <inheritdoc/>
    public SendToMsTeamsChannelName FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SendToMsTeamsChannelName.FromRawUnchecked(rawData);
}
