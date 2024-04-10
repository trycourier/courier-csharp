using System.Text.Json.Serialization;
using Courier.Net.Users;

namespace Courier.Net.Users;

public class PatchUserTokenOpts
{
    [JsonPropertyName("patch")]
    public List<PatchOperation> Patch { get; init; }
}
