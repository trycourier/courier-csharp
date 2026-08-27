using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using TryCourier.Core;

namespace TryCourier.Models.Journeys;

/// <summary>
/// Send to a Microsoft Teams address directly, bypassing the recipient's stored profile.
/// Requires exactly one target: `channel_id`, `channel_name` (with `team_id`), `user_id`,
/// or `email`. `channel_name`, `user_id`, and `email` also need at least one of `service_url`
/// or `tenant_id` — if you provide both, they must agree. `channel_id` doesn't require
/// tenant context to publish, but provide `service_url` or `tenant_id` anyway: sends
/// without either have failed at delivery in testing. `conversation_id` and `reply_to_activity_id`,
/// available on the send API's `MsTeams` profile, aren't supported here yet.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<JourneySendNodeToMsTeams, JourneySendNodeToMsTeamsFromRaw>)
)]
public sealed record class JourneySendNodeToMsTeams : JsonModel
{
    /// <summary>
    /// Bot Framework channel ID to send to.
    /// </summary>
    public string? ChannelID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("channel_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("channel_id", value);
        }
    }

    /// <summary>
    /// Teams channel name to send to. Requires `team_id`.
    /// </summary>
    public string? ChannelName
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("channel_name");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("channel_name", value);
        }
    }

    /// <summary>
    /// Email address of the Teams user to send to.
    /// </summary>
    public string? Email
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("email");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("email", value);
        }
    }

    /// <summary>
    /// The regional Bot Framework host for this conversation, e.g. `https://smba.trafficmanager.net/amer`.
    /// A path segment naming the Microsoft tenant may follow it and is used to derive
    /// `tenant_id` when it is not supplied directly.
    /// </summary>
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

    /// <summary>
    /// Microsoft Teams team ID. Required alongside `channel_name`.
    /// </summary>
    public string? TeamID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("team_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("team_id", value);
        }
    }

    /// <summary>
    /// The Microsoft (Azure AD) tenant this send targets or authenticates against.
    /// Unrelated to `message.context.tenant_id`, which is the Courier customer's
    /// own multi-tenant context.
    /// </summary>
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

    /// <summary>
    /// Microsoft Teams user ID to send to.
    /// </summary>
    public string? UserID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("user_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("user_id", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ChannelID;
        _ = this.ChannelName;
        _ = this.Email;
        _ = this.ServiceUrl;
        _ = this.TeamID;
        _ = this.TenantID;
        _ = this.UserID;
    }

    public JourneySendNodeToMsTeams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JourneySendNodeToMsTeams(JourneySendNodeToMsTeams journeySendNodeToMsTeams)
        : base(journeySendNodeToMsTeams) { }
#pragma warning restore CS8618

    public JourneySendNodeToMsTeams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JourneySendNodeToMsTeams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JourneySendNodeToMsTeamsFromRaw.FromRawUnchecked"/>
    public static JourneySendNodeToMsTeams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class JourneySendNodeToMsTeamsFromRaw : IFromRawJson<JourneySendNodeToMsTeams>
{
    /// <inheritdoc/>
    public JourneySendNodeToMsTeams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => JourneySendNodeToMsTeams.FromRawUnchecked(rawData);
}
