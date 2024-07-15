using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;
using OneOf;

#nullable enable

namespace Courier.Client;

public record UserProfile
{
    [JsonPropertyName("address")]
    public required Address Address { get; init; }

    [JsonPropertyName("birthdate")]
    public required string Birthdate { get; init; }

    [JsonPropertyName("email")]
    public required string Email { get; init; }

    [JsonPropertyName("email_verified")]
    public required bool EmailVerified { get; init; }

    [JsonPropertyName("family_name")]
    public required string FamilyName { get; init; }

    [JsonPropertyName("gender")]
    public required string Gender { get; init; }

    [JsonPropertyName("given_name")]
    public required string GivenName { get; init; }

    [JsonPropertyName("locale")]
    public required string Locale { get; init; }

    [JsonPropertyName("middle_name")]
    public required string MiddleName { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("nickname")]
    public required string Nickname { get; init; }

    [JsonPropertyName("phone_number")]
    public required string PhoneNumber { get; init; }

    [JsonPropertyName("phone_number_verified")]
    public required bool PhoneNumberVerified { get; init; }

    [JsonPropertyName("picture")]
    public required string Picture { get; init; }

    [JsonPropertyName("preferred_name")]
    public required string PreferredName { get; init; }

    [JsonPropertyName("profile")]
    public required string Profile { get; init; }

    [JsonPropertyName("sub")]
    public required string Sub { get; init; }

    [JsonPropertyName("updated_at")]
    public required string UpdatedAt { get; init; }

    [JsonPropertyName("website")]
    public required string Website { get; init; }

    [JsonPropertyName("zoneinfo")]
    public required string Zoneinfo { get; init; }

    /// <summary>
    /// A free form object. Due to a limitation of the API Explorer, you can only enter string key/values below, but this API accepts more complex object structures.
    /// </summary>
    [JsonPropertyName("custom")]
    public required object Custom { get; init; }

    [JsonPropertyName("airship")]
    public required AirshipProfile Airship { get; init; }

    [JsonPropertyName("apn")]
    public required string Apn { get; init; }

    [JsonPropertyName("target_arn")]
    public required string TargetArn { get; init; }

    [JsonPropertyName("discord")]
    [JsonConverter(typeof(OneOfSerializer<OneOf<SendToChannel, SendDirectMessage>>))]
    public required OneOf<SendToChannel, SendDirectMessage> Discord { get; init; }

    [JsonPropertyName("expo")]
    [JsonConverter(typeof(OneOfSerializer<OneOf<Token, MultipleTokens>>))]
    public required OneOf<Token, MultipleTokens> Expo { get; init; }

    [JsonPropertyName("facebookPSID")]
    public required string FacebookPsid { get; init; }

    [JsonPropertyName("firebaseToken")]
    [JsonConverter(typeof(OneOfSerializer<OneOf<string, IEnumerable<string>>>))]
    public required OneOf<string, IEnumerable<string>> FirebaseToken { get; init; }

    [JsonPropertyName("intercom")]
    public required Intercom Intercom { get; init; }

    [JsonPropertyName("slack")]
    [JsonConverter(
        typeof(OneOfSerializer<OneOf<SendToSlackChannel, SendToSlackEmail, SendToSlackUserId>>)
    )]
    public required OneOf<
        SendToSlackChannel,
        SendToSlackEmail,
        SendToSlackUserId
    > Slack { get; init; }

    [JsonPropertyName("ms_teams")]
    [JsonConverter(
        typeof(OneOfSerializer<
            OneOf<
                SendToMsTeamsUserId,
                SendToMsTeamsEmail,
                SendToMsTeamsChannelId,
                SendToMsTeamsConversationId,
                SendToMsTeamsChannelName
            >
        >)
    )]
    public required OneOf<
        SendToMsTeamsUserId,
        SendToMsTeamsEmail,
        SendToMsTeamsChannelId,
        SendToMsTeamsConversationId,
        SendToMsTeamsChannelName
    > MsTeams { get; init; }
}
