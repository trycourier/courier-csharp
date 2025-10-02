using System.Text.Json;
using System.Text.Json.Serialization;
using Courier.Client;
using Courier.Client.Core;

namespace Courier.Client.Users;

[Serializable]
public record PutUserTokensOpts : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("user_id")]
    public required string UserId { get; set; }

    [JsonPropertyName("tokens")]
    public IEnumerable<UserToken> Tokens { get; set; } = new List<UserToken>();

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
