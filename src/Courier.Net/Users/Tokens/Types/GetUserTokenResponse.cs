using System.Text.Json.Serialization;
using Courier.Net.Core;
using Courier.Net.Users;
using OneOf;

#nullable enable

namespace Courier.Net.Users;

public record GetUserTokenResponse
{
    [JsonPropertyName("status")]
    public TokenStatus? Status { get; init; }

    /// <summary>
    /// The reason for the token status.
    /// </summary>
    [JsonPropertyName("status_reason")]
    public string? StatusReason { get; init; }

    /// <summary>
    /// Full body of the token. Must match token in URL.
    /// </summary>
    [JsonPropertyName("token")]
    public string? Token { get; init; }

    [JsonPropertyName("provider_key")]
    public required ProviderKey ProviderKey { get; init; }

    /// <summary>
    /// ISO 8601 formatted date the token expires. Defaults to 2 months. Set to false to disable expiration.
    /// </summary>
    [JsonPropertyName("expiry_date")]
    [JsonConverter(typeof(OneOfSerializer<OneOf<string, bool>>))]
    public OneOf<string, bool>? ExpiryDate { get; init; }

    /// <summary>
    /// Properties sent to the provider along with the token
    /// </summary>
    [JsonPropertyName("properties")]
    public object? Properties { get; init; }

    /// <summary>
    /// Information about the device the token is associated with.
    /// </summary>
    [JsonPropertyName("device")]
    public Device? Device { get; init; }

    /// <summary>
    /// Information about the device the token is associated with.
    /// </summary>
    [JsonPropertyName("tracking")]
    public Tracking? Tracking { get; init; }
}
