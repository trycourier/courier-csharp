using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;
using OneOf;

namespace Courier.Client.Users;

[Serializable]
public record GetUserTokenResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("status")]
    public TokenStatus? Status { get; set; }

    /// <summary>
    /// The reason for the token status.
    /// </summary>
    [JsonPropertyName("status_reason")]
    public string? StatusReason { get; set; }

    /// <summary>
    /// Full body of the token. Must match token in URL.
    /// </summary>
    [JsonPropertyName("token")]
    public string? Token { get; set; }

    [JsonPropertyName("provider_key")]
    public required ProviderKey ProviderKey { get; set; }

    /// <summary>
    /// ISO 8601 formatted date the token expires. Defaults to 2 months. Set to false to disable expiration.
    /// </summary>
    [JsonPropertyName("expiry_date")]
    public OneOf<string, bool>? ExpiryDate { get; set; }

    /// <summary>
    /// Properties sent to the provider along with the token
    /// </summary>
    [JsonPropertyName("properties")]
    public object? Properties { get; set; }

    /// <summary>
    /// Information about the device the token is associated with.
    /// </summary>
    [JsonPropertyName("device")]
    public Device? Device { get; set; }

    /// <summary>
    /// Information about the device the token is associated with.
    /// </summary>
    [JsonPropertyName("tracking")]
    public Tracking? Tracking { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
