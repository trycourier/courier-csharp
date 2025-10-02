using System.Text.Json.Serialization;
using Courier.Client.Core;

namespace Courier.Client.Users;

[Serializable]
public record AddUserToSingleTenantsParams
{
    [JsonPropertyName("profile")]
    public Dictionary<string, object?>? Profile { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
