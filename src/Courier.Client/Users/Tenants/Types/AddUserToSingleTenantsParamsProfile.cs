using System.Text.Json.Serialization;

#nullable enable

namespace Courier.Client.Users;

public record AddUserToSingleTenantsParamsProfile
{
    [JsonPropertyName("title")]
    public required string Title { get; init; }

    /// <summary>
    /// Email Address
    /// </summary>
    [JsonPropertyName("email")]
    public required string Email { get; init; }

    /// <summary>
    /// A valid phone number
    /// </summary>
    [JsonPropertyName("phone_number")]
    public required string PhoneNumber { get; init; }

    /// <summary>
    /// The user's preferred ISO 639-1 language code.
    /// </summary>
    [JsonPropertyName("locale")]
    public required string Locale { get; init; }

    /// <summary>
    /// Additional provider specific fields may be specified.
    /// </summary>
    [JsonPropertyName("additional_fields")]
    public Dictionary<string, object> AdditionalFields { get; init; } =
        new Dictionary<string, object>();
}
