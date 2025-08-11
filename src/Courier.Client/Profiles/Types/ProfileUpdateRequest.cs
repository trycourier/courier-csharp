using System.Text.Json.Serialization;
using Courier.Client.Core;

#nullable enable

namespace Courier.Client;

public record ProfileUpdateRequest
{
    /// <summary>
    /// List of patch operations to apply to the profile.
    /// </summary>
    [JsonPropertyName("patch")]
    public IEnumerable<UserProfilePatch> Patch { get; set; } = new List<UserProfilePatch>();

    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
