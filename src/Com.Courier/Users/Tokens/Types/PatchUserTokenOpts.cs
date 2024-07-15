using System.Text.Json.Serialization;
using Com.Courier.Users;

#nullable enable

namespace Com.Courier.Users;

public record PatchUserTokenOpts
{
    [JsonPropertyName("patch")]
    public IEnumerable<PatchOperation> Patch { get; init; } = new List<PatchOperation>();
}
