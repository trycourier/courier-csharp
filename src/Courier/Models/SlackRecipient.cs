using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Core;

namespace Courier.Models;

/// <summary>
/// Send via Slack (channel, email, or user_id)
/// </summary>
[JsonConverter(typeof(JsonModelConverter<SlackRecipient, SlackRecipientFromRaw>))]
public sealed record class SlackRecipient : JsonModel
{
    public required Slack Slack
    {
        get { return this._rawData.GetNotNullClass<Slack>("slack"); }
        init { this._rawData.Set("slack", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Slack.Validate();
    }

    public SlackRecipient() { }

    public SlackRecipient(SlackRecipient slackRecipient)
        : base(slackRecipient) { }

    public SlackRecipient(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SlackRecipient(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SlackRecipientFromRaw.FromRawUnchecked"/>
    public static SlackRecipient FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SlackRecipient(Slack slack)
        : this()
    {
        this.Slack = slack;
    }
}

class SlackRecipientFromRaw : IFromRawJson<SlackRecipient>
{
    /// <inheritdoc/>
    public SlackRecipient FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        SlackRecipient.FromRawUnchecked(rawData);
}
