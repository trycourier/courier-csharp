using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Journeys;

[JsonConverter(
    typeof(JsonModelConverter<JourneySendNodeToSlackEmail, JourneySendNodeToSlackEmailFromRaw>)
)]
public sealed record class JourneySendNodeToSlackEmail : JsonModel
{
    /// <summary>
    /// Email address of the Slack user to send to, resolved via the workspace directory.
    /// </summary>
    public required string Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("email");
        }
        init { this._rawData.Set("email", value); }
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
        _ = this.Email;
        _ = this.AccessToken;
    }

    public JourneySendNodeToSlackEmail() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneySendNodeToSlackEmail(JourneySendNodeToSlackEmail journeySendNodeToSlackEmail)
        : base(journeySendNodeToSlackEmail) { }
#pragma warning restore CS8618

    public JourneySendNodeToSlackEmail(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneySendNodeToSlackEmail(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneySendNodeToSlackEmailFromRaw.FromRawUnchecked"/>
    public static JourneySendNodeToSlackEmail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public JourneySendNodeToSlackEmail(string email)
        : this()
    {
        this.Email = email;
    }
}

class JourneySendNodeToSlackEmailFromRaw : IFromRawJson<JourneySendNodeToSlackEmail>
{
    /// <inheritdoc/>
    public JourneySendNodeToSlackEmail FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneySendNodeToSlackEmail.FromRawUnchecked(rawData);
}
