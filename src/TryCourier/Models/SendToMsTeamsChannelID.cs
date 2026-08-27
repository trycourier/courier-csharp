using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models;

/// <summary>
/// Sends directly to a Microsoft Teams channel by its Bot Framework ID. Still provide
/// at least one of `tenant_id` or `service_url` — sends without either have failed
/// Bot Framework authentication in testing.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SendToMsTeamsChannelID, SendToMsTeamsChannelIDFromRaw>))]
public sealed record class SendToMsTeamsChannelID : JsonModel
{
    public required string ChannelID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("channel_id");
        }
        init { this._rawData.Set("channel_id", value); }
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
        _ = this.ChannelID;
        _ = this.ServiceUrl;
        _ = this.TenantID;
    }

    public SendToMsTeamsChannelID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SendToMsTeamsChannelID(SendToMsTeamsChannelID sendToMsTeamsChannelID)
        : base(sendToMsTeamsChannelID) { }
#pragma warning restore CS8618

    public SendToMsTeamsChannelID(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendToMsTeamsChannelID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SendToMsTeamsChannelIDFromRaw.FromRawUnchecked"/>
    public static SendToMsTeamsChannelID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SendToMsTeamsChannelID(string channelID)
        : this()
    {
        this.ChannelID = channelID;
    }
}

class SendToMsTeamsChannelIDFromRaw : IFromRawJson<SendToMsTeamsChannelID>
{
    /// <inheritdoc/>
    public SendToMsTeamsChannelID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SendToMsTeamsChannelID.FromRawUnchecked(rawData);
}
