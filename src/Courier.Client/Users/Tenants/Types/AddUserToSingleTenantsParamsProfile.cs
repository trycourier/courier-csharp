using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;

namespace Courier.Client.Users;

/// <summary>
/// AddUserToSingleTenantsParamsProfile is no longer used for Add a User to a Single Tenant
/// </summary>
[Serializable]
public record AddUserToSingleTenantsParamsProfile : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

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
