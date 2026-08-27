using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models;

/// <summary>
/// `team_id` is required alongside `channel_name`. Also provide at least one of `tenant_id`
/// or `service_url`; if you provide both, they must agree.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<SendToMsTeamsChannelName, SendToMsTeamsChannelNameFromRaw>)
)]
public sealed record class SendToMsTeamsChannelName : JsonModel
{
    public required string ChannelName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("channel_name");
        }
        init { this._rawData.Set("channel_name", value); }
    }

    public required string TeamID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("team_id");
        }
        init { this._rawData.Set("team_id", value); }
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
        _ = this.ChannelName;
        _ = this.TeamID;
        _ = this.ServiceUrl;
        _ = this.TenantID;
    }

    public SendToMsTeamsChannelName() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SendToMsTeamsChannelName(SendToMsTeamsChannelName sendToMsTeamsChannelName)
        : base(sendToMsTeamsChannelName) { }
#pragma warning restore CS8618

    public SendToMsTeamsChannelName(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SendToMsTeamsChannelName(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
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
