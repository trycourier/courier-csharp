using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client.Users;

public record AddUserToSingleTenantsParamsProfile
{
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    /// <summary>
    /// Email Address
    /// </summary>
    [JsonPropertyName("email")]
    public required string Email { get; set; }

    /// <summary>
    /// A valid phone number
    /// </summary>
    [JsonPropertyName("phone_number")]
    public required string PhoneNumber { get; set; }

    /// <summary>
    /// The user's preferred ISO 639-1 language code.
    /// </summary>
    [JsonPropertyName("locale")]
    public required string Locale { get; set; }

    /// <summary>
    /// Additional provider specific fields may be specified.
    /// </summary>
    [JsonPropertyName("additional_fields")]
    public Dictionary<string, object?> AdditionalFields { get; set; } =
        new Dictionary<string, object?>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
