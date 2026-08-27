using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Journeys;

[JsonConverter(
    typeof(JsonModelConverter<JourneySendNodeToSlackChannel, JourneySendNodeToSlackChannelFromRaw>)
)]
public sealed record class JourneySendNodeToSlackChannel : JsonModel
{
    /// <summary>
    /// Slack channel to send to, by name or ID.
    /// </summary>
    public required string Channel
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("channel");
        }
        init { this._rawData.Set("channel", value); }
    }

    /// <summary>
    /// A runtime reference to a Slack access token, such as `{{data.slack_token}}`.
    /// Literal values are rejected — they'd be stored permanently with no way to
    /// rotate them. Omit to use the token on the recipient's stored Slack profile.
    /// </summary>
    public string? AccessToken
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("access_token");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("access_token", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Channel;
        _ = this.AccessToken;
    }

    public JourneySendNodeToSlackChannel() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneySendNodeToSlackChannel(
        JourneySendNodeToSlackChannel journeySendNodeToSlackChannel
    )
        : base(journeySendNodeToSlackChannel) { }
#pragma warning restore CS8618

    public JourneySendNodeToSlackChannel(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneySendNodeToSlackChannel(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneySendNodeToSlackChannelFromRaw.FromRawUnchecked"/>
    public static JourneySendNodeToSlackChannel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public JourneySendNodeToSlackChannel(string channel)
        : this()
    {
        this.Channel = channel;
    }
}

class JourneySendNodeToSlackChannelFromRaw : IFromRawJson<JourneySendNodeToSlackChannel>
{
    /// <inheritdoc/>
    public JourneySendNodeToSlackChannel FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneySendNodeToSlackChannel.FromRawUnchecked(rawData);
}
