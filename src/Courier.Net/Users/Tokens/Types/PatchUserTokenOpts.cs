using System.Text.Json.Serialization;
using Courier.Net.Users;

#nullable enable

namespace Courier.Net.Users;

public record PatchUserTokenOpts
{
    [JsonPropertyName("patch")]
    public IEnumerable<PatchOperation> Patch { get; init; } = new List<PatchOperation>();
}
