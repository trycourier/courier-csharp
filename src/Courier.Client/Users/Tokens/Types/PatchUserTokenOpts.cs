using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client.Users;

public record PatchUserTokenOpts
{
    [JsonPropertyName("patch")]
    public IEnumerable<PatchOperation> Patch { get; set; } = new List<PatchOperation>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
