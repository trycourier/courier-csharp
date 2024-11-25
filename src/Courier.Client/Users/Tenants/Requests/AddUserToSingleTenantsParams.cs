using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client.Users;

public record AddUserToSingleTenantsParams
{
    [JsonPropertyName("profile")]
    public Dictionary<string, object?>? Profile { get; set; }

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
