using System.Text.Json.Serialization;

namespace Courier.Net.Users;

public class AddUserToSingleTenantsParamsProfile
{
    [JsonPropertyName("title")]
    public string Title { get; init; }

    /// <summary>
    /// Email Address
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; init; }

    /// <summary>
    /// A valid phone number
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; init; }

    /// <summary>
    /// The user's preferred ISO 639-1 language code.
    /// </summary>
    [JsonPropertyName("locale")]
    public string Locale { get; init; }

    /// <summary>
    /// Additional provider specific fields may be specified.
    /// </summary>
    [JsonPropertyName("additional_fields")]
    public Dictionary<string, object> AdditionalFields { get; init; }
}
