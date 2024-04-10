using System.Text.Json.Serialization;
using Courier.Net;
using OneOf;

namespace Courier.Net;

public class UserProfile
{
    [JsonPropertyName("address")]
    public Address Address { get; init; }

    [JsonPropertyName("birthdate")]
    public string Birthdate { get; init; }

    [JsonPropertyName("email")]
    public string Email { get; init; }

    [JsonPropertyName("email_verified")]
    public bool EmailVerified { get; init; }

    [JsonPropertyName("family_name")]
    public string FamilyName { get; init; }

    [JsonPropertyName("gender")]
    public string Gender { get; init; }

    [JsonPropertyName("given_name")]
    public string GivenName { get; init; }

    [JsonPropertyName("locale")]
    public string Locale { get; init; }

    [JsonPropertyName("middle_name")]
    public string MiddleName { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }

    [JsonPropertyName("nickname")]
    public string Nickname { get; init; }

    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; init; }

    [JsonPropertyName("phone_number_verified")]
    public bool PhoneNumberVerified { get; init; }

    [JsonPropertyName("picture")]
    public string Picture { get; init; }

    [JsonPropertyName("preferred_name")]
    public string PreferredName { get; init; }

    [JsonPropertyName("profile")]
    public string Profile { get; init; }

    [JsonPropertyName("sub")]
    public string Sub { get; init; }

    [JsonPropertyName("updated_at")]
    public string UpdatedAt { get; init; }

    [JsonPropertyName("website")]
    public string Website { get; init; }

    [JsonPropertyName("zoneinfo")]
    public string Zoneinfo { get; init; }

    /// <summary>
    /// A free form object. Due to a limitation of the API Explorer, you can only enter string key/values below, but this API accepts more complex object structures.
    /// </summary>
    [JsonPropertyName("custom")]
    public object Custom { get; init; }

    [JsonPropertyName("airship")]
    public AirshipProfile Airship { get; init; }

    [JsonPropertyName("apn")]
    public string Apn { get; init; }

    [JsonPropertyName("target_arn")]
    public string TargetArn { get; init; }

    [JsonPropertyName("discord")]
    public OneOf<SendToChannel, SendDirectMessage> Discord { get; init; }

    [JsonPropertyName("expo")]
    public OneOf<Token, MultipleTokens> Expo { get; init; }

    [JsonPropertyName("facebookPSID")]
    public string FacebookPsid { get; init; }

    [JsonPropertyName("firebaseToken")]
    public string FirebaseToken { get; init; }

    [JsonPropertyName("intercom")]
    public Intercom Intercom { get; init; }

    [JsonPropertyName("slack")]
    public OneOf<SendToSlackChannel, SendToSlackEmail, SendToSlackUserId> Slack { get; init; }

    [JsonPropertyName("ms_teams")]
    public OneOf<SendToMsTeamsUserId, SendToMsTeamsEmail, SendToMsTeamsChannelId, SendToMsTeamsConversationId, SendToMsTeamsChannelName> MsTeams { get; init; }
}
