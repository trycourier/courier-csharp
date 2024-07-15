using System.Text.Json.Serialization;
using Courier.Client.Users;

#nullable enable

namespace Courier.Client.Users;

public record PatchUserTokenOpts
{
    [JsonPropertyName("patch")]
    public IEnumerable<PatchOperation> Patch { get; init; } = new List<PatchOperation>();
}
