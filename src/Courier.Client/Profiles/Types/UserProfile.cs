using System.Text.Json.Serialization;
using Courier.Client.Core;
using OneOf;

#nullable enable

namespace Courier.Client;

public record UserProfile
{
    [JsonPropertyName("address")]
    public required Address Address { get; set; }

    [JsonPropertyName("birthdate")]
    public required string Birthdate { get; set; }

    [JsonPropertyName("email")]
    public required string Email { get; set; }

    [JsonPropertyName("email_verified")]
    public required bool EmailVerified { get; set; }

    [JsonPropertyName("family_name")]
    public required string FamilyName { get; set; }

    [JsonPropertyName("gender")]
    public required string Gender { get; set; }

    [JsonPropertyName("given_name")]
    public required string GivenName { get; set; }

    [JsonPropertyName("locale")]
    public required string Locale { get; set; }

    [JsonPropertyName("middle_name")]
    public required string MiddleName { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("nickname")]
    public required string Nickname { get; set; }

    [JsonPropertyName("phone_number")]
    public required string PhoneNumber { get; set; }

    [JsonPropertyName("phone_number_verified")]
    public required bool PhoneNumberVerified { get; set; }

    [JsonPropertyName("picture")]
    public required string Picture { get; set; }

    [JsonPropertyName("preferred_name")]
    public required string PreferredName { get; set; }

    [JsonPropertyName("profile")]
    public required string Profile { get; set; }

    [JsonPropertyName("sub")]
    public required string Sub { get; set; }

    [JsonPropertyName("updated_at")]
    public required string UpdatedAt { get; set; }

    [JsonPropertyName("website")]
    public required string Website { get; set; }

    [JsonPropertyName("zoneinfo")]
    public required string Zoneinfo { get; set; }

    /// <summary>
    /// A free form object. Due to a limitation of the API Explorer, you can only enter string key/values below, but this API accepts more complex object structures.
    /// </summary>
    [JsonPropertyName("custom")]
    public required object Custom { get; set; }

    [JsonPropertyName("airship")]
    public required AirshipProfile Airship { get; set; }

    [JsonPropertyName("apn")]
    public required string Apn { get; set; }

    [JsonPropertyName("target_arn")]
    public required string TargetArn { get; set; }

    [JsonPropertyName("discord")]
    public required OneOf<SendToChannel, SendDirectMessage> Discord { get; set; }

    [JsonPropertyName("expo")]
    public required OneOf<Token, MultipleTokens> Expo { get; set; }

    [JsonPropertyName("facebookPSID")]
    public required string FacebookPsid { get; set; }

    [JsonPropertyName("firebaseToken")]
    public required OneOf<string, IEnumerable<string>> FirebaseToken { get; set; }

    [JsonPropertyName("intercom")]
    public required Intercom Intercom { get; set; }

    [JsonPropertyName("slack")]
    public required OneOf<
        SendToSlackChannel,
        SendToSlackEmail,
        SendToSlackUserId
    > Slack { get; set; }

    [JsonPropertyName("ms_teams")]
    public required OneOf<
        SendToMsTeamsUserId,
        SendToMsTeamsEmail,
        SendToMsTeamsChannelId,
        SendToMsTeamsConversationId,
        SendToMsTeamsChannelName
    > MsTeams { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
