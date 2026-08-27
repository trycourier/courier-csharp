using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Journeys;

[JsonConverter(
    typeof(JsonModelConverter<JourneySendNodeToSlackUserID, JourneySendNodeToSlackUserIDFromRaw>)
)]
public sealed record class JourneySendNodeToSlackUserID : JsonModel
{
    /// <summary>
    /// Slack user ID to send to.
    /// </summary>
    public required string UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("user_id");
        }
        init { this._rawData.Set("user_id", value); }
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
        _ = this.UserID;
        _ = this.AccessToken;
    }

    public JourneySendNodeToSlackUserID() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneySendNodeToSlackUserID(JourneySendNodeToSlackUserID journeySendNodeToSlackUserID)
        : base(journeySendNodeToSlackUserID) { }
#pragma warning restore CS8618

    public JourneySendNodeToSlackUserID(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneySendNodeToSlackUserID(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneySendNodeToSlackUserIDFromRaw.FromRawUnchecked"/>
    public static JourneySendNodeToSlackUserID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public JourneySendNodeToSlackUserID(string userID)
        : this()
    {
        this.UserID = userID;
    }
}

class JourneySendNodeToSlackUserIDFromRaw : IFromRawJson<JourneySendNodeToSlackUserID>
{
    /// <inheritdoc/>
    public JourneySendNodeToSlackUserID FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneySendNodeToSlackUserID.FromRawUnchecked(rawData);
}
